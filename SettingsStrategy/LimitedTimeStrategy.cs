/**************************************************************************
 *                                                                        *
 *  File:        LimitedTimeStrategy.cs                                   *
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

using System;
using System.Windows.Forms;
using TesteSimulareAdmitere;
using QuizState;

namespace SettingsStrategy
{
    /// <summary>
    /// Clasa LimitedTimeStrategy este clasa care implementeaza strategia care permite utilizatorului să parcurgă quiz-ul cu timp limitat.
    /// </summary>
    public class LimitedTimeStrategy : Strategy
    {
        #region Private Member Variables
        private Label _labelTimp;
        private Label _labelOra;
        private Label _labelMinute;
        private Label _labelSecunde;
        private Timer _timerTest;
        private QuestionStateForm _questionStateForm;
        private int _count = 59;
        #endregion

        #region Public Methods
        /// <summary>
        /// Seteaza timerul pentru quiz in functie de timpul dat.
        /// </summary>
        /// <param name="questionStateForm">Form-ul curent care conține intrebările.</param>
        /// <param name="time">Timpul alocat quiz-ului.</param>
        public override void SetTimer(QuestionStateForm questionStateForm, string time)
        {
            _questionStateForm = questionStateForm;

            _labelSecunde = new Label
            {
                Location = new System.Drawing.Point(985, 35),
                Text = "59 s"
            };

            _labelMinute = new Label
            {
                Location = new System.Drawing.Point(950, 35),
                Text = "0 m"
            };

            _labelOra = new Label
            {
                Location = new System.Drawing.Point(910, 35),
                Text = "0 h"
            };

            _labelTimp = new Label
            {
                Location = new System.Drawing.Point(830, 35),
                Text = "Timp ramas:"
            };

            _timerTest = new Timer
            {
                Interval = 1000,
                Enabled = false
            };

            string[] tmp = time.Split(' ');
            string type = tmp[1];

            if (type == "min")
            {
                _labelMinute.Text = tmp[0] + " m";
            }
            else
            {
                _labelOra.Text = tmp[0] + " h";
            }

            questionStateForm.Controls.Add(_labelSecunde);
            questionStateForm.Controls.Add(_labelMinute);
            questionStateForm.Controls.Add(_labelOra);
            questionStateForm.Controls.Add(_labelTimp);

            _timerTest.Tick += new EventHandler(timerTest_Tick);
            questionStateForm.timerTest = _timerTest;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Funcția de callback pentru timer.
        /// </summary>
        /// <param name="sender">Obiectul care a declanșat evenimentul.</param>
        /// <param name="e">Argumentele evenimentului.</param>
        private void timerTest_Tick(object sender, EventArgs e)
        {
            _count--;
            _labelSecunde.Text = _count.ToString() + " s";

            if (_count == 0)
            {
                int minut = Convert.ToInt32(_labelMinute.Text.Split(' ')[0]);
                int ora = Convert.ToInt32(_labelOra.Text.Split(' ')[0]);

                if (minut == 0 && ora == 0)
                {
                    TesteSimulareAdmitere.TesteSimulareAdmitere.quizContext.SetState(new EndState());
                    TesteSimulareAdmitere.TesteSimulareAdmitere.quizContext.DisplayState(_questionStateForm);
                    _timerTest.Enabled = false;
                    return;
                }
                else if (ora == 0)
                {
                    _labelMinute.Text = (minut - 1).ToString() + " m";
                }
                else if (ora == 1 && minut == 0)
                {
                    _labelOra.Text = "0 h";
                    _labelMinute.Text = "59 m";
                }
                else if (minut == 0)
                {
                    _labelOra.Text = (ora - 1).ToString() + " h";
                }
                else
                {
                    _labelMinute.Text = (minut - 1).ToString() + " m";
                }

                _count = 59;
            }
        }
    }
    #endregion
}