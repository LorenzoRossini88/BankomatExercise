using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExercise
{
    public class UserInterface
    {
        public static void UsingUserInterface()
        {
            DateTime thisDay = DateTime.Now;

            int maxLoginAttempts = 3; // Numero massimo di tentativi di accesso consentiti
            int loginAttempts = 0; // numero di tentativi eseguiti all'inizio del programma



            // Creazione di tre account correnti con saldo iniziale di 1000 euro
            Account account1 = new Account("lollo", "1234", 1000.00);
            Account account2 = new Account("dani", "567", 1000.00);
            Account account3 = new Account("utente", "890", 1000.00);

            // Creazione di un oggetto Bank che gestisce gli account
            Bank bank = new Bank();
            bank.AddAccount(account1);
            bank.AddAccount(account2);
            bank.AddAccount(account3);

            while (true)
            {

                if (loginAttempts >= maxLoginAttempts)
                {
                    Console.WriteLine("Hai superato il numero massimo di tentativi di accesso. Il programma verrà chiuso.");
                    break;
                }

                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("      Benvenuto al Bancomat!");// menu con inserimento usurname e password
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Numero Tentativi Rimasti: {maxLoginAttempts}");
                Console.WriteLine("-----------------------------------");
                Console.Write("Inserisci il tuo username: ");
                string username = Console.ReadLine();
                Console.Write("Inserisci la tua password: ");
                string password = Console.ReadLine();

                // Verifica le credenziali e se l'account esiste davvero
                Account currentAccount = bank.ValidateAccount(username, password);

                if (currentAccount == null)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Credenziali errate!");
                    Console.ResetColor();
                    maxLoginAttempts--;
                }
                else
                {

                    maxLoginAttempts = 3;

                    while (true)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Benvenuto, {currentAccount.Username}!");// menu all'interno dell'account
                        Console.ResetColor();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine($"Saldo disponibile: {currentAccount.Balance} euro");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("1. Prelievo");
                        Console.WriteLine("2. Versamento");
                        Console.WriteLine("3. Scontrino Saldo");
                        Console.WriteLine("4. Esci");

                        int choice;
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)// switch per la scelta tra prelievo, versamento, saldo, uscita
                            {
                                case 1:// prelievo
                                    Console.Write("Inserisci l'importo da prelevare: ");
                                    double withdrawalAmount;
                                    if (double.TryParse(Console.ReadLine(), out withdrawalAmount))
                                    {
                                        if (currentAccount.Withdraw(withdrawalAmount))
                                        {
                                            Console.WriteLine($"Hai prelevato {withdrawalAmount} euro.");
                                        }
                                        else
                                        {

                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Saldo insufficiente o cifra non valida.");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Importo non valido.");
                                        Console.ResetColor();
                                    }
                                    break;

                                case 2:// versamento
                                    Console.Write("Inserisci l'importo da versare: ");
                                    double depositAmount;
                                    if (double.TryParse(Console.ReadLine(), out depositAmount))
                                    {

                                        if (currentAccount.Deposit(depositAmount))
                                        {
                                            
                                            Console.WriteLine($"Hai versato {depositAmount} euro.");
                                        }
                                        else
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Cifra non valida");
                                            Console.ResetColor();
                                        }


                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Importo non valido.");
                                        Console.ResetColor();
                                    }
                                    break;

                                case 3:// scontrino saldo
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine($"Conto corrente di  {currentAccount.Username} ");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine($"Operazione avvenute in data {thisDay}");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine($"Saldo disponibile: {currentAccount.Balance} euro");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine("");

                                    break;

                                case 4:// Uscita dall'account corrente
                                    currentAccount = null;
                                    break;

                                default:
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Scelta non valida. Riprova.");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Scelta non valida. Riprova.");
                            Console.ResetColor();
                        }

                        if (currentAccount == null)
                        {
                            break;
                        }

                        Console.WriteLine("Premi un tasto per continuare...");// ritorno al menu principale
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
