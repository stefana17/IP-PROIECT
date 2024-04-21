/**************************************************************************
*                                                                        *
*  File:        QuestionManager.cs                                       *
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
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DataBaseConnection;
using System.Data.SQLite;
using System.IO;

namespace QuestionManager
{
    /// <summary>
    /// Clasa QuestionManager se ocupă de interogarea bazei de date pentru a prelua întrebările și răaspunsurile corecte pentru crearea testelor.
    /// </summary>
    public class QuestionManager
    {

        #region Public Structs
        /// <summary>
        /// Structură pentru stocarea informațiilor despre o întrebare.
        /// </summary>
        public struct Question
        {
            public readonly Image image;
            public readonly int response;

            /// <summary>
            /// Constructorul pentru inițializarea informațiilor despre o întrebare.
            /// </summary>
            /// <param name="image">Imaginea cu întrebarea.</param>
            /// <param name="raspuns">Răspunsul corect.</param>
            public Question(Image image, int raspuns)
            {
                this.image = image;
                this.response = raspuns;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Preia întrebarile din baza de date pentru materia aleasă.
        /// </summary>
        /// <param name="subject">Materia pentru care se preiau intrebarile.</param>
        /// <returns>Un array de întrebari.</returns>
        public static Question[] GetQuestions(string subject)
        {
            List<Question> list = new List<Question>();

            DataBaseManager db = DataBaseManager.GetInstance();

            SQLiteCommand sqlite_cmd = db.GetConnection().CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + subject;

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                var stream = new MemoryStream((byte[])sqlite_datareader.GetValue(0));
                Image img = Image.FromStream(stream);

                Question question = new Question(img, sqlite_datareader.GetInt32(1));

                list.Add(question);

            }

            sqlite_datareader.Dispose();
            sqlite_cmd.Dispose();

            return list.ToArray();
        }
        #endregion

        #region Public Methods 
        /// <summary>
        /// Generează 10 întrebări de informatică aleatorii.
        /// </summary>
        /// <returns>Un array de 10 întrebări.</returns>
        public static Question[] GenerateInfoQuestions()
        {
            Question[] questionsInfo = new Question[10];
            try
            {
                Question[] allQuestions = GetQuestions("IntrebariInformatica");
                Random rand = new Random();
                allQuestions = allQuestions.OrderBy(x => rand.Next()).ToArray();
                questionsInfo = allQuestions.Take(10).ToArray();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Eroare la preluarea întrebărilor de informatică din baza de date: " + e.Message);
            }

            return questionsInfo;
        }

        /// <summary>
        /// Generează 10 întrebări de matematică aleatorii.
        /// </summary>
        /// <returns>Un array de 10 întrebări.</returns>
        public static Question[] GenerateMathQuestions()
        {
            Question[] questionsMath = new Question[10];
            try
            {
                Question[] allQuestions = GetQuestions("IntrebariMatematica");
                Random rand = new Random();
                allQuestions = allQuestions.OrderBy(x => rand.Next()).ToArray();
                questionsMath = allQuestions.Take(10).ToArray();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Eroare la preluarea întrebărilor de matematică din baza de date: " + e.Message);
            }
            return questionsMath;
        }
        #endregion
    }
}