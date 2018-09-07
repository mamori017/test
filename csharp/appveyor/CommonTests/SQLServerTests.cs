using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Data;

namespace Common.Tests
{
    [TestClass()]
    public class SQLServerTests
    {
        SQLServer objDB = null;

        [TestInitialize]
        public void Initialize()
        {
            objDB = new SQLServer(SQLServerSettings.Default.AppveyorSqlServerName,"",SQLServerSettings.Default.AppveyorSqlServerUser,SQLServerSettings.Default.AppveyorSqlServerPw);
        }
        private void SetUseDB()
        {
            objDB.ChangeData("USE TestDB");
        }

        private void SetEnv()
        {
            objDB.CreateAndDrop("DROP DATABASE IF EXISTS TestDB;");
            objDB.CreateAndDrop("CREATE DATABASE TestDB;");
        }

        [TestMethod()]
        public void ConnectTest()
        {
            try
            {
                if (objDB != null)
                {
                    Assert.AreEqual(true, objDB.Connect());
                }
            }
            finally
            {
                objDB.Disconnect();
            }
        }

        [TestMethod()]
        public void DisconnectTest()
        {
            if (objDB != null)
            {
                if (objDB.Connect())
                {
                    Assert.AreEqual(true, objDB.Disconnect());
                }
            }
        }


        [TestMethod()]
        public void CreateAndDropTest()
        {
            try
            {
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        SetUseDB();
                        SetEnv();
                        Assert.AreEqual(true, objDB.CreateAndDrop("CREATE TABLE Test (id int NOT NULL PRIMARY KEY, col_1 nvarchar(10) NULL);"));
                    }
                }
            }
            finally
            {
                if (objDB.Conn.State == ConnectionState.Open)
                {
                    objDB.Disconnect();
                }
            }

        }


        [TestMethod()]
        public void BeginTransAndRollBackTest2()
        {
            try
            {
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        SetUseDB();
                        Assert.AreEqual(true, objDB.BeginTrans());
                        Assert.AreEqual(true, objDB.RollBack());
                    }
                }
            }
            finally
            {
                if (objDB.Conn.State == ConnectionState.Open)
                {
                    objDB.Disconnect();
                }
            }
        }

    }
}