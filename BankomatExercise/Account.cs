using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExercise
{
    public class Account
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public double Balance { get; private set; }


        

        

        public Account(string username, string password, double initialBalance) // ctor
        {
            Username = username;
            Password = password;
            Balance = initialBalance;
            
        }

        public bool Withdraw(double amount) // metodo per il prelievo
        {
            if (amount <= 0 || amount > Balance) 
            {
                
                return false;
                
            }

            Balance -= amount; 
            return true;
        }

        public bool Deposit(double amount)// metodo per versamento
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }  
}
