using DapperORMProject;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Dapper_Project
{
    class program
    {
        static void Main()
        {
            PrintHeader();
            PrintOptions();

            int NumberOfOption = ReadNumber();

            switch(NumberOfOption)
            {
                case 1: GetAllUsers(); break;
                case 2: AddNewUser(); break;
                case 3: UpdateUser(); break;
                case 4: DeleteUser(); break;
            }

            Console.ReadKey();
        }

        public static void PrintHeader()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("       Users Management       ");
            Console.WriteLine("==============================");
        }
        public static void PrintOptions()
        {
            Console.WriteLine("   [1] Show All Users.");
            Console.WriteLine("   [2] Add New User.");
            Console.WriteLine("   [3] Update User.");
            Console.WriteLine("   [4] Delete User.");

        }

        public static int ReadNumber(int NumberOfTries = 0)
        {
            if (NumberOfTries >= 5)
            {
                Console.Write($"You tried {NumberOfTries} times , try again later.");
                Environment.Exit(1);
            }

            Console.WriteLine("\n" + "Please select an option : ");

            if (int.TryParse(Console.ReadLine(), out int Number))
                return Number;
            else           
                return ReadNumber(NumberOfTries + 1);
            
        }

        public static void GetAllUsers()
        {
            Console.Clear();

            var AllUsers = User_DAL.GetAllUsers();

            Console.WriteLine("#**** All Users ****#");


            if (AllUsers == Enumerable.Empty<User>()) 
                Console.WriteLine("No users in the system.");

            else
            {
                foreach (var u in AllUsers)
                {
                    Console.WriteLine(u);
                }
            }
        }

        public static void AddNewUser()
        {
            Console.Clear();

            Console.WriteLine("#** Add new user **#");
                        
            Console.Write("Please enter the Name : ");
            string Name = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the Email : ");
            string Email = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the Password : ");
            string Password = Convert.ToString(Console.ReadLine());

            User user = new User(-1 , Name, Email, Password);

            int NewID = User_DAL.InsertNewUser(user);

            if (NewID > 0) { Console.WriteLine("Add new user done successfully."); }
            else Console.WriteLine("Error in add new user.");
        }

        public static void UpdateUser()
        {
            Console.Clear();

            Console.WriteLine("#** Update user **#");

            Console.Write("Please enter the Id : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the Name : ");
            string Name = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the Email : ");
            string Email = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the Password : ");
            string Password = Convert.ToString(Console.ReadLine());

            User user = new User(Id, Name, Email, Password);

            if (User_DAL.UpdateUser(user))
                Console.WriteLine("Update user done successfully.");
            else
                Console.WriteLine("Error in update user.");

        }

        public static void DeleteUser()
        {
            Console.Clear();

            Console.WriteLine("#** Delete User **#");

            Console.Write("Please enter the ID : ");
            int ID = Convert.ToInt32(Console.ReadLine());

            if (User_DAL.DeleteUser(ID))
                Console.WriteLine("Delete user done successfully.");
            else
                Console.WriteLine("Error in delete user");

        }
    }
}