using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class BankAccount
    {
        private List<Transaction> AllTransactions = new List<Transaction>();
        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; }
        private decimal balance;
        private Loan loan;

        
        public decimal Balance
        {
            get
            {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"Utworzono nowe konto {accountNumberSeed} z saldem: {initialBalance}");
        }


        public void SplataKredytu(decimal amount, DateTime date, string note)
        {

            if (amount <= 0 || amount > loan.Kredens)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Błędna kwota!");
            }
            MakeWithdraw(amount, date, note);
            loan.Kredens = loan.Kredens - amount;
        }

        public void PobranieKredytu(decimal amount, DateTime date, string note)
        {

            if (amount <= 0 || amount > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Błędna kwota!");
            }

            this.loan = new Loan(amount);
            MakeDeposit(amount, date, note);

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wpłaty o kwocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }

            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);
        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wyplaty o kwocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wyplacic kwoty ujemnej");
            }

            Transaction withdrawal = new Transaction(-amount, date, note);
            AllTransactions.Add(withdrawal);
        }

        public void ListTransactionHistory(decimal amount, DateTime date, string note)
        {

            Console.WriteLine("Historia :");
            foreach (Transaction Konto in AllTransactions)
            {
                balance += Konto.Amount;
                Console.WriteLine($"Kwota:  {+Konto.Amount} \t Data: {Konto.Date} \t Notka: { Konto.Note} \t\t Stan konta: {balance}");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\nStan konta : {Balance}");
        }

    }
}
