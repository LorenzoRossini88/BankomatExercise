using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExercise
{
    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account ValidateAccount(string username, string password)
        {
            return accounts.Find(account => account.Username == username && account.Password == password);
        }
    }
}
