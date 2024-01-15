public class CardHolder
{

    public string CardNum { get; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }


    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {

        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;

    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {

            Console.Write("How much $$ would you like to deposit? ");
            string userInput = Console.ReadLine();
            if (Double.TryParse(userInput, out double deposit))
            {

                currentUser.Balance += deposit;
                Console.WriteLine($"Thank you for your $$. Your new balance is {currentUser.Balance} $");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        }

        void widtdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());

            if (currentUser.Balance < withdraw)
            {
                Console.WriteLine("Insufficient balance.");

            }
            else
            {
                currentUser.Balance -= withdraw;
                Console.WriteLine("You are good to good! Thank you.");

            }

        }

        void balance(CardHolder currentUser)
        {

            Console.WriteLine($"Current balance: {currentUser.Balance} $");

        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("111111", 1234, "John", "Doe", 150.45));
        cardHolders.Add(new CardHolder("222222", 2323, "Mike", "Zaza", 200.55));
        cardHolders.Add(new CardHolder("333333", 3333, "Ivan", "Tall", 150.45));
        cardHolders.Add(new CardHolder("444444", 1234, "Jane", "Berg", 150.45));
        cardHolders.Add(new CardHolder("555555", 7777, "Ann", "Doe", 150.45));



        Console.WriteLine("Welcome to  SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser;



        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.Find(user => user.CardNum == debitCardNum);
                if (currentUser != null) { break; } else { Console.WriteLine("invalid Card Number. Please try again."); }
            }
            catch
            {
                Console.WriteLine("Invalid Card Number. Please try again.");
            }

        }



        Console.WriteLine("PLease enter your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.Pin == userPin) { break; }
                else
                {
                    Console.WriteLine("Invalid Pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid Pin. Please try again.");
            }
        }



        Console.WriteLine($"Welcome {currentUser.FirstName} !");
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid option");
            }

            switch (option)
            {
                case 1:
                    deposit(currentUser); break;
                case 2: widtdraw(currentUser); break;
                case 3: balance(currentUser); break;
                case 4: break;
                default:
                    option = 0; break;
            }

        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day!");


    }


}




