/**************************************************************************
 *                                                                        *
 *  File:        QuizContextUnitTest.cs                                   *
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

namespace QuizContextUnitTest
{
    [TestClass]
    public class QuizContextUnitTest
    {
        /// <summary>
        /// Verifică dacă constructorul a funcționat
        /// </summary>
        [TestMethod]
        public void QuizContext_Constructor_IsNotNull()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            Assert.IsNotNull(context);
        }

        /// <summary>
        /// Verifică dacă constructorul a funcționat
        /// </summary>
        [TestMethod]
        public void GetScore_AreEqual()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            Assert.AreEqual(0, context.GetScore());
        }

        /// <summary>
        /// Verifică dacă metoda SetScore setează corect
        /// </summary>
        [TestMethod]
        public void SetScore_AreEqual()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            context.SetScore();
            Assert.AreEqual(0, context.GetScore());
        }

        /// <summary>
        /// Verifică dacă metoda IncreaseScore incrementeaza scorul corect
        /// </summary>
        [TestMethod]
        public void IncreaseScore_AreEqual()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            context.IncreaseScore();
            Assert.AreEqual(1, context.GetScore());
        }

        /// <summary>
        /// Verifică dacă metoda GetQuestion returnează un array diferit de null
        /// </summary>
        [TestMethod]
        public void GetQuestion_IsNotNull()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            QuestionManager.QuestionManager.Question[] question = QuestionManager.QuestionManager.GenerateInfoQuestions();
            context.SetQuestion(question);
            Assert.IsNotNull(context.GetQuestion(1));
        }

        /// <summary>
        /// Verifică dacă metoda GetQuestion aruncă excepția ArgumentOutOfRangeException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetQuestion_Throws_Exception()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            QuestionManager.QuestionManager.Question[] question = QuestionManager.QuestionManager.GenerateInfoQuestions();
            context.SetQuestion(question);
            Assert.IsNotNull(context.GetQuestion(12));
        }

        /// <summary>
        /// Verifică dacă metoda GetQuestion returnează un array de dimensiune 10
        /// </summary>
        [TestMethod]
        public void GetQuestion_Size_AreEqual()
        {
            QuizContext.QuizContext context = new QuizContext.QuizContext();
            QuestionManager.QuestionManager.Question[] question = QuestionManager.QuestionManager.GenerateInfoQuestions();
            Assert.AreEqual(10, question.Length);
        }
    }
}