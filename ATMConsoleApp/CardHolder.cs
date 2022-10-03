using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMConsoleApp
{
  
    public class CardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;

        public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin; 
            this.firstName = firstName; 
            this.lastName = lastName;   
            this.balance = balance;
        }

        //getter
        public string getCardNum()
        {
            return cardNum;
        }

        //setter
        public void setCardNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public string getFirstName() { return firstName; }
        public void setFirstName(string newFirstName) { firstName = newFirstName; }

        public string getLastName() { return lastName; }
        public void setLastName(string newLastName) { lastName = newLastName; }

        //getter for balance
        public double getBalance() { return balance; }
        //setter for balance
        public void setBalance(double newBalance) { balance = newBalance; }

        //Main Method
        static void Main(string[] args)
        {
            void showOptions()
            {
                Console.WriteLine("********************************************************");
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("********************************************************");
            }

            void deposit(CardHolder currentUser)
            {
                Console.WriteLine("********************************************************");
                Console.WriteLine("How much Money would you like to deposit?");
                double deposit = Double.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Thank for Deposit. Your new balance is : " + currentUser.getBalance());
                Console.WriteLine("------------------------------------------------------");
            }

            void withdraw(CardHolder currentUser)
            {
                Console.WriteLine("********************************************************");
                Console.WriteLine("How much Money would you like to withdraw?");
                double withdrawal = Double.Parse(Console.ReadLine());
                // Check if current user has enough money
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.Write("Insufficient balance :(");
                    Console.WriteLine("-----------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------");
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("Thank you :) Please Visit again!");
                    Console.WriteLine("-----------------------------------------------------");

                }


            }

            void balance(CardHolder currentUser)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Current Balance: " + currentUser.getBalance());
                Console.WriteLine("-----------------------------------------------------");
            }

            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("45327722818527395", 1234, "Amol", "Gahane", 231.34));
            cardHolders.Add(new CardHolder("53429864332722809", 6438, "Aman", "Smith", 437.89));
            cardHolders.Add(new CardHolder("98473297983742823", 9738, "Harshal", "Jones", 389.54));
            cardHolders.Add(new CardHolder("75584372432279848", 3893, "Emmi", "Jackson", 327.78));
            cardHolders.Add(new CardHolder("57948718y37478022", 8390, "Jack", "Jackson", 843.99));

            // prompt user
            Console.WriteLine("********************************************************");
            Console.WriteLine("Welcome to Console ATM");
            Console.WriteLine("********************************************************");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Please insert your debit card:");
            string debitCardNum = "";
            CardHolder currentUser;
          
            while (true)
            {
                try
                {

                    debitCardNum = Console.ReadLine();
                    //Check against our DB
                    currentUser = cardHolders.FirstOrDefault(x => x.cardNum == debitCardNum);

                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("Card not recognized. Please try again");
                        Console.WriteLine("-----------------------------------------------------");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Card not recognized. Please try again " + e.Message);
                    Console.WriteLine("-----------------------------------------------------");

                }
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Please enter your pin");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else 
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("Incorrect Pin!");
                        Console.WriteLine("-----------------------------------------------------");
                    }

                }
                catch 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Incorrect Pin! try again..");
                    Console.WriteLine("-----------------------------------------------------");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                showOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("********************************************************");
            Console.WriteLine("Thank you! Have a nice day :)");
            Console.WriteLine("********************************************************");
        }

    }
}
