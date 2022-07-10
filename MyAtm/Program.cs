using System;
using System.Text;

namespace MyAtm
{

    public class cardHolder
    {
        String cardNum;
        int pin;
        String firtName;
        String lastName;
        double balance;

        public cardHolder(string cardNum, int pin, string firtName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firtName = firtName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public String getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public String getFirtName()
        {
            return firtName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public double getBalence()
        {
            return balance;
        }

        public void setNum(String newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(String newFirstName)
        {
            firtName = newFirstName;
        }
        public void sesetLastName(String newLastName)
        {
            lastName = newLastName;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(String[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("What the amount you would like to deposit:  ");
                double enteredAmount = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalence() + enteredAmount);
                Console.WriteLine("A deposit of $" + enteredAmount + " has been made. Your new balance is: ");
                Console.WriteLine(currentUser.getBalence());

            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("What the amount you would like to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());
                if (currentUser.getBalence() < withdrawal)
                {
                    Console.WriteLine("Insufficient balance...");
                }
                else
                {

                    currentUser.setBalance(currentUser.getBalence() - withdrawal);
                    Console.WriteLine("All set, your new balance is: ");
                    Console.WriteLine(currentUser.getBalence());
                }

            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance is: ");
                Console.WriteLine(currentUser.getBalence());
            }
            string RequestPin()
            {
                StringBuilder sb = new StringBuilder();
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    if (!char.IsControl(keyInfo.KeyChar)) 
                    {
                        sb.Append(keyInfo.KeyChar);
                        Console.WriteLine("*");
                    }
                } while (keyInfo.Key != ConsoleKey.Enter);
                {
                    return sb.ToString();
                }

            }

            List<cardHolder> cardsHolders = new List<cardHolder>();
            cardsHolders.Add(new cardHolder("4444333322221111", 1234, "John", "Griffith", 150.31));
            cardsHolders.Add(new cardHolder("4444454113300911", 1234, "Beth", "Brown", 2000));
            cardsHolders.Add(new cardHolder("4444329178394501", 1234, "Mark", "Tomphson", 15.01));
            cardsHolders.Add(new cardHolder("4444331111234413", 1234, "John", "John", 850));

            // Prompt user
            Console.WriteLine("Welcome to BesTM");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // Check agaisnt data
                    currentUser = cardsHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again"); };

                }
                catch { Console.WriteLine("Card not recognized. Please try again"); }


            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = int.Parse(RequestPin());
                    // Check agaisnt data

                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin, try again"); };

                }
                catch { Console.WriteLine("Incorrect pin, try again"); }


            }

            Console.WriteLine(" Welcome " + currentUser.getFirtName());
            int option = 0;

            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            } while (option != 4);
            Console.WriteLine("Thank you for useing BesTM");
        }


    }

    

}