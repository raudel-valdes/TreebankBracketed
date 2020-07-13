using System;
using System.IO;
using System.Text;

namespace TreebankBracketed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to your file: ");

            string filePath = Console.ReadLine();
            string fileText = "";

            Console.WriteLine(filePath);

            try
            {
                fileText = File.ReadAllText(filePath);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            ASCIIEncoding en = new ASCIIEncoding();
            byte[] input = en.GetBytes(fileText);
            Scanner scanner = new Scanner(new MemoryStream(input));
            Parser parser = new Parser(scanner);
        }
    }
}
