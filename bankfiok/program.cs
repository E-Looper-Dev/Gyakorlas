using System;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        bool running = true;
 
        while (running)
        {
            Console.WriteLine("Válassz egy lehetőséget:");
            Console.WriteLine("1. Befizetés");
            Console.WriteLine("2. Kifizetés");
            Console.WriteLine("3. Egyenleg megtekintése");
            Console.WriteLine("4. Tranzakciók megtekintése");
            Console.WriteLine("5. Kilépés");
 
            string choice = Console.ReadLine();
 
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Írd be a befizetni kívánt összeget:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Érvénytelen összeg.");
                    }
                    break;
 
                case "2":
                    Console.WriteLine("Írd be a kifizetni kívánt összeget:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        account.Withdraw(withdrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("Érvénytelen összeg.");
                    }
                    break;
 
                case "3":
                    Console.WriteLine($"Aktuális egyenleg: {account.Balance} Ft");
                    break;
 
                case "4":
                    account.DisplayTransactions();
                    break;
 
                case "5":
                    running = false;
                    break;
 
                default:
                    Console.WriteLine("Érvénytelen választás. Próbáld újra.");
                    break;
            }
 
            Console.WriteLine();
        }
    }
}
 
class BankAccount
{
    private const decimal TransactionFee = 159m;
    private decimal balance;
    private List<string> transactions;
 
    public decimal Balance { get { return balance; } }
 
    public BankAccount()
    {
        balance = 0m;
        transactions = new List<string>();
    }
 
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            transactions.Add($"Befizetés: {amount} Ft, Egyenleg: {balance} Ft");
            Console.WriteLine($"Sikeres befizetés: {amount} Ft.");
        }
        else
        {
            Console.WriteLine("A befizetett összegnek pozitívnak kell lennie.");
        }
    }
 
    public void Withdraw(decimal amount)
    {
        if (amount > 0)
        {
            decimal totalWithdrawal = amount + TransactionFee;
            if (balance >= totalWithdrawal)
            {
                balance -= totalWithdrawal;
                transactions.Add($"Kifizetés: {amount} Ft, Tranzakciós díj: {TransactionFee} Ft, Egyenleg: {balance} Ft");
                Console.WriteLine($"Sikeres kifizetés: {amount} Ft. Tranzakciós díj: {TransactionFee} Ft.");
            }
            else
            {
                Console.WriteLine("Nincs elegendő egyenleg a tranzakció végrehajtásához.");
            }
        }
        else
        {
            Console.WriteLine("A kifizetett összegnek pozitívnak kell lennie.");
        }
    }
 
    public void DisplayTransactions()
    {
        if (transactions.Count > 0)
        {
            Console.WriteLine("Tranzakciók:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
        else
        {
            Console.WriteLine("Nincsenek tranzakciók.");
        }
    }
}
