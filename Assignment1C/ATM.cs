using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.InteropServices;
/*
* To change this license header, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
namespace  project1
{
  
    public class ATM
    {
        static ATM atm = new ATM();
        bool alreadyExecuted;
        Account[] accounts = new Account[3];

		public static void Main(string[] args)
		{
            atm.menu();
		}

        public void menu()
		{
			int input;
			do
			{
				Console.WriteLine("1. Populate Accounts");
				Console.WriteLine("2. Select Accounts");
                Console.WriteLine("3. Save Accounts");
				Console.WriteLine("4. Load Accounts");
                Console.WriteLine("5. Exit");
				input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    if (!alreadyExecuted)
                    {
                        atm.populate();
                        alreadyExecuted = true;
                    }
                    else
                    {
                        Console.WriteLine("\nAccounts already populated!");
                    }
                }
                else if (input == 2)
                {
                    if (alreadyExecuted)
                    {
                        atm.select();
                    }
                    else
                    {
                        Console.WriteLine("Populate accounts first.");
                    }
                }
                else if (input == 3)
                {
                    
                    try
                    {
                        if (alreadyExecuted)
                        {
                            XmlSerializer serializer = new XmlSerializer(accounts.GetType());
                            //FileStream stream = new FileStream("bank.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            StreamWriter writer = new StreamWriter("bank.xml");
                            serializer.Serialize(writer, accounts);
                            writer.Close();
                            alreadyExecuted = true;
                        }
                        else
                        {
                            Console.WriteLine("There are no accounts to save!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException);
                    }
                }
                else if (input == 4)
                {
                    try
                    {
                        XmlSerializer deserializer = new XmlSerializer(accounts.GetType());
                        //FileStream rereader = new FileStream("bank.xml", FileMode.Open, FileAccess.ReadWrite);
                        StreamReader sr = new StreamReader("bank.xml");
                        accounts = (Account[])deserializer.Deserialize(sr);
                        sr.Close();
                        alreadyExecuted = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }                     
                }
                else if (input == 5)
                {
                Environment.Exit(0);
                }
				else if (input > 5 || input < 1)
				{
				Console.WriteLine("\nPlease enter a valid number.\n");
				}
			} while (input != 5);
		}

        public void populate()
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account();
            }
        }

        public void select()
        {
            int input;
            do
            {
                Console.WriteLine("Enter account number: ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input >= 4 || input <= 0)
                {
                    Console.WriteLine("Please enter numbers 1 2 or 3");
                }

            }
            while (!((input - 1) >= 0) || !((input - 1) < accounts.Length));
                {
                try
                {
                    accounts[input - 1].menu();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
		}
    }

}