/**************************************************************************
 *                                                                        *
 *  File:        EndState.cs                                              *
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

using System.Windows.Forms;
using TesteSimulareAdmitere;

namespace QuizState
{
    /// <summary>
    /// Clasa EndState este o clasă de stare a sablonului State.
    /// Aceasta implementează interfața IQuizState și are rolul de a afișa interfața grafică pentru starea finală a testului.
    /// Se va afișa punctajul obținut cu posibilitatea de vizualizare a răspunsurilor corecte.
    /// </summary>
    public class EndState : IQuizState
    {
        #region Interface Implementation
        /// <summary>
        /// Implementarea metodei Display() din interfața IQuizState. 
        /// Metoda are rolul de a afișa interfața grafică corespunzătoare stării curente.
        /// </summary>
        /// <param name="owner">Form-ul pe care îl afișează starea curentă</param>
        public void Display(Form owner)
        {
            EndStateForm nextForm = new EndStateForm(((QuestionStateForm)owner).allquestions, ((QuestionStateForm)owner).userAnswer);
            nextForm.Show(owner);
            owner.Hide();
        }
        #endregion
    }
}
