/**************************************************************************
 *                                                                        *
 *  File:        AplicatieBancara.cs                                     *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Clasă statică ce gestionează starea generală a aplicației,
 *               inclusiv utilizatorul curent și schimbarea formularelor.*
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using BankApp.Data;
using System;
using System.Windows.Forms;

namespace BankApp
{

    /// <summary>
    /// Clasă statică ce gestionează starea aplicației și form-urile active.
    /// </summary>
    public static class AplicatieBancara
    {

        /// <summary>
        /// Utilizatorul autentificat curent.
        /// </summary>
        public static User currentUser;


        /// <summary>
        /// Referință la formularul principal ce conține toate controalele.
        /// </summary>
        private static Form _currentForm;


        /// <summary>
        /// Returnează formularul de start al aplicației (Login).
        /// </summary>
        /// <returns>LoginForm inițializat.</returns>
        public static Form GetCurrentForm()
        {
            _currentForm = new LoginForm();
            return _currentForm;
        }


        /// <summary>
        /// Șterge toate controalele de pe formularul principal.
        /// </summary>
        private static void DeleteAllControls()
        {
            while (_currentForm.Controls.Count > 0)
            {
                _currentForm.Controls[0].Dispose();
            }
        }

        /// <summary>
        /// Mută toate controalele dintr-un formular nou în formularul curent.
        /// </summary>
        /// <param name="sourceForm">Formularul sursă ale cărui controale trebuie transferate.</param>
        private static void AddAllControls(Form sourceForm)
        {
            while (sourceForm.Controls.Count != 0)
            {
                Control c = sourceForm.Controls[0];
                sourceForm.Controls.Remove(c);
                _currentForm.Controls.Add(c);
            }
        }

        /// <summary>
        /// Înlocuiește interfața cu un nou formular, în aceeași fereastră.
        /// </summary>
        /// <param name="form">Formularul ce trebuie afișat.</param>
        public static void SetNewForm(Form form)
        {
            DeleteAllControls();
            AddAllControls(form);
            form.Dispose();
        }

        /// <summary>
        /// Deschide fișierul .chm de help al aplicației.
        /// </summary>
        public static void DeschideHelp(Form owner)
        {
            string path = System.IO.Path.Combine(
                Environment.CurrentDirectory,
                "Help Aplicatie Bancara.chm"
            );

            if (System.IO.File.Exists(path))
            {
                Help.ShowHelp(owner, path);
            }
            else
            {
                MessageBox.Show("Fișierul de help nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
