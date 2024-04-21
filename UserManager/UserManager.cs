/**************************************************************************
*                                                                        *
*  File:        UserManager.cs                                           *
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
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using DataBaseConnection;

namespace UserManager
{
    /// <summary>
    /// Clasa UserManager gestionează operațiile pe utilizatori și se ocupă de interogarea bazei de date pentru a prelua și salva datele utilizatorilor.
    /// </summary>
    public class UserManager
    {
        #region Private Member Variables
        private List<User> _users;
        #endregion

        #region Public Structs
        /// <summary>
        /// Structură pentru stocarea informațiilor despre un utilizator.
        /// </summary>
        public struct User
        {
            public readonly string nume;
            public readonly string prenume;
            public readonly string numeUtilizator;
            public readonly string parola;

            /// <summary>
            /// Constructorul pentru inițializarea informațiilor despre un utilizator.
            /// </summary>
            /// <param name="nume">Numele utilizatorului.</param>
            /// <param name="prenume">Prenumele utilizatorului.</param>
            /// <param name="numeUtilizator">Numele de utilizator.</param>
            /// <param name="parola">Parola utilizatorului.</param>
            public User(string nume, string prenume, string numeUtilizator, string parola)
            {
                this.nume = nume;
                this.prenume = prenume;
                this.numeUtilizator = numeUtilizator;
                this.parola = parola;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructorul clasei UserManager. Inițializează lista de utilizatori cu o listă nouă vidă.
        /// </summary>
        public UserManager()
        {
            _users = new List<User>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adaugă un utilizator în baza de date.
        /// </summary>
        /// <param name="nume">Numele utilizatorului.</param>
        /// <param name="prenume">Prenumele utilizatorului.</param>
        /// <param name="numeUtilizator">Numele de utilizator.</param>
        /// <param name="parola">Parola utilizatorului.</param>
        public void AddUser(string nume, string prenume, string numeUtilizator, string parola)
        {
            if (nume.Length < 3 || prenume.Length < 3)
                throw new Exception("Numele și prenumele trebuie sa aibă lungime minim 3.");

            if (numeUtilizator.Length < 5 || parola.Length < 5)
                throw new Exception("Nume de utilizator sau parola prea scurte. Minim 5 caractere.");

            if (nume.Any(char.IsDigit) || prenume.Any(char.IsDigit))
                throw new Exception("Numele și prenumele nu trebuie să conțină cifre.");

            try
            {
                DataBaseManager db = DataBaseManager.GetInstance();
                SQLiteCommand sqlite_cmd = db.GetConnection().CreateCommand();

                sqlite_cmd.CommandText = "INSERT INTO Utilizatori (Nume, Prenume, NumeUtilizator, Parola) VALUES(@nume, @prenume, @numeUtilizator, @parola)";
                sqlite_cmd.Parameters.AddWithValue("@nume", nume);
                sqlite_cmd.Parameters.AddWithValue("@prenume", prenume);
                sqlite_cmd.Parameters.AddWithValue("@numeUtilizator", numeUtilizator);
                sqlite_cmd.Parameters.AddWithValue("@parola", parola);

                User user = new User(nume, prenume, numeUtilizator, parola);

                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la adăugarea utilizatorului în baza de date: " + ex.Message);
            }
        }

        /// <summary>
        /// Citeste utilizatorii din baza de date și îi adaugă în lista _users.
        /// </summary>
        public void ReadUsers()
        {
            try
            {
                DataBaseManager db = DataBaseManager.GetInstance();
                SQLiteCommand sqlite_cmd = db.GetConnection().CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM Utilizatori";

                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    User user = new User(sqlite_datareader.GetString(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetString(3));
                    _users.Add(user);
                }

                sqlite_datareader.Dispose();
                sqlite_cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la citirea datelor utilizatorului din baza de date: " + ex.Message);
            }
        }

        /// <summary>
        /// Returnează o listă cu toți utilizatorii din baza de date. Metoda citeste utilizatorii din baza de date folosind metoda privată ReadUsers().
        /// </summary>
        /// <returns>O listă cu toți utilizatorii din baza de date</returns>
        public List<User> GetUsers()
        {
            ReadUsers();
            return _users;
        }
        #endregion
    }
}