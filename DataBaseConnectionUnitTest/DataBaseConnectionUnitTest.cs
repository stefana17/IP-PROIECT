/**************************************************************************
 *                                                                        *
 *  File:        DataBaseConnectionUnitTest.cs                            *
 *  Copyright:   (c) 2023, Hușman Carla-Gabriela                          *
 *  E-mail:      carla-gabriela.husman@student.tuiasi.ro                  *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseConnection;
using System.Data;

namespace DataBaseConnectionUnitTest
{
    /// <summary>
    /// Teste unitare pentru clasa DataBaseManager.
    /// </summary>
    [TestClass]
    public class DataBaseConnectionUnitTest
    {
        #region Test Methods
        /// <summary>
        /// Verifică dacă metoda GetInstance returnează aceeași instanță a clasei DataBaseManager.
        /// </summary>
        [TestMethod]
        public void GetInstance_Returns_SameInstance()
        {
            var expectedInstance = DataBaseManager.GetInstance();
            var actualInstance = DataBaseManager.GetInstance();

            Assert.AreSame(expectedInstance, actualInstance);
        }

        /// <summary>
        /// Verifică dacă metoda GetConnection returnează conexiunea la baza de date.
        /// </summary>
        [TestMethod]
        public void GetConnection_Returns_Connection()
        {
            var db = DataBaseManager.GetInstance();
            var connection = db.GetConnection();

            Assert.IsNotNull(connection);
            Assert.IsTrue(connection.State == ConnectionState.Open);
        }

        /// <summary>
        /// Verifică dacă metoda CloseConnection închide conexiunea la baza de date.
        /// </summary>
        [TestMethod]
        public void CloseConnection_Closes_Connection()
        {
            var db = DataBaseManager.GetInstance();
            var connection = db.GetConnection();
            db.CloseConnection();

            Assert.IsTrue(connection.State == ConnectionState.Closed);
        }

        /// <summary>
        /// Verifică dacă metoda CloseConnection aruncă excepție când conexiunea este deja închisă.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CloseConnection_Throws_Exception()
        {
            DataBaseManager db = DataBaseManager.GetInstance();
            db.CloseConnection();
            db.CloseConnection();
        }
        #endregion
    }
}