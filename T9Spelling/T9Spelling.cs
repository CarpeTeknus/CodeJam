using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    public class StoreCredit
    {

        public static void Main(String[] args) {

            string strNumberOfCases;
            int intNumberOfCases = 0;
            Hashtable alpha = new Hashtable();
            alpha.Add('a', "2");
            alpha.Add('b', "22");
            alpha.Add('c', "222");
            alpha.Add('d', "3");
            alpha.Add('e', "33");
            alpha.Add('f', "333");
            alpha.Add('g', "4");
            alpha.Add('h', "44");
            alpha.Add('i', "444");
            alpha.Add('j', "5");
            alpha.Add('k', "55");
            alpha.Add('l', "555");
            alpha.Add('m', "6");
            alpha.Add('n', "66");
            alpha.Add('o', "666");
            alpha.Add('p', "7");
            alpha.Add('q', "77");
            alpha.Add('r', "777");
            alpha.Add('s', "7777");
            alpha.Add('t', "8");
            alpha.Add('u', "88");
            alpha.Add('v', "888");
            alpha.Add('w', "9");
            alpha.Add('x', "99");
            alpha.Add('y', "999");
            alpha.Add('z', "9999");
            alpha.Add(' ', "0");
            Console.WriteLine("Reading input...");
            Console.WriteLine();
            TextReader reader = File.OpenText("input.txt");
            //Read Number of Cases
            strNumberOfCases = reader.ReadLine();
            if (!int.TryParse(strNumberOfCases, out intNumberOfCases))
            {
                Console.WriteLine("Wrong input (Number of Cases), please enter to finish process...");
                Console.ReadLine();
                return;
            }

            

            
            StreamWriter writer = File.CreateText("output.txt");
            Console.WriteLine("Output...");
            //For every case
            for (int caseNumber = 0; caseNumber < intNumberOfCases; caseNumber++)
            {
                //get text line into a char array
                char[] strCase = reader.ReadLine().ToCharArray();

                Console.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));
                writer.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));
                char last = ' ';

                //check all chars in line
                for (int p = 0; p < strCase.Length; p++)
                {
                    //get code input for char
                    string codeInput = alpha[strCase[p]].ToString();

                    //if first char of new code equals last of previous, insert pause
                    if (codeInput.ElementAt(codeInput.Length - 1).Equals(last))
                    {
                        Console.Write(" ");
                        writer.Write(" ");

                    }
                    //insert code
                    Console.Write(codeInput);
                    writer.Write(codeInput);

                    //save last char to compare against next code
                    last = codeInput.ElementAt(codeInput.Length - 1);

                }
                Console.WriteLine();
                writer.WriteLine();
            }

            //close streams and files
            reader.Close();
            reader.Dispose();
            Console.WriteLine("");


            writer.Close();
            writer.Dispose();
            Console.ReadLine();

        }
        
    }
}
