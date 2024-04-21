/**************************************************************************
 *                                                                        *
 *  File:        UserManagerUnitTest.cs                                   *
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
using System;

namespace UserManagerUnitTest
{
    /// <summary>
    /// Teste unitare pentru clasa UserManagerUnitTest.
    /// </summary>
    [TestClass]
    public class UserManagerUnitTest
    {
        #region Test Methods
        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unui nume cu lungime < 3, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_LastName_Length()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("as", "ana", "anais", "anais");
        }

        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unui prenume cu lungime < 3, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_FirstName_Length()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("ana", "an", "anais", "anais");
        }

        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unui nume de utilizator cu lungime < 5, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_UserName_Length()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("ana", "an", "a", "anais");
        }

        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unei parole cu lungime < 5, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_Password_Length()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("ana", "ana", "anais", "a");
        }

        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unui nume care conține cifre, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_FirstName_Digit()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("ana", "ana55", "anais", "anais");
        }

        /// <summary>
        /// Verifică dacă metoda AddUser, la adăugarea unui prenume care conține cifre, aruncă excepție.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_Throws_Exception_LastName_Digit()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            userManager.AddUser("ana34ana", "ana", "anais", "anais");
        }

        /// <summary>
        /// Verifică dacă metoda GetUsers returnează o listă validă.
        /// </summary>
        [TestMethod]
        public void GetUsers_IsNotNull()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            Assert.IsNotNull(userManager.GetUsers());
        }

        /// <summary>
        /// Verifică dacă primul utilizator din baza de date este cel de testare, numeUtilizator = a.
        /// </summary>
        [TestMethod]
        public void GetUsers_Username()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            var lista = userManager.GetUsers();
            Assert.AreEqual("a", lista[0].numeUtilizator);
        }

        /// <summary>
        /// Verifică dacă primul utilizator din baza de date este cel de testare, parola = a.
        /// </summary>
        [TestMethod]
        public void GetUsers_Password()
        {
            UserManager.UserManager userManager = new UserManager.UserManager();
            var lista = userManager.GetUsers();
            Assert.AreEqual("a", lista[0].parola);
        }
        #endregion
    }
}