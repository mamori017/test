using System;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    class SQLServer
    {
        private SqlConnection Conn = null;
        private SqlTransaction Trans = null;
        private SqlCommand Cmd = null;
        public string ServerName { get; private set; }
        public string UserId { get; private set; }
        public string Catalog { get; private set; }
        public string Password { get; private set; }
        public bool Disposed { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        SQLServer()
        {
            ServerName = Properties.Settings.Default.SqlServerName;
            Catalog = Properties.Settings.Default.SqlServerCatalog;
            UserId = Properties.Settings.Default.SqlServerUser;
            Password = Properties.Settings.Default.SqlServerPassword;
        }

        /// <summary>
        /// Connect
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                Conn = new SqlConnection();
                Conn.ConnectionString = SqlConString();
                Conn.Open();
                Cmd = Conn.CreateCommand();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Connection String
        /// </summary>
        /// <returns></returns>
        private String SqlConString()
        {
            String ret = "Data Source =" + ServerName +
                         ";Initial Catalog=" + Catalog +
                         ";User ID=" + UserId +
                         ";Password=" + Password;
            return ret;
        }

        /// <summary>
        /// Transaction Start
        /// </summary>
        /// <returns></returns>
        public bool BeginTrans()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans.Connection == null)
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

        /// <summary>
        /// Roll Back
        /// </summary>
        /// <returns></returns>
        public bool RollBack()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans.Connection == null)
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

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans.Connection != null)
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

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Change Data
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
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
            finally
            {
                //Dispose
            }
        }
    }
}
