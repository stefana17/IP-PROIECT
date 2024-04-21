/**************************************************************************
 *                                                                        *
 *  File:        IQuizState.cs                                            *
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

namespace QuizState
{
    /// <summary>
    /// Interfața IQuizState definește metoda Display() pe care fiecare stare a sablonului State o va implementa.
    /// Sablonul de proiectare State se bazează pe ideea de a permite unui obiect să își schimbe comportamentul atunci când starea internă se schimbă.Acesta permite unei clase să-și schimbe comportamentul atunci când este invocată o anumită metodă, fără a modifica codul care apelează acea metodă.
    /// În implementarea sa, sablonul State implică crearea unei ierarhii de clase de stare care implementează o interfață comună. 
    /// Această interfață definește metodele care vor fi utilizate de context pentru a modifica comportamentul său. 
    ///</summary>
    public interface IQuizState
    {
        #region Public Methods
        /// <summary>
        /// Metoda Display() este implementată de fiecare clasă de stare și are rolul de a afișa interfața grafică corespunzătoare stării curente.
        /// </summary>
        /// <param name="owner">Form-ul pe care îl afișează starea curentă.</param>
        void Display(Form owner);
        #endregion
    }
}
