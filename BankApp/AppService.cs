/**************************************************************************
 *                                                                        *
 *  File:        AppService.cs                                           *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Clasa principală de servicii business pentru aplicație. *
 *               Conține logica pentru autentificare, parole și tranzacții.
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
using BankApp.Data.Data;
using BankApp.Exceptions;
using BankApp.Validation;
using System;
using System.Linq;

namespace BankApp
{
    /// <summary>
    /// Clasa de servicii care conține logica principală de business a aplicației bancare.
    /// </summary>
    public class AppService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Inițializează serviciul cu contextul bazei de date.
        /// </summary>
        /// <param name="context">Contextul EF Core folosit pentru accesul la date.</param>
        public AppService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Autentifică un utilizator pe baza numelui de utilizator și parolei.
        /// </summary>
        /// <param name="username">Numele de utilizator.</param>
        /// <param name="password">Parola introdusă.</param>
        /// <returns>Obiectul utilizator autentificat.</returns>
        /// <exception cref="PasswordValidationException">Dacă parola nu este validă.</exception>
        /// <exception cref="UserNotFoundException">Dacă utilizatorul nu este găsit.</exception>
        public User Login(string username, string password)
        {
            var validator = new SimplePasswordValidation();
            if (!validator.IsValid(password))
                throw new PasswordValidationException("Parola introdusă este prea scurtă (minim 3 caractere).");

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
                throw new UserNotFoundException("Utilizatorul sau parola nu sunt corecte.");

            return user;
        }

        /// <summary>
        /// Schimbă parola utilizatorului curent, după validări.
        /// </summary>
        /// <param name="userId">ID-ul utilizatorului.</param>
        /// <param name="currentPassword">Parola curentă.</param>
        /// <param name="newPassword">Noua parolă.</param>
        /// <param name="confirmPassword">Confirmarea noii parole.</param>
        /// <exception cref="FormValidationException">Dacă datele introduse sunt incorecte.</exception>
        /// <exception cref="UserNotFoundException">Dacă utilizatorul nu este găsit.</exception>
        /// <exception cref="PasswordValidationException">Dacă noua parolă nu respectă regulile.</exception>
        public void ChangePassword(int userId, string currentPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
                throw new FormValidationException("Completează toate câmpurile.");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId)
                ?? throw new UserNotFoundException("Utilizatorul nu a fost găsit.");

            if (user.Password != currentPassword)
                throw new FormValidationException("Parola actuală este incorectă.");

            if (newPassword != confirmPassword)
                throw new FormValidationException("Parolele nu coincid.");

            var validator = new PasswordValidator(new StrongPasswordValidation());
            validator.Validate(newPassword);

            user.Password = newPassword;
            _context.SaveChanges();
        }

        /// <summary>
        /// Efectuează o tranzacție bancară între doi utilizatori.
        /// </summary>
        /// <param name="senderId">ID-ul expeditorului (utilizator curent).</param>
        /// <param name="destinationIban">IBAN-ul destinatarului.</param>
        /// <param name="amount">Suma de transferat.</param>
        /// <exception cref="TransactionValidationException">Dacă datele sunt invalide sau utilizatorii nu sunt găsiți.</exception>
        /// <exception cref="InsufficientFundsException">Dacă expeditorul nu are suficiente fonduri.</exception>
        public void ExecuteTransaction(int senderId, string destinationIban, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(destinationIban) || amount <= 0)
                throw new TransactionValidationException("Completează corect IBAN-ul și suma.");

            var sender = _context.Users.FirstOrDefault(u => u.Id == senderId)
                ?? throw new TransactionValidationException("Expeditorul nu a fost găsit.");

            var recipient = _context.Users.FirstOrDefault(u => u.IBAN == destinationIban)
                ?? throw new TransactionValidationException("Destinatarul nu a fost găsit.");

            if (sender.Balance < amount)
                throw new InsufficientFundsException("Fonduri insuficiente.");

            sender.Balance -= amount;
            recipient.Balance += amount;

            _context.Transactions.Add(new Transaction
            {
                FromUser = sender.IBAN,
                ToUser = recipient.IBAN,
                Amount = amount,
                Timestamp = DateTime.Now
            });

            _context.SaveChanges();
        }

        /// <summary>
        /// Resetează parola unui utilizator, apelată de către administrator.
        /// </summary>
        /// <param name="username">Username-ul utilizatorului căruia i se va reseta parola.</param>
        /// <param name="newPassword">Noua parolă propusă.</param>
        /// <param name="confirmPassword">Confirmarea noii parole.</param>
        /// <exception cref="FormValidationException">
        /// Aruncată dacă unul dintre câmpuri este gol sau parolele nu coincid.
        /// </exception>
        /// <exception cref="PasswordValidationException">
        /// Aruncată dacă parola nu respectă regulile (ex: lungime, complexitate).
        /// </exception>
        /// <exception cref="UserNotFoundException">
        /// Aruncată dacă utilizatorul nu este găsit în baza de date.
        /// </exception>
        public void AdminResetPassword(string username, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
                throw new FormValidationException("Completează toate câmpurile.");

            if (newPassword != confirmPassword)
                throw new FormValidationException("Parolele nu coincid.");

            var validator = new PasswordValidator(new SimplePasswordValidation());
            validator.Validate(newPassword);

            var user = _context.Users.FirstOrDefault(u => u.Username == username)
                ?? throw new UserNotFoundException("Utilizatorul nu a fost găsit.");

            user.Password = newPassword;
            _context.SaveChanges();
        }


    }
}
