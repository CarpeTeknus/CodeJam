using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    public class MinimumScalarProduct
    {

        public static void Main(String[] args) {

            string strNumberOfCases;
            int intNumberOfCases = 0;
            
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
                int elementsNumber= int.Parse(reader.ReadLine());

                Console.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));
                writer.Write(string.Format("Case #{0}: ", (caseNumber + 1).ToString()));


                string[] vector1 = reader.ReadLine().Split(' ');
                string[] vector2 = reader.ReadLine().Split(' ');
                List<Int64> vectorList1 = new List<Int64>(elementsNumber);
                List<Int64> vectorList2 = new List<Int64>(elementsNumber);
                foreach (string s in vector1)
                    vectorList1.Add(Int64.Parse(s));
                foreach (string s in vector2)
                    vectorList2.Add(Int64.Parse(s));

                vectorList1.Sort();
                vectorList2.Sort();
                
                if (vectorList1.ElementAt(0) > vectorList2.ElementAt(0))
                    vectorList1.Reverse();
                else
                    vectorList2.Reverse();

                Int64 minimumProduct = 0;
                  //check all chars in line
                for (int p = 0; p < elementsNumber; p++)
                {
                    minimumProduct = minimumProduct + vectorList1[p] * vectorList2[p];
                }

                Console.WriteLine(minimumProduct.ToString());
                writer.WriteLine(minimumProduct.ToString());
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
