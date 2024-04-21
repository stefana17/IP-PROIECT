/**************************************************************************
 *                                                                        *
 *  File:        Startegy.cs                                              *
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

using TesteSimulareAdmitere;

namespace SettingsStrategy
{
    /// <summary>
    /// Clasa Strategy este o clasă abstractă pentru implementarea șablonului Strategy și definește o metodă abstractă SetTimer().
    /// Aceasta va fi implementată în clasele derivate pentru a seta un timer în funcție de setările alese de utilizator.
    /// </summary>
    public abstract class Strategy
    {
        #region Public Abstract Method
        /// <summary>
        /// Metoda abstractă pentru setarea unui timer în funcție de strategia specificată.
        /// </summary>
        /// <param name="questionStateForm">Form pentru starea întrebărilor.</param>
        /// <param name="time">Timpul pentru setarea timerului.</param>
        public abstract void SetTimer(QuestionStateForm questionStateForm, string time);
        #endregion
    }
}
