﻿using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

    }
}