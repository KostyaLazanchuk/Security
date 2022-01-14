using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab1
{
    // 23, 55 
    internal class Program
    {

        static string text1 = "7958401743454e1756174552475256435e59501a5c524e176f786517545e475f5245191772195019175e43174" +
            "45f58425b531743565c521756174443455e595017d5b7ab5f525b5b58174058455b53d5b7aa175659531b17505e41525917435f52175c" +
            "524e175e4417d5b7ab5c524ed5b7aa1b174f584517435f5217515e454443175b524343524517d5b7ab5fd5b7aa17405e435f17d5b7ab5c" +
            "d5b7aa1b17435f5259174f584517d5b7ab52d5b7aa17405e435f17d5b7ab52d5b7aa1b17435f525917d5b7ab5bd5b7aa17405e435f17d5b7" +
            "ab4ed5b7aa1b1756595317435f5259174f58451759524f4317545f564517d5b7ab5bd5b7aa17405e435f17d5b7ab5cd5b7aa175650565e591b" +
            "17435f525917d5b7ab58d5b7aa17405e435f17d5b7ab52d5b7aa1756595317445817585919176e5842175a564e17424452175659175e5953524f1" +
            "758511754585e59545e53525954521b177f565a5a5e595017535e4443565954521b177c56445e445c5e17524f565a5e5956435e58591b17444356435e" +
            "44435e54565b17435244434417584517405f564352415245175a52435f5853174e5842175152525b174058425b5317445f584017435f52175552444317455244425b4319";
        static string text2 = "G0IFOFVMLRAPI1QJbEQDbFEYOFEPJxAfI10JbEMFIUAAKRAfOVIfOFkYOUQFI15ML1kcJFUeYhA4IxAeKVQZL1VMOFgJbFMDIUAAKUgFOElMI1ZMOFgFPxADIlVMO1VMO1kAIBAZP1VMI14ANRAZPEAJPlMNP1VMIFUYOFUePxxMP19MOFgJbFsJNUMcLVMJbFkfbF8CIElMfgZNbGQDbFcJOBAYJFkfbF8CKRAeJVcEOBANOUQDIVEYJVMNIFwVbEkDORAbJVwAbEAeI1INLlwVbF4JKVRMOF9MOUMJbEMDIVVMP18eOBADKhALKV4JOFkPbFEAK18eJUQEIRBEO1gFL1hMO18eJ1UIbEQEKRAOKUMYbFwNP0RMNVUNPhlAbEMFIUUALUQJKBANIl4JLVwFIldMI0JMK0INKFkJIkRMKFUfL1UCOB5MH1UeJV8ZP1wVYBAbPlkYKRAFOBAeJVcEOBACI0dAbEkDORAbJVwAbF4JKVRMJURMOF9MKFUPJUAEKUJMOFgJbF4JNERMI14JbFEfbEcJIFxCbHIJLUJMJV5MIVkCKBxMOFgJPlVLPxACIxAfPFEPKUNCbDoEOEQcPwpDY1QDL0NCK18DK1wJYlMDIR8II1MZIVUCOB8IYwEkFQcoIB1ZJUQ1CAMvE1cHOVUuOkYuCkA4eHMJL3c8JWJffHIfDWIAGEA9Y1UIJURTOUMccUMELUIFIlc=";
        static void Main(string[] args)
        {

            byte[] repeatingkey = Encoding.ASCII.GetBytes("L0l");

            byte[] array2 = System.Convert.FromBase64String(text2);
            Task1(55);

           /* for (int i = 1; i < 256; i++)
            {
                for (int j = 0; j < 132; j++)
                {
                    byte[] check = new byte[2];
                    check[0] = (byte)(i);
                    check[1] = (byte)(j);*/
                    
                  /*  Console.WriteLine(result);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Thread.Sleep(500);*/
            /*       }
               }*/

            /*int size = GetKeylenght(array2);
            Console.WriteLine(size);*/
            byte[] input = RepeatingKeyXor(array2, repeatingkey);


            string result = Encoding.ASCII.GetString(input);
            int dif = '5'-'i';
            int dif2 = '9' - 'e';
            int dif3 = '8' - 'd';
            Console.WriteLine(result);
            //string q = "77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777";
            //Console.WriteLine(q.Length);
           /* Console.WriteLine(dif);
            Console.WriteLine(dif2);
            Console.WriteLine(dif3);*/
        }
        static byte[] SingeByteXor(byte[] bytes, int key)
        {
            //xor cipher
            byte[] bytes2 = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {

                bytes2[i] = (byte)(bytes[i] ^ Convert.ToByte(key));

            }
            return bytes2;
        }
        static byte[] StringToByte(string text1)
        {
            // строки к байту
            var bytes = new byte[text1.Length / 2];
            for (int i = 0; i < text1[text1.Length / 2]; i++)
            {
                string couple = "";
                couple += text1[i * 2];
                couple += text1[i * 2 + 1];
                bytes[i] = Convert.ToByte(couple, 16);
            }
            return bytes;


        }
        static byte[] RepeatingKeyXor(byte[] bytes, byte[] key)
        {
            //xor cipher 2
            byte[] array = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                int shift = i % key.Length;
                array[i] = (byte)(bytes[i] ^ key[shift]);

            }
            return array;
            /*    int repetitoins = 1 + (bytes.Length / key.Length);
                key = key * repetitoins;
                key = key.Take(bytes.Length);*/

        }
        static void Task1(int i)
        {
            byte[] bytes = StringToByte(text1);
            byte[] array = SingeByteXor(bytes, i);

            string bitString = Encoding.ASCII.GetString(array);
            Console.WriteLine(i);
            Console.WriteLine(bitString);


        }
        static int GetKeylenght(byte[] text)
        {
            int? bestKey = null;
            int? lowestKey = null;
            for (int keylength = 2; keylength < 41; keylength++)
            {
                List<int> toAverage = new List<int>();
                int start = 0;
                int end = start + keylength;
                while (true)
                {
                    byte[] firstChunk = text.Skip(start).Take(keylength).ToArray();
                    byte[] secondChunk = text.Skip(start + keylength).Take(keylength).ToArray();
                    if (secondChunk.Length < keylength)
                    {
                        break;
                    }
                    int distance = HammingDistance(firstChunk, secondChunk);
                    int normalized = distance / keylength;
                    toAverage.Add(normalized);
                    start = end + keylength;
                    end = start + keylength;
                }
                int average = toAverage.Count() / toAverage.ToArray().Length;
                if (lowestKey == null || average < lowestKey)
                {
                    lowestKey = average;
                    bestKey = keylength;
                }
            }
            return (int)bestKey;
        }
        static int HammingDistance(byte[] bytes1, byte[] bytes2)
        {
            int distance = 0;
            for (int i = 0; i < bytes1.Length - 1; i++)
            {
                byte x = (byte)(bytes1[i] ^ bytes2[i]);
                int setbits = 0;
                setbits = Convert.ToString(x, 2).PadLeft(8, '0').ToCharArray().Where(c => c == '1').ToArray().Length;
                distance += setbits;
            }
            return distance;

        }
        /*static string GetKey(byte[][] blocks)
        {
            string common = "ETAOIN SHRDLU", key = "";
            foreach (byte[] str in blocks)
            {
                int current_high_score = 0;
                char current_key_char = ' ';
                int[] arr;
                for (int i = 0, j = 0; i < 127; i++, j = 0)
                {
                    arr = new int[str.Length];
                    foreach (char letter in str)
                    {
                        arr[j] = i ^ letter;
                        j++;
                    }

                    string? convertedString = ConvertToString(arr);
                    Console.WriteLine(convertedString);

                    if (convertedString is not null)
                    {
                        int score = 0;
                        foreach (char letter1 in convertedString.ToUpper())
                        {
                            foreach (char letter2 in common)
                            {
                                if (letter1 == letter2)
                                {
                                    score++;
                                }
                            }
                        }

                        if (score > current_high_score)
                        {
                            current_high_score = score;
                            current_key_char = (char)j;
                        }
                        key += current_key_char;
                    }
                }
            }
            return key;
        }*/

    }
}
