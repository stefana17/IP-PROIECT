/**************************************************************************
 *                                                                        *
 *  File:        QuestionManagerUnitTest.cs                               *
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

namespace QuestionManagerUnitTest
{
    /// <summary>
    /// Teste unitare pentru clasa QuestionManagerUnitTest.
    /// </summary>
    [TestClass]
    public class QuestionManagerUnitTest
    {
        #region Test Methods
        /// <summary>
        /// Verifică dacă metoda GetQuestions preia toate cele 30 de întrebări de matematică din baza de date.
        /// </summary>
        [TestMethod]
        public void GetQuestions_AreEqual_QuestionsSizeMath()
        {
            var intrebari = QuestionManager.QuestionManager.GetQuestions("IntrebariMatematica");
            Assert.AreEqual(30, intrebari.Length);
        }

        /// <summary>
        /// Verifică dacă metoda GetQuestions preia toate cele 30 de întrebări de informatică din baza de date.
        /// </summary>
        [TestMethod]
        public void GetQuestions_AreEqual_QuestionsSizeInfo()
        {
            var intrebari = QuestionManager.QuestionManager.GetQuestions("IntrebariInformatica");
            Assert.AreEqual(30, intrebari.Length);
        }

        /// <summary>
        /// Verifică dacă metoda GenerateInfoQuestions generează 10 întrebări random.
        /// </summary>
        [TestMethod]
        public void GenerateInfoQuestions()
        {
            var intrebari = QuestionManager.QuestionManager.GenerateInfoQuestions();
            var intrebari2 = QuestionManager.QuestionManager.GenerateInfoQuestions();
            Assert.AreNotSame(intrebari[0], intrebari2[0]);
        }

        /// <summary>
        /// Verifică dacă metoda GenerateMathQuestions generează 10 întrebări random.
        /// </summary>
        [TestMethod]
        public void GenerateMathQuestions()
        {
            var intrebari = QuestionManager.QuestionManager.GenerateMathQuestions();
            var intrebari2 = QuestionManager.QuestionManager.GenerateMathQuestions();
            Assert.AreNotSame(intrebari[0], intrebari2[0]);
        }

        /// <summary>
        /// Verifică dacă prima intrebare din baza de date are răspunsul 1.
        /// </summary>
        [TestMethod]
        public void VerifyTheFirstQuestion_Info()
        {
            var intrebari = QuestionManager.QuestionManager.GetQuestions("IntrebariInformatica");

            Assert.AreEqual(1,intrebari[0].response);
        }

        /// <summary>
        /// Verifică dacă prima intrebare din baza de date are răspunsul 1.
        /// </summary>
        [TestMethod]
        public void VerifyTheFirstQuestion_Math()
        {
            var intrebari = QuestionManager.QuestionManager.GetQuestions("IntrebariMatematica");

            Assert.AreEqual(1, intrebari[0].response);
        }
        #endregion
    }
}
