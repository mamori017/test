using System;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class SQLServer
    {
        public SqlConnection Conn { get; private set; }
        public SqlTransaction Trans { get; private set; }
        public SqlCommand Cmd { get; private set; }
        public string ServerName { get; private set; }
        public string UserId { get; private set; }
        public string Catalog { get; private set; }
        public string Password { get; private set; }
        public bool Disposed { get; set; }

        public SQLServer(String SqlServerName, String SqlServerCatalog, String SqlServerUser, String SqlServerPassword)
        {
            ServerName = SqlServerName;
            Catalog = SqlServerCatalog;
            UserId = SqlServerUser;
            Password = SqlServerPassword;
        }

        public bool Connect()
        {
            try
            {
                Conn = new SqlConnection
                {
                    ConnectionString = SqlConString()
                };
                Conn.Open();
                Cmd = Conn.CreateCommand();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private String SqlConString()
        {
            String ret = "Data Source =" + ServerName +
                         ";Initial Catalog=" + Catalog +
                         ";User ID=" + UserId +
                         ";Password=" + Password;
            return ret;
        }

        public bool BeginTrans()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans == null)
                {
                    Trans = Conn.BeginTransaction();
                    Cmd.Transaction = Trans;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RollBack()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans != null)
                {
                    Trans.Rollback();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Commit()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans != null)
                {
                    Trans.Commit();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetData(string sql)
        {
            SqlDataReader reader = null;
            DataTable ret = null;
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    reader = Cmd.ExecuteReader();
                    if (reader != null)
                    {
                        ret = new DataTable();
                        ret.Load(reader);
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangeData(String sql)
        {
            int retCnt = 0;
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    retCnt = Cmd.ExecuteNonQuery();
                }
                return retCnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateAndDropTable(String sql)
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    try
                    {
                        Cmd.CommandText = sql;
                        Cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetTableLockInfo(string objectName)
        {
            SqlDataReader reader = null;
            DataTable dataTable = null;
            String sql = "";
            bool ret = false;

            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    sql = Query.GetLockInfoQuery();
                    Cmd.CommandText = sql;

                    reader = Cmd.ExecuteReader();

                    if (reader != null)
                    {
                        dataTable = new DataTable();
                        dataTable.Load(reader);

                        for (int i = 0; i < dataTable.Rows.Count - 1; i++)
                        {
                            if (dataTable.Rows[i].ItemArray[0].ToString() == "OBJECT" &&
                                dataTable.Rows[i].ItemArray[2].ToString() == objectName &&
                                dataTable.Rows[i].ItemArray[5].ToString() == "GRANT")
                            {
                                ret = true;
                            }
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string SetLockType(String type)
        {
            string ret = "";

            switch (type)
            {
                case "DB":
                    ret = "DB単位";
                    break;
                case "TAB":
                    ret = "テーブル単位";
                    break;
                case "PAGE":
                    ret = "ページ単位";
                    break;
                case "ROW":
                    ret = "行単位";
                    break;
                case "KEY":
                    ret = "キー単位";
                    break;
                default:
                    break;
            }
            return ret;
        }

        private static string SetLockRequest(String type)
        {
            string ret = "";

            switch (type)
            {
                case "S":
                    ret = "共有ロック";
                    break;
                case "X":
                    ret = "排他ロック";
                    break;
                case "U":
                    ret = "更新ロック";
                    break;
                case "IS":
                    ret = "インテント共有";
                    break;
                case "IX":
                    ret = "インテント排他";
                    break;
                case "SIX":
                    ret = "インテント排他の共有";
                    break;
                case "IU":
                    ret = "インテント更新";
                    break;
                case "SIU":
                    ret = "共有インテント更新";
                    break;
                case "UIX":
                    ret = "更新インテント排他";
                    break;
                default:
                    break;
            }
            return ret;
        }

        private static string SetLockRequestStatus(String type)
        {
            string ret = "";

            switch (type)
            {
                case "GRANT":
                    ret = "GRANT";
                    break;
                case "WAIT":
                    ret = "WAIT";
                    break;
                default:
                    break;
            }
            return ret;
        }


        private static class Query
        {
            public static string GetLockInfoQuery()
            {
                String sql = "";

                sql += "\n" + "SELECT";
                sql += "\n" + "  resource_type AS type";
                sql += "\n" + " ,resource_associated_entity_id as entity_id";
                sql += "\n" + " ,(CASE WHEN resource_type = 'OBJECT' THEN";
                sql += "\n" + "             OBJECT_NAME(resource_associated_entity_id)";
                sql += "\n" + "        ELSE";
                sql += "\n" + "             (SELECT";
                sql += "\n" + "                OBJECT_NAME(OBJECT_ID)";
                sql += "\n" + "              FROM";
                sql += "\n" + "                sys.partitions";
                sql += "\n" + "              WHERE";
                sql += "\n" + "                hobt_id = resource_associated_entity_id)";
                sql += "\n" + "        END) AS object_name";
                sql += "\n" + " ,request_mode";
                sql += "\n" + " ,request_type";
                sql += "\n" + " ,request_status";
                sql += "\n" + " ,request_session_id AS Session_id";
                sql += "\n" + " ,(SELECT";
                sql += "\n" + "     hostname";
                sql += "\n" + "   FROM";
                sql += "\n" + "     sys.sysprocesses";
                sql += "\n" + "   WHERE";
                sql += "\n" + "     spid = request_session_id) AS ProcessName";
                sql += "\n" + "FROM";
                sql += "\n" + "  sys.dm_tran_locks";
                sql += "\n" + "WHERE";
                sql += "\n" + "  resource_type <> 'DATABASE'";
                sql += "\n" + "ORDER BY";
                sql += "\n" + "  request_session_id";

                return sql;
            }
        }

    }
}
