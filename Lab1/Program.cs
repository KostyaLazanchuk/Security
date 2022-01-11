using System;

namespace Lab1
{
    internal class Program
    {
        public static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += Cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Type a string to encrypt:");
            string UserString = Console.ReadLine();

            Console.WriteLine("\n");

            Console.Write("Enter your Key");
            Console.WriteLine("\n");


            Console.WriteLine("Encrypted Data");
            for (int key = 0; key < 26; key++)
            {
                string cipherText = Encipher(UserString, key);
                Console.WriteLine(key + "number " + cipherText);
                Console.Write("\n");
            }

            /*
                        Console.WriteLine("Decrypted Data:");

                        string t = Decipher(cipherText, key);
                        Console.WriteLine(t);
                        Console.Write("\n");*/


            Console.ReadKey();

        }
    }
}
