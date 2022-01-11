using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Lab1
{

    internal class Program
    {

        static void Main(string[] args)
        {
            string text = "7958401743454e1756174552475256435e59501a5c524e176f786517545e475f524519177219501";

            string result = XORMethod.EncryptDecrypt(text, 7);
            Console.WriteLine("number " + 7 + " " + result);

        }
    }
}
