/**************************************************************************
 *                                                                        *
 *  File:        UnlimitedTimeStrategy.cs                                 *
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

namespace SettingsStrategy
{
    /// <summary>
    /// Clasa UnlimitedTimeStrategy este clasa care implementeaza strategia care permite utilizatorului să parcurgă quiz-ul cu timp nelimitat.
    /// </summary>
    public class UnlimitedTimeStrategy : Strategy
    {
        #region Public Methods
        /// <summary>
        /// Seteaza timerul pentru quiz cu timp nelimitat.
        /// </summary>
        /// <param name="questionStateForm">Form-ul curent care conține intrebările.</param>
        /// <param name="time">Timpul alocat quiz-ului.</param>
        public override void SetTimer(QuestionStateForm questionStateForm, string time)
        {

            Label labelTimpNelimitat = new Label
            {
                Text = time,
                Size = new System.Drawing.Size(85, 16),
                Location = new System.Drawing.Point(908, 35),
                Name = "labelTimpNelimitat"
            };
            questionStateForm.Controls.Add(labelTimpNelimitat);
        }
        #endregion
    }
}
