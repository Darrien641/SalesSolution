using System;
using DataProject;
using System.Text;
namespace PresentationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            foreach (var c in Menu.GetMenu()) 
            {
                Console.WriteLine(c.ToString());
            }
            input = Console.ReadLine();
            Menu.OptionSelector(Convert.ToInt32(input));

        }
    }
}
