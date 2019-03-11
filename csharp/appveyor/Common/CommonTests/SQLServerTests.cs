using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Net;

namespace Common.Tests
{
    [TestClass()]
    public class SQLServerTests
    {
        private SQLServer TestEnvJudge()
        {
            SQLServer objDB = null;

            try
            {
                string hostname = Dns.GetHostName();

                //IPAddress[] adrList = Dns.GetHostAddresses(hostname);
                //foreach (IPAddress address in adrList)
                //{
                //    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                //    {
                //        String[] appVeyorEnv = Settings.Default.AppveyorBuildEnv.Split(',');

                //        if (Array.IndexOf(appVeyorEnv, address) > 0)
                //        {
                //            objDB = new SQLServer(Settings.Default.AppveyorSqlServerName,
                //                                  "",
                //                                  Settings.Default.AppveyorSqlServerUser,
                //                                  Settings.Default.AppveyorSqlServerPw);
                //            return objDB;
                //        }
                //    }
                //}

                objDB = new SQLServer(Settings.Default.SqlServerName,
                                      "",
                                      Settings.Default.SqlServerUser,
                                      Settings.Default.SqlServerPw);

                return objDB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod()]
        public void ConnectTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    Assert.AreEqual(true, objDB.Connect());
                }
            }
            finally
            {
                objDB.Disconnect();
                objDB = null;
            }

        }

        [TestMethod()]
        public void DisconnectTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        Assert.AreEqual(true, objDB.Disconnect());
                    }
                }
            }
            finally
            {
                objDB = null;
            }
        }

        [TestMethod()]
        public void BeginTransTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        Assert.AreEqual(true, objDB.BeginTrans());

                        objDB.RollBack();
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
            }
        }

        [TestMethod()]
        public void RollBackTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        objDB.BeginTrans();

                        Assert.AreEqual(true, objDB.RollBack());
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
            }
        }

        [TestMethod()]
        public void ChangeDataTest()
        {
            SQLServer objDB = null;
            Random random = new Random();

            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        int ret = objDB.ChangeData("INSERT INTO inspection.dbo.Test_143336483 VALUES('" + random.Next() + "','A','B','C')");
                        Assert.AreEqual(ret, 1);
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
                random = null;
            }
        }

        [TestMethod()]
        public void CreateAndDropTableTest()
        {
            SQLServer objDB = null;
            Random random = new Random();

            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        bool ret = objDB.CreateAndDropTable("CREATE TABLE Test_" +
                                                   DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond +
                                                   " (id int NOT NULL PRIMARY KEY, col_1 nvarchar(10) NULL, col_2 nvarchar(10) NULL, col_3 nvarchar(10) NULL);");
                        Assert.AreEqual(true, ret);
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
                random = null;
            }

        }

        [TestMethod()]
        public void GetDataTest()
        {
            SQLServer objDB = null;
          
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        DataTable dataTable = objDB.GetData("SELECT * FROM get_test");
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
            }
        }

        [TestMethod()]
        public void GetTableLockInfoTest()
        {
            SQLServer objDB = null;

            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        objDB.BeginTrans();
                        objDB.ChangeData("insert into get_test values (NEXT VALUE FOR get_test_sequence,'','',SYSDATETIME(),SYSDATETIMEOFFSET())");
                        Assert.AreNotEqual(true, objDB.GetTableLockInfo("get_test"));
                        objDB.RollBack();
                    }
                }
            }
            finally
            {
                if (objDB.Connect())
                {
                    objDB.Disconnect();
                }
                objDB = null;
            }
        }
    }
}