using System;
namespace StringHashingSamples
{
    class Program
    {
        static void Main(string[] args)
        {
           GetNextBytes(startIndex: 0, "lore");

            string input = string.Empty;
            while (! input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Writelin
            }

            
        }
        private static int AdditiveHash(string input)
        {
            int currentHashValue = 0;
            foreach (char c in input)
            {
                unchecked
                {
                    currentHashValue += (int)c;
                }
                
            }
            return currentHashValue;
        }
        private static int FoldingHash(string input)
        {
            int hashValue = 0;
            int startIndex = 0;
            int curentFourBytes;
            do
            {
                curentFourBytes = GetNextBytes(startIndex, input);
                unchecked
                {
                    hashValue += curentFourBytes;
                }
                startIndex += 4;

            } while (curentFourBytes != 0);

            return hashValue;
        }
             
        private static int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;
            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes+= GetByte(str, index: startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;

            return currentFourBytes;
        }

        private static int GetByte(string str, int index)
        {
            if (index<str.Length)
            {
                return (int)str[index];
            }
            return 0;
        }

    }

}