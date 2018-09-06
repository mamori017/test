using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                //string hostname = Dns.GetHostName();

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

                objDB = new SQLServer(SQLServerSettings.Default.AppveyorSqlServerName,
                                      "",
                                      SQLServerSettings.Default.AppveyorSqlServerUser,
                                      SQLServerSettings.Default.AppveyorSqlServerPw);
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
                        bool ret = objDB.CreateAndDropTable("CREATE DATABASE SampleDB");

                        //bool ret = objDB.CreateAndDropTable("CREATE TABLE SampleDB.Test (id int NOT NULL PRIMARY KEY, col_1 nvarchar(10) NULL);");

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
    }
}