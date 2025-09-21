/*
 * BankAccount class UML
 * ----------------------------------------------------------------
 * - firstId : int
 * + AccountId : int
 * + CustomerName : string
 * + Balance: decimal
 * + Transactions : List<string>
 * ----------------------------------------------------------------
 * + BankAccount(customerName : string, initialBalance : decimal)
 * + Deposit(amount : decimal) : void
 * + Withdraw(amount : decimal) : void
 * ----------------------------------------------------------------
 * */

using System;
using System.Collections.Generic;

public class BankAccount
{
    private static int firstId = 1;

    public int AccountId { get; private set; }
    public string CustomerName { get; private set; }
    public decimal Balance { get; private set; }
    public List<string> Transactions { get; private set; } = new List<string>();

    public BankAccount(string customerName, decimal initialBalance)
    {
        AccountId = firstId++;
        CustomerName = customerName;
        Balance = initialBalance;

        Transactions.Add($"Account created for {customerName} with initial balance of: {initialBalance}$");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Transactions.Add("[FAILED]: Deposit amount must be greater than 0$");
            return;
        }

        Balance += amount;
        Transactions.Add($"[APPROVED]: A balance of {amount}$ was added to your account, your updated balance is: {Balance}$");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Transactions.Add("[FAILED]: Withdrawal amount must be greater than 0$");
            return;
        }

        if (amount > Balance)
        {
            Transactions.Add($"[FAILED]: Amount requested of {amount}$ is greater than total balance, your balance is: {Balance}$");
            return;
        }

        Balance -= amount;
        Transactions.Add($"[APPROVED]: Withdrawal of {amount}$ approved, your updated balance is: {Balance}$");
    }
}

class Program
{
    static void Main(string[] main)
    {
        BankAccount account1 = new BankAccount("Bar Yaakov", 100m);

        account1.Deposit(100m);
        account1.Withdraw(200m);

        account1.Deposit(0m);
        account1.Deposit(-5m);
        account1.Withdraw(0m);
        account1.Withdraw(-5m);
        account1.Withdraw(500m);

        Console.WriteLine($"AccountId: {account1.AccountId}");
        Console.WriteLine($"Customer : {account1.CustomerName}");
        Console.WriteLine($"Balance  : {account1.Balance}");

        Console.WriteLine("\nTransactions:");

        foreach (var line in account1.Transactions)
            Console.WriteLine(line);

        Console.WriteLine();

        BankAccount account2 = new BankAccount("Random Name", 0m);

        account2.Withdraw(1m);

        account2.Deposit(25.50m);
        account2.Withdraw(25.50m);

        Console.WriteLine($"AccountId: {account2.AccountId}");
        Console.WriteLine($"Customer : {account2.CustomerName}");
        Console.WriteLine($"Balance  : {account2.Balance}");

        Console.WriteLine("\nTransactions:");

        foreach (var line in account2.Transactions)
            Console.WriteLine(line);
    }
}