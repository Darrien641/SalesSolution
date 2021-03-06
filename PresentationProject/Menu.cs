using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationProject
{
    class Menu
    {
        public static List<string> MenuOptions = new List<string>();
        public static List<string> GetMenu()
        {
            MenuOptions.Add("CRUD with EF: Select an option from the menu (1-6):");
            MenuOptions.Add("1. Add New Customer");
            MenuOptions.Add("2. Search For Customer");
            MenuOptions.Add("3. Update Existing Customer");
            MenuOptions.Add("4. Delete Customer");
            MenuOptions.Add("5. Filter Customers");
            MenuOptions.Add("6. Show all Customers ");
            MenuOptions.Add("7. Quit Application");

            return MenuOptions;
        }
        public static void OptionSelector(int choice)
        {
            if (choice == 1)
            {
                Add();
            }
            else if (choice == 2)
            {
                Find();
            }
            else if (choice == 3)
            {
                Update();
            }
            else if (choice == 4)
            {
                Delete();
            }
            else if (choice == 5)
            {
                Filter();
            }
            else if (choice == 6)
            {
                ShowAllCustomers();
            }
        }
        public static void Add()
        {
            string firstName, lastName, city, country , phone;
            //string ? NullInput = null;
            Console.WriteLine("Input New Customer Info:");
            Console.WriteLine("First Name:");
            firstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            lastName = Console.ReadLine();
            Console.WriteLine("City");
            city = Console.ReadLine();
            Console.WriteLine("Country");
            country = Console.ReadLine();
            Console.WriteLine("Phone");
            phone = Console.ReadLine();
            

            CustCRUD.AddCust(firstName, lastName, city, country, phone);
            ShowAllCustomers();
           
        }
        public static void Update()
        {
            Console.WriteLine("Enter The last name of the customer to update");
            string lastName = Console.ReadLine();
            CustCRUD.UpdateCust(lastName);
            Console.WriteLine($"Customer With Last Name {lastName} updated");
            ShowAllCustomers();
        }
        public static void Delete()
        {
            Console.WriteLine("Enter the last name of the Customer you want to delete");
            string LastName = Console.ReadLine();
            CustCRUD.DelCust(LastName);
            Console.WriteLine($"Customer With Last Name {LastName} removed from records");
            ShowAllCustomers();
        }
        public static void Find()
        {
            Console.WriteLine("Enter the last name of the customer you want to find");
            string lastName = Console.ReadLine();
            foreach (string cust in CustCRUD.FindCust(lastName))
            {
                Console.WriteLine(cust);
            }
        }
        public static void Filter()
        {
            Console.WriteLine("Please Enter Type of filter (C)ity, (L)astName, or Starting (CH)arcter of LastName \nOr leave blank to Find by lastName");
            string Type = Console.ReadLine();
            Console.WriteLine("Enter the filter parameter");
            string Filter = Console.ReadLine();
            foreach (var cust in CustCRUD.FilterCust(Type, Filter))
            {
                Console.WriteLine(cust);
            }
        }
        public static void ShowAllCustomers()
        {
            foreach (var c in CustCRUD.GetAllCustomers())
            {
                Console.WriteLine(c.ToString());
            }
        }

    }
}
