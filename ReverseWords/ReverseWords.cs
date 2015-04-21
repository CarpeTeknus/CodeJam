using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    public class ReverseWords
    {

        public static void Main(String[] args)
        {

            string strNumberOfCases;
            int intNumberOfCases = 0;
            Console.WriteLine("Reading input...");
            Console.WriteLine();
            TextReader reader = File.OpenText("input.txt");
            strNumberOfCases = reader.ReadLine();
            if (!int.TryParse(strNumberOfCases, out intNumberOfCases))
            {
                Console.WriteLine("Wrong input (Number of Cases), please enter to finish process...");
                Console.ReadLine();
                return;
            }

            StreamWriter writer = File.CreateText("output.txt");
            Console.WriteLine("Output...");
            for (int caseNumber = 0; caseNumber < intNumberOfCases; caseNumber++)
            {
                string[] strCase = reader.ReadLine().Split(' ');

                 Console.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));
                writer.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));
                for (int p = strCase.Length; p > 0; p--)
                {
                    Console.Write(strCase[p - 1] + " ");
                    writer.Write(strCase[p - 1] + " ");
                }
                Console.WriteLine();
                writer.WriteLine();
            }
            reader.Close();
            reader.Dispose();
            Console.WriteLine("");


            writer.Close();
            writer.Dispose();
            Console.ReadLine();


        }


    }

}

