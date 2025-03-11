using System;

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

        private static void BasicReading(ref List<string> readingList, string path, TarotList tarotList)
        {
            int num = Int32.Parse(readingList[0]);
            string reading = "Here is your tarot reading for " + DateTime.Today.Day.ToString() + ":" + "\n";
            reading = reading + "The card representing your past is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[1]);
            reading = reading + "The card representing your present is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[2]);
            reading = reading + "The card representing your future is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";

            string newFile = path + "Past-Present-Future Tarot Reading " + DateTime.Today.Day + " " + DateTime.Today.Ticks.ToString() + ".txt";
            WriteFile(reading, newFile);
        }

        private static void CelticReading(ref List<string> readingList, string path, TarotList tarotList)
        {
            int num = Int32.Parse(readingList[0]);
            string reading = "Here is your tarot reading for " + DateTime.Today.Day.ToString() + ":" + "\n";
            reading = reading + "The card representing The Situation is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[1]);
            reading = reading + "The card representing What Crosses You is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[2]);
            reading = reading + "The card representing Best That Can Be Achieved is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[3]);
            reading = reading + "The card representing The Reason For Your Reading is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[4]);
            reading = reading + "The card representing The Past is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[5]);
            reading = reading + "The card representing The Near Future is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[6]);
            reading = reading + "The card representing You is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[7]);
            reading = reading + "The card representing Your Environment is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[8]);
            reading = reading + "The card representing your Hopes Or Fears is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";
            num = Int32.Parse(readingList[9]);
            reading = reading + "The card representing The Outcome is: " + tarotList.CardList[num].Name + "\n";
            reading = reading + "The description is: " + tarotList.CardList[num].ShortDescription + "\n";

            string newFile = path + "Celtic Cross Tarot Reading " + DateTime.Today.Day + " " + DateTime.Today.Ticks.ToString() + ".txt";
            WriteFile(reading, newFile);
        }
    }
}
