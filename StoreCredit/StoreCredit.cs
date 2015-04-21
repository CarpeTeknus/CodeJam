using System;
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

            int[] intCreditAmount = new int[intNumberOfCases];
            string[] strCreditAmount = new string[intNumberOfCases];
            int[] intNumberOfItems = new int[intNumberOfCases];
            string[] strNumberOfItems = new string[intNumberOfCases];
            int[][] itemsPriceList = new int[intNumberOfCases][];
            int[,] purchasedItems = new int[intNumberOfCases, 2];


            for (int caseNumber = 0; caseNumber < intNumberOfCases; caseNumber++)
            {
                strCreditAmount[caseNumber] = reader.ReadLine();

                if (!int.TryParse(strCreditAmount[caseNumber], out intCreditAmount[caseNumber]))
                {
                    Console.WriteLine("Wrong input, (Credit Amount Case #" + caseNumber.ToString() + ") Press enter to exit...");
                    Console.ReadLine();
                    return;
                }
                if (intCreditAmount[caseNumber] < 5 || intCreditAmount[caseNumber] > 1000)
                {
                    Console.WriteLine("Wrong input, (Credit Amount Case #" + caseNumber.ToString() + ") Press enter to exit...");
                    Console.ReadLine();
                    return;
                }



                strNumberOfItems[caseNumber] = reader.ReadLine();
                if (!int.TryParse(strNumberOfItems[caseNumber], out intNumberOfItems[caseNumber]))
                {
                    Console.WriteLine("Wrong input, (Number of Items Case #" + caseNumber.ToString() + ") Press enter to exit...");
                    Console.ReadLine();
                    return;
                }



                string priceList = reader.ReadLine();
                string[] arrPriceList = priceList.Split(' ');

                if (arrPriceList.Length != intNumberOfItems[caseNumber])
                {
                    Console.WriteLine("Wrong input, (Price ListCase #" + caseNumber.ToString() + ") Press enter to exit...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    itemsPriceList[caseNumber] = new int[intNumberOfItems[caseNumber]];
                    for (int p = 0; p < arrPriceList.Length; p++)
                    {
                        if (!int.TryParse(arrPriceList[p], out itemsPriceList[caseNumber][p]))
                        {
                            Console.WriteLine("Wrong input, (Price ListCase #" + caseNumber.ToString() + ") Press enter to exit...");
                            Console.ReadLine();
                            return;
                        }
                        if (itemsPriceList[caseNumber][p] < 1 || itemsPriceList[caseNumber][p] > 1000)
                        {
                            Console.WriteLine("Wrong input, (Price ListCase #" + caseNumber.ToString() + ") Press enter to exit...");
                            Console.ReadLine();
                            return;
                        }

                    }


                }
            }
            reader.Close();
            reader.Dispose();
            Console.WriteLine("");
            Console.WriteLine("Output...");

            StreamWriter writer = File.CreateText("output.txt");

            for (int caseNumber =0;caseNumber<intNumberOfCases;caseNumber++){
                int resultIndex1 = 0;
                int resultIndex2 = 0;
                bool resultFound = false;
                for (int itemIndex1 = 0; itemIndex1 < itemsPriceList[caseNumber].Length; itemIndex1++)
                {
                    for (int itemIndex2 = itemIndex1+1; itemIndex2 < itemsPriceList[caseNumber].Length; itemIndex2++ )
                    {
                        if (itemsPriceList[caseNumber][itemIndex1] + itemsPriceList[caseNumber][itemIndex2] == intCreditAmount[caseNumber])
                        {
                            resultIndex1 = itemIndex1;
                            resultIndex2 = itemIndex2;
                            resultFound = true;
                            break;
                        }
                    }
                    if (resultFound) break;
                }
                
                Console.WriteLine(string.Format("Case #{0}: {1} {2}", (caseNumber + 1).ToString(), (resultIndex1 + 1).ToString(), (resultIndex2 + 1).ToString()));
                writer.WriteLine(string.Format("Case #{0}: {1} {2}", (caseNumber + 1).ToString(), (resultIndex1 + 1).ToString(), (resultIndex2 + 1).ToString()));
            }
            writer.Close();
            writer.Dispose();
            Console.ReadLine();

        }
        
    }
}
