namespace Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.WriteLine("1-- Sign in            2-> Login in ");

            Console.Write("Enter the number : ");
            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    SignIn();
                    break;
                case 2:
                    LoginIn();
                    break;
                default:
                    {
                        Console.WriteLine("You have selected a partition that does not exist !!!");
                        Console.WriteLine("Please check and try again.");

                        Console.ReadKey();

                        Start();

                        Console.Clear();
                        break;
                    }
            }
        }

        public static void SignIn()
        {
            Console.Write("Enter your fulname :");
            string fullName = Console.ReadLine();

            Console.Write("Enter your phone number :");
            string phone = Console.ReadLine();

            Console.Write("Enter your Login name : ");
            string userName = Console.ReadLine();

            Console.Write("Enter your new pasword(At least 4 characters) : ");
            string password = Console.ReadLine();

            User user = new User();

            user.Fullname = fullName;
            user.Username = userName;
            user.Pasword = password;
            user.Phonenumber = phone;

            string path = Directory.GetCurrentDirectory() + $"\\{userName + password}.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("Kechirasiz bunday nomdagi foydalanuvchi mavjud.");
                foreach (var userlist in user.UserList)
                {
                    Console.WriteLine(userlist);
                    Console.WriteLine(userlist.Value.Read());
                }
            }

            using (StreamWriter writer = new StreamWriter($"{userName + password}.txt", true))
            {
                writer.WriteLine(user.Fullname + "," + user.Username + "," + user.Pasword + "," + user.Phonenumber);

            }

            StreamReader streamReader = new StreamReader($"{userName + password}.txt");

            user.UserList.Add(userName + password, streamReader);

            Console.WriteLine("Registration completed successfully.");
        }

        public static void LoginIn()
        {
            Console.Write("Enter your Login name : ");
            string userName = Console.ReadLine();

            Console.Write("Enter your pasword(At least 4 characters) : ");
            string password = Console.ReadLine();

            string path = Directory.GetCurrentDirectory() + $"\\{userName + password}.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("Hisobga muvaffaqiyatli kirildi.");
            }

            else
            {
                Console.WriteLine("Siz noto'g'ri parol yoki loginni kiritdingiz !");

                Console.WriteLine("1-> To'g'rilab boshqatdan kiritish." +
                    "2-> Sign in.");
                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1: LoginIn(); break;
                    case 2: SignIn(); break;
                    default:
                        {
                            Console.WriteLine("You have selected a partition that does not exist !!!");
                            Console.WriteLine("Please check and try again.");

                            Console.ReadKey();

                            Start();

                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}