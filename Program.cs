using System;
using System.Linq;
using System.Collections.Generic;

namespace CaesarCipher
{
    class Program
    {
        public class GlobalVars
        {
            public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            public static char[] rev_alphabet = new char[] { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };
            public static string listOfStrings = "!@#$%^&*()_+-={}|;:'.,";

        }

        static void Main(string[] args)
        {


            Console.WriteLine("Write your message:... ");
            string userMsg = Console.ReadLine();
            userMsg = userMsg.ToLower();
            char[] secretMessage = userMsg.ToCharArray();

            Console.WriteLine("Enter your key:... ");
            string userKeyAnswer = Console.ReadLine();
            bool success = Int32.TryParse(userKeyAnswer, out int userKey);
            if (success)
            {
                Console.WriteLine($"Your key is {userKey}");
            }
            else
            {
                Console.WriteLine("Input number is invalid, did you wrote a number?");
            }

            Console.WriteLine("Choose your mode: Encryption or Decryption...");
            string userAnswer = Console.ReadLine();

            if (userAnswer.Equals("Encryption", StringComparison.OrdinalIgnoreCase) && success == true)
            {
                Console.WriteLine("Encrypting...");
                Console.WriteLine(Encrypt(secretMessage, userKey));
            }
            else if (userAnswer.Equals("Decryption", StringComparison.OrdinalIgnoreCase) && success == true)
            {
                Console.WriteLine("Decrypting...");
                Console.WriteLine(Decrypt(secretMessage, userKey));
            }
            else
            {
                Console.WriteLine("Invalid Method");
            }

            Console.ReadLine();
        }




        static string Encrypt(char[] array, int key)
        {

            char[] encryptedMessage = new char[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string myString = Char.ToString(array[i]);
                bool yeah = GlobalVars.listOfStrings.Any(s => myString.Contains(s));
                if (yeah == true)
                {

                    continue;

                }
                else
                {


                }
                char letter = array[i];
                int index = Array.IndexOf(GlobalVars.alphabet, letter);
                index = (index + key) % GlobalVars.alphabet.Length;
                char newLetter = GlobalVars.alphabet[index];
                encryptedMessage[i] = newLetter;

            }
            string msgString = String.Join("", encryptedMessage);
            return msgString;
        }


        static string Decrypt(char[] array, int key)
        {

            char[] encryptedMessage = new char[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string myString = Char.ToString(array[i]);
                bool yeah = GlobalVars.listOfStrings.Any(s => myString.Contains(s));
                if (yeah == true)
                {

                    continue;

                }
                else
                {


                }
                char letter = array[i];
                int index = Array.IndexOf(GlobalVars.alphabet, letter);
                index = (index - key) % GlobalVars.alphabet.Length;
                if (index < 0)
                {

                    index = Math.Abs(index);
                    index = index - 1;
                    index = index % GlobalVars.rev_alphabet.Length;
                    Console.WriteLine(index);
                    char newLetter = GlobalVars.rev_alphabet[index];
                    encryptedMessage[i] = newLetter;

                }
                else
                {

                    char newLetter = GlobalVars.alphabet[index];
                    encryptedMessage[i] = newLetter;

                }
            }
            string msgString = String.Join("", encryptedMessage);
            return msgString;
        }


    }
}
