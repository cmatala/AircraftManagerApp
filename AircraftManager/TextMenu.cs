using System;
using System.Globalization;



namespace AircraftNamespace
{
    public class TextMenu
    {
        // Instance variable to store the menu items
        private string[] menuItems;

        // Constructor that accepts an array of menu items
        public TextMenu(string[] items)
        {
            // Create a new array and copy the contents
            menuItems = new string[items.Length];
            Array.Copy(items, menuItems, items.Length);
        }

        // Method to get the user's choice
        public int GetChoice()
        {
            int choice;
            do
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();
                choice = ValidateChoice(userInput);
                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            } while (choice == -1);

            return choice;
        }

        // Method to validate the user's choice
        public int ValidateChoice(string choice)
        {
            try
            {
                int intChoice = int.Parse(choice);
                if (intChoice < 1 || intChoice > menuItems.Length)
                {
                    return -1;
                }
                return intChoice;
            }
            catch (FormatException)
            {
                return -1;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }
    }
}

