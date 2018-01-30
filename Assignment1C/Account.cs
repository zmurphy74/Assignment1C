using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;


namespace project1
{

[Serializable()]

	public class Account
	{
        public double balance;
		double amount;
		public int firstdate;
		public int seconddate;
		public DateTime cal1 = new DateTime();
		public DateTime cal2 = new DateTime();
		public bool dateflag = false;
		double rate;


        public Account()
        {
            balance = 100;
        }


        public void menu()
		{
			int input;
			do
			{
			Console.WriteLine("Enter 1 to deposit.");
			Console.WriteLine("Enter 2 to Withdraw.");
			Console.WriteLine("Enter 3 to Check Balance.");
			Console.WriteLine("Enter 4 to exit.");
			input = 0;
			input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
				        if (dateflag == true)
				        {
						    getDate2();
						    getInterest();
						    deposit();
				        }
				        else
				        {
						    getDate1();
						    deposit();
				        }
						break;
					case 2:
				        if (dateflag == true)
				        {
						    getDate2();
						    getInterest();
						    withdraw();
				        }
				        else
				        {
						    getDate1();
						    withdraw();
				        }
						break;
					case 3:
						if (dateflag == true)
						{
						    getDate2();
						    getInterest();
						    display();
						}
				        else
				        {
						getDate1();
						display();
				        }
						break;
					default:
						break;
				}
			}
            while (!(input >= 4 || input <= 0));
		}
		public void getDate1()
		{
            Console.Write("Enter todays date(mm/dd/yyyy): ");
		    string inputText = Convert.ToString(Console.ReadLine());
            string pattern = "MM/dd/yy";
            DateTime parsedDate;
            DateTime.TryParseExact(inputText, pattern, null,
            DateTimeStyles.None, out parsedDate);
            DateTime date = DateTime.Parse(inputText);
		    cal1 = date;
            firstdate = cal1.DayOfYear;
            dateflag = true;
		}
	    public void getDate2()
	    {
	        Console.Write("Enter todays date(mm/dd/yyyy): ");
			string inputText = Convert.ToString(Console.ReadLine());
			DateTime date = DateTime.Parse(inputText);
            date.ToString("d");
			cal2 = date;
			seconddate = cal2.DayOfYear;

				if (firstdate > seconddate)
					{
						Console.WriteLine("You must enter a future date.");
						getDate2();
					}
	    }

		public void getInterest()
		{
			int datediff = seconddate - firstdate;
			rate = .10 / 365;
			double ratetime = Math.Pow(1 + rate,datediff);
			balance = balance * ratetime;
			firstdate = seconddate;
		}
		public int deposit()
		{
			Console.Write("Enter amount to deposit:");
		    amount = Convert.ToDouble(Console.ReadLine());
				if (amount < 0)
				{
				    Console.WriteLine("Invalid Amount");
				    return 1;
				}
				balance = balance + amount;
				return 0;
		}

		public int withdraw()
		{
            string balance1 = String.Format("Balance: {0:C}", balance);
            Console.WriteLine(balance1);
			Console.Write("Enter amount to withdraw:");
		    amount = Convert.ToDouble(Console.ReadLine());
				if (balance < amount)
				{
				Console.WriteLine("Not sufficient balance.");
				return 1;
				}
				    if (amount < 0)
				    {
				    Console.WriteLine("Invalid Amount");
				    return 1;
				    }
				    balance = balance - amount;
				    return 0;
		}
		public void display()
		{
            string balance1 = String.Format("Balance: {0:C}", balance);
		    Console.WriteLine(balance1);

		}

	}

}