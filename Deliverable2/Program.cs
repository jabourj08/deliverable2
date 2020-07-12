using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Deliverable2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string message;
            int checksum;
            bool valid;

            //Greeting
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Hello, and welcome to the Super Cool Message Encoder!");
            Console.WriteLine("*****************************************************");
            Console.WriteLine();

            //create alphabet array
            char[] alphabet = new char[26];

            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)(i + 65); //65 is the offset for capital A in the ascaii table
            }

            //check to make sure array populates with alphabet
            //Console.WriteLine(alphabet);

            //start loop for continuance
            string cont = "y";
            do
            {
                //reset values
                valid = false;
                message = "";
                checksum = 0;

                //ask user for input
                Console.WriteLine("What is the message you would like to encode? (Please enter only letters): ");
                input = Console.ReadLine();

                //make sure user input contains only letters
                do
                {
                    if (Regex.IsMatch(input, @"^[\p{L}]+$"))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, Please enter only letters: ");
                        input = Console.ReadLine();
                    }
                }
                while (!valid);

                //once valid, convert to uppercase
                input = input.ToUpper();
                Console.WriteLine();

                //create and execute encoder
                char[] inputArray = input.ToCharArray();


                for (int i = 0; i < inputArray.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (inputArray[i].Equals(alphabet[j]))
                        {
                            if (i < inputArray.Length - 1)
                            {
                                int a = Array.IndexOf(alphabet, inputArray[i]);
                                //check to make sure correct index is grabbed
                                //Console.WriteLine(a + 1);
                                message = message.Insert(message.Length, a + 1 + "-");
                            }
                            else
                            {
                                int a = Array.IndexOf(alphabet, inputArray[i]);
                                //check to make sure correct index is grabbed
                                //Console.WriteLine(a + 1);
                                message = message.Insert(message.Length, a + 1 + "");
                            }
                            
                        }
                    }
                }

                //create ascii array
                byte[] asciiBytes = Encoding.ASCII.GetBytes(input);

                //calculate checksum
                foreach (int s in asciiBytes)
                {
                    //check to ensure correct ascii values
                    //Console.WriteLine(s);
                    checksum = checksum + s;
                }

                //print message
                Console.WriteLine();
                Console.WriteLine("Your encoded message is: " + message);
                Console.WriteLine();

                //print checksum
                Console.WriteLine();
                Console.WriteLine("Your message checksum is: " + checksum);
                Console.WriteLine();

                //ask for continuance
                Console.WriteLine();
                Console.WriteLine("Would you like to encode another message? enter y for yes or n for no: ");
                cont = Console.ReadLine();
                Console.WriteLine();

            }
            while (cont != "n");
        }
    }
}
