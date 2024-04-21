/**************************************************************************
 *                                                                        *
 *  File:        StartState.cs                                            *
 *  Copyright:   (c) 2023, Hușman Carla-Gabriela                          *
 *  E-mail:      carla-gabriela.husman@student.tuiasi.ro                  *
 *  Website:     https://github.com/aeerdna01/ProjectIP                   *
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
    /// Clasa StartState este o clasă de stare a sablonului State.
    /// Aceasta implementează interfața IQuizState și are rolul de a afișa interfața grafică pentru comportamentul stării de început a aplicației.
    /// Se va afișa lista de materii pentru care se dorește susținerea testului și posibilitatea de a intra în setările aplicației.
    /// </summary>
    public class StartState : IQuizState
    {
        #region Interface Implementation
        /// <summary>
        /// Implementarea metodei Display() din interfața IQuizState. 
        /// Metoda are rolul de a afișa interfața grafică corespunzătoare stării curente.
        /// </summary>
        /// <param name="owner">Form-ul pe care îl afișează starea curentă</param>
        public void Display(Form owner)
        {
            StartStateForm nextForm = new StartStateForm();
            nextForm.Show(owner);
            owner.Hide();
        }
        #endregion
    }
}

