using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SaveTarotReading
{
    internal class dbAccess
    {
        public static TarotList ReadDB()
        {
            var tarotList = new TarotList();

            using (OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\shini\\Documents\\CS 361\\TarotCards.accdb"))
            {
                con.Open();
                var query = "SELECT * FROM TarotCards WHERE ArcanaType = @arcana";
                var cards = con.Query<TarotCard>(query, new { arcana = "Major" }).ToList();
                foreach (var card in cards)
                {
                    tarotList.CardList.Add(card);
                }
                con.Close();
            }

            return tarotList;
        }
    }
}
