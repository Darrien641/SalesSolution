using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataProject;

namespace PresentationProject
{
    class CustCRUD
    {
        static SalesContext CustomerData = new SalesContext();
        static List<string> CustData = new List<string>();
        public static List<string> GetAllCustomers()
        {
            
            foreach (Customer c in CustomerData.Customers)
            {
                CustData.Add($"Last Name: {c.LastName} First Name: {c.FirstName} Phone: {c.Phone} City: {c.City} Country: {c.Country}");
            }
            return CustData;
        }

        public static void AddCust(string FirstName, string LastName, string city, string country, string phone)
        {
            Customer newCust = new Customer();
            newCust.FirstName = FirstName;
            newCust.LastName = LastName;
            newCust.City = city;
            newCust.Country = country;
            newCust.Phone = phone;
            CustomerData.Add(newCust);
            CustomerData.SaveChanges();

        }
        public static void DelCust(string lastName)
        {
            var CustData = CustomerData.Customers;
            List<Customer> LastMatches = CustData.Where(c => c.LastName.ToUpper() == lastName.ToUpper()).ToList();
            int HasLastName = LastMatches.Count();
            Customer Undesirable;
            if (HasLastName == 1)
            {
                Undesirable = CustData.Single(c => c.LastName.ToUpper() == lastName.ToUpper());
                Console.WriteLine($"Deleting Customer ({Undesirable.LastName}, {Undesirable.FirstName}) From Records");
                CustData.Remove(Undesirable);
            }
            else if (HasLastName > 1)
            {
                Console.WriteLine("There are Multiple Customers with that last name");
                Console.WriteLine("Enter the First Name of the Customer You would like to remove");
                foreach (Customer c in LastMatches)
                {
                    Console.WriteLine($"{c.LastName}, {c.FirstName}");
                }
                string FirstName = Console.ReadLine();
                Undesirable = (Customer)CustData.Where(c => c.LastName.ToUpper() == lastName.ToUpper() && c.FirstName.ToUpper() == FirstName.ToUpper());
                CustData.Remove(Undesirable);
            }
            else
            {
                Console.WriteLine("No Customer With that last Name was found");
            }
            CustomerData.SaveChanges();
        }

        public static void UpdateCust(string lastName)
        {
            var CustData = CustomerData.Customers;
            List<Customer> LastMatches = CustData.Where(c => c.LastName.ToUpper() == lastName.ToUpper()).ToList();
            int HasLastName = LastMatches.Count();
            Customer ToUpdate;
            if (HasLastName == 1)
            {
                ToUpdate = CustData.Single(c => c.LastName.ToUpper() == lastName);
                Console.WriteLine($"Update Customer: {ToUpdate.LastName}, {ToUpdate.FirstName}");
                Console.WriteLine($"What Would you like to update from {ToUpdate.LastName}, {ToUpdate.FirstName} [(F)irstName, (L)astName, (C)ity, (Co)untry, (P)hone]");
                string choice = Console.ReadLine();
                Updater(choice, lastName);

                bool cont = true;
                while (cont == true)
                {
                    Console.WriteLine("Perform More Updates? y/n");
                    string YNChoice = Console.ReadLine();


                    if (YNChoice.ToUpper() != "Y")
                    {
                        cont = false;
                        break;
                    }
                    else if (YNChoice.ToUpper() == "Y")
                    {
                        Console.WriteLine($"What Would you like to update from {ToUpdate.LastName}, {ToUpdate.FirstName} [(F)irstName, (L)astName, (C)ity, (Co)untry, (P)hone]");
                        choice = Console.ReadLine();
                        Updater(choice, lastName);
                    }
                }

            }
            else if (HasLastName > 1)
            {
                string fname;
                Console.WriteLine("More than One Customer with that name found!");
                foreach (Customer c in LastMatches)
                {
                    Console.WriteLine($"{c.LastName}, {c.FirstName}");
                }
                Console.WriteLine("Enter the first name of the customer you would like to update:");
                fname = Console.ReadLine();
                ToUpdate = CustData.Single(c => c.LastName == lastName && c.FirstName == fname);
                Console.WriteLine($"What Would you like to update from {ToUpdate.LastName}, {ToUpdate.FirstName} [(F)irstName, (L)astName, (C)ity, (Co)untry, (P)hone]");
                string choice = Console.ReadLine();
                Updater(choice, lastName, fname);

                bool cont = true;
                while (cont == true)
                {
                    Console.WriteLine("Perform More Updates? y/n");
                    string YNChoice = Console.ReadLine();


                    if (YNChoice.ToUpper() != "Y")
                    {
                        cont = false;
                        break;
                    }
                    else if (YNChoice.ToUpper() == "Y")
                    {
                        Console.WriteLine("What Would you like to update? [(F)irstName, (L)astName, (C)ity, (Co)untry, (P)hone]");
                        choice = Console.ReadLine();
                        Updater(choice, lastName,fname);
                    }
                }
            }
            else
            {
                Console.WriteLine("No match for that LastName");
            }

        }
        private static void Updater(string choice, string last, string first)
        {
            Customer cust = CustomerData.Customers.Single(c => c.LastName.ToUpper() == last && c.FirstName.ToUpper() == first);
            Console.WriteLine("-----------Update UI------------");
            if (choice.ToLower() == "f")
            {
                Console.WriteLine("What is the Customers FirstName?");
                cust.FirstName = Console.ReadLine();
            }
            else if (choice.ToLower() == "l")
            {
                Console.WriteLine("What is the Customers LastName?");
                cust.LastName = Console.ReadLine();
            }
            else if (choice.ToLower() == "c")
            {
                Console.WriteLine("What city does the Customer reside in?");
                cust.City = Console.ReadLine();
            }
            else if (choice.ToLower() == "co")
            {
                Console.WriteLine("What country does the Customer reside in?");
                cust.City = Console.ReadLine();
            }
            else if (choice.ToLower() == "p")
            {
                Console.WriteLine("What is the customers New Phone Number?");
                cust.Phone = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input: Check your spelling or enter something");
            }
            CustomerData.SaveChanges();
        }
        private static void Updater(string choice, string lastName)
        {

            Customer cust = CustomerData.Customers.Single(c => c.LastName.ToUpper() == lastName);
            Console.WriteLine("-----------Update UI------------");
            if (choice.ToLower() == "f")
            {
                Console.WriteLine("What is the Customers FirstName?");
                cust.FirstName = Console.ReadLine();
            }
            else if (choice.ToLower() == "l")
            {
                Console.WriteLine("What is the Customers LastName?");
                cust.LastName = Console.ReadLine();
            }
            else if (choice.ToLower() == "c")
            {
                Console.WriteLine("What city does the Customer reside in?");
                cust.City = Console.ReadLine();
            }
            else if (choice.ToLower() == "co")
            {
                Console.WriteLine("What country does the Customer reside in?");
                cust.City = Console.ReadLine();
            }
            else if (choice.ToLower() == "p")
            {
                Console.WriteLine("What is the customers New Phone Number?");
                cust.Phone = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input: Check your spelling or enter something");
            }
            CustomerData.SaveChanges();
        }
        public static List<string> FindCust(string lastName)
        {
            List<string> LastMatches = new List<string>();
            foreach (Customer c in CustomerData.Customers.Where(c => c.LastName.ToUpper() == lastName.ToUpper()))
            {
                LastMatches.Add($"Last Name: {c.LastName} First Name: {c.FirstName} Phone: {c.Phone} City: {c.City} Country: {c.Country}");
            }
            return LastMatches;
        }

        public static List<string> FilterCust(string FilterType, string Filter)
        {
            List<string> FilteredCusts = new List<string>();
            if (FilterType.ToUpper() == "L" || FilterType.ToUpper() == "LASTNAME")
            {
                Console.WriteLine("Search By LastName:");
                foreach (Customer c in CustomerData.Customers
                    .Where(c => c.LastName.ToUpper() == Filter.ToUpper()))
                {
                    FilteredCusts.Add($"Last Name: {c.LastName} First Name: {c.FirstName} Phone: {c.Phone} City: {c.City} Country: {c.Country}");
                }
            }
            else if (FilterType.ToUpper() == "C" || FilterType.ToUpper() == "CITY")
            {
                Console.WriteLine("Search By city:");
                foreach (Customer c in CustomerData.Customers
                    .Where(c => c.City.ToUpper() == Filter.ToUpper()))
                {
                    FilteredCusts.Add($"Last Name: {c.LastName} First Name: {c.FirstName} Phone: {c.Phone} City: {c.City} Country: {c.Country}");
                }
            }
            else if (FilterType.ToUpper() == "CH")
            {
                Console.WriteLine("Search by First Character of lastName");
                foreach (Customer c in CustomerData.Customers
                    .Where(c => c.LastName.StartsWith(Filter.ToUpper())))
                {
                    FilteredCusts.Add($"Last Name: {c.LastName} First Name: {c.FirstName} Phone: {c.Phone} City: {c.City} Country: {c.Country}");
                }
            }
            else 
            {
                Console.WriteLine("No Matches found!");
            }
            return FilteredCusts;
        }


    }
}
