namespace SaveTarotReading
{
    class SaveTarotReading
    {
        public static int Main()
        {
            string readingPath = @"C:\Users\shini\Documents\CS 361\Microservices\Temp_Num.txt";
            string readPath = @"C:\Users\shini\Documents\CS 361\Microservices\Personal Readings\";
            if (File.Exists(readingPath) == false)
            {
                Console.WriteLine("File not found.");
                return 1;
            }

            string words = ReadFile(readingPath);
            List<string> readingList = new List<string>();
            SplitString(words, ref readingList);
            ParseFile(ref readingList, readPath);

            return 0;
        }

        public static string ReadFile(string cardPath)
        {
            string words = "";

            try
            {
                using (StreamReader readIn = new StreamReader(cardPath))
                {
                    words = readIn.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading the file. Error is:");
                Console.WriteLine(e.Message);
            }

            return words;
        }

        public static void WriteFile(string text, string cardPath)
        {
            try
            {
                using (StreamWriter writeOut = new StreamWriter(cardPath))
                {
                    writeOut.Write(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing to the file. Error is:");
                Console.WriteLine(e.Message);
            }
        }

        public static void SplitString(string word, ref List<string> readingList)
        {
            string[] words = word.Split(", ");

            foreach (var part in words)
            {
                readingList.Add(part);
            }
        }

        public static void ParseFile(ref List<string> readingList, string path)
        {
            var tarotList = new TarotList();
            tarotList = dbAccess.ReadDB();

            if (readingList.Count == 3)
            {
                BasicReading(ref readingList, path, tarotList);
            }
            else
            {
                CelticReading(ref readingList, path, tarotList);
            }
        }

        private static void BasicReading(ref List<string> readingList, string path, TarotList cardList)
        {



        }

        private static void CelticReading(ref List<string> readingList, string path, TarotList cardList)
        {



        }
    }


}
