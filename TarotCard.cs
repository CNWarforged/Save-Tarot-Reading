using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTarotReading
{
    public class TarotCard
    {
        public int DBKey { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string ArcanaType { get; set; } = string.Empty;
        public int Upright { get; set; }

        public TarotCard() { }
    }
}
