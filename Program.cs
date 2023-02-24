using System;

namespace ProstyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }
        }

        static public void playWithAccount()
        {
            // Wywoływanie wszystkich operacji na koncie
            var account = new BankAccount("<name>", 1000);
            account.MakeWithdraw(200, DateTime.Now, "Na burgery");
            account.MakeDeposit(300, DateTime.Now, "zwrot podatku 2022");
            account.PobranieKredytu(900, DateTime.Now, "Kredyt na paliwo");
            account.SplataKredytu(500, DateTime.Now, "500+");
            account.ListTransactionHistory(0, DateTime.Now, "Lista transakcji");
            account.DisplayInfo();
            Console.ReadKey();
          
        }

    }
}
