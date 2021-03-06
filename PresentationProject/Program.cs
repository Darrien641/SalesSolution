using System;
using DataProject;
using System.Text;
namespace PresentationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool operating = true;
            while (operating == true) {
                string input;
                foreach (var c in Menu.GetMenu())
                {
                    Console.WriteLine(c.ToString());
                }
                
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter A valid input or quit");
                }else if(Convert.ToInt32(input) > 0 && Convert.ToInt32(input) < 7)
                {
                    Menu.OptionSelector(Convert.ToInt32(input));
                }
                else {
                    operating = false;
                    break;
                }
                
            }
        }
    }
}
