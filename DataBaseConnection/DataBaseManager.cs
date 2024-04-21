/**************************************************************************
*                                                                        *
*  File:        DataBaseManager.cs                                       *
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
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DataBaseConnection
{
    /// <summary>
    /// Clasă pentru gestionarea conexiunii la baza de date. Utilizează șablonul Singleton pentru a asigura o singură instanță a conexiunii la baza de date.
    /// </summary>
    public class DataBaseManager
    {

        #region Private Member Variables
        /// <summary>
        /// Conexiunea la baza de date.
        /// </summary>
        private readonly SQLiteConnection _sqlite_conn;
        /// <summary>
        /// Singura instanță a clasei DataBaseManager.
        /// </summary>
        static private DataBaseManager _instance;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructorul clasei. Creează o nouă conexiune la baza de date SQLite.
        /// </summary>
        private DataBaseManager()
        {
            try
            {
                _sqlite_conn = new SQLiteConnection("Data Source = database.db; Version = 3; New = True; Compress = True; ");
                _sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returnează instanța comună la nivel de aplicație a clasei DataBaseManager, prin intermediul Singleton Design Pattern.
        /// </summary>
        /// <returns>Instanța unică a clasei DataBaseManager.</returns>
        public static DataBaseManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBaseManager();
            }
            return _instance;
        }

        /// <summary>
        /// Returnează conexiunea la baza de date. Deschide conexiunea dacă aceasta nu este deja deschisă.
        /// </summary>
        /// <returns>Conexiunea la baza de date sau valoarea null în cazul în care a apărut o eroare la deschiderea conexiunii.</returns>
        public SQLiteConnection GetConnection()
        {
            try
            {
                if (_sqlite_conn.State == ConnectionState.Closed)
                {
                    _sqlite_conn.Open();
                }
                return _sqlite_conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare la deschiderea conexiunii la baza de date: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Închide conexiunea la baza de date și eliberează resursele asociate.
        /// </summary>
        public void CloseConnection()
        {
         
            if (_sqlite_conn.State != ConnectionState.Closed)
            {
                _sqlite_conn.Close();
                //_sqlite_conn.Dispose();
            }
            else
            {
                throw new Exception("Conexiunea este deja închisă.");
            }
        }
        #endregion
    }
}