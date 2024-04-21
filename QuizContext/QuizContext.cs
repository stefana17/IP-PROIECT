/**************************************************************************
 *                                                                        *
 *  File:        QuizContext.cs                                           *
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

using QuizState;
using System;
using System.Windows.Forms;

namespace QuizContext
{
    /// <summary>
    /// Clasa QuizContext ceste clasa care gestionează starea quiz-ului și întrebările asociate.
    /// </summary>
    public class QuizContext
    {
        #region Private Member Variables
        /// <summary>
        /// Un array de obiecte Question care reprezintă întrebarile testului.
        /// </summary>
        private QuestionManager.QuestionManager.Question[] _questions;
        /// <summary>
        /// O referință la starea curentă a quiz-ului, implementată prin intermediul interfeței IQuizState.
        /// </summary>
        private IQuizState _currentState;
        /// <summary>
        /// Scorul curent al utilizatorului.
        /// </summary>
        private int _score;
        #endregion

        #region Contructors
        /// <summary>
        /// Constructorul clasei care inițializează scorul cu zero și starea curentă a quiz-ului cu starea de start.
        /// </summary>
        public QuizContext()
        {
            _score = 0;
            _currentState = new StartState();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Setează starea curentă a quiz-ului cu starea dată ca parametru.
        /// </summary>
        /// <param name="state">Starea de setat</param>
        public void SetState(IQuizState state)
        {
            _currentState = state;
        }

        /// <summary>
        /// Setează întrebările pentru quiz.
        /// </summary>
        /// <param name="questions">Lista de întrebări de setat</param>
        public void SetQuestion(QuestionManager.QuestionManager.Question[] questions)
        {
            _questions = questions;         
        }

        /// <summary>
        /// Afișează starea curentă a quiz-ului.
        /// </summary>
        /// <param name="owner">Form-ul pe care se va afișa starea curentă.</param>
        public void DisplayState(Form owner)
        {
            _currentState.Display(owner);
        }

        /// <summary>
        /// Incrementează scorul cu 1.
        /// </summary>
        public void IncreaseScore()
        {
            _score++;
        }

        /// <summary>
        /// Returnează scorul curent.
        /// </summary>
        /// <returns>Scorul curent</returns>
        public int GetScore()
        {
            return _score;
        }

        /// <summary>
        /// Setează scorul la 0.
        /// </summary>
        public void SetScore()
        {
            _score = 0;
        }

        /// <summary>
        /// Returnează întrebarea de la indexul dat ca parametru.
        /// </summary>
        /// <param name="index">Indexul întrebării de returnat</param>
        /// <returns>Întrebarea de la indexul dat ca parametru</returns>
        public QuestionManager.QuestionManager.Question GetQuestion(int index)
        {
            if (index < 0 || index >= _questions?.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _questions[index];
        }
        #endregion
    }
}
