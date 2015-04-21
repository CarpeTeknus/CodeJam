using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    public class Opera
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
                int maxShy = 0;
                if (!int.TryParse(strCase[0], out maxShy))
                {
                    Console.WriteLine("Wrong input, (Credit Amount Case #" + caseNumber.ToString() + ") Press enter to exit...");
                    Console.ReadLine();
                    return;
                }
                int numberInvites = 0;
                int totalStanding = 0;

                for (int p = 0; p < maxShy; p++)
                {
                    totalStanding = totalStanding + int.Parse(strCase[1].ElementAt(p).ToString());
                    int standingNeeded = int.Parse(strCase[1].ElementAt(p + 1).ToString());
                    while (totalStanding < p+1)
                    {
                        numberInvites++;
                        totalStanding++;
                    }

                }
                Console.WriteLine(string.Format("Case #{0}: {1}", (caseNumber + 1).ToString(), numberInvites.ToString()));
                writer.WriteLine(string.Format("Case #{0}: {1}", (caseNumber + 1).ToString(), numberInvites.ToString()));
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

