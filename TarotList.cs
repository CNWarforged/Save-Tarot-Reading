using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTarotReading
{
    public class TarotList
    {
        private List<TarotCard>? _CardList;
        public List<TarotCard> CardList
        {
            get
            {
                return _CardList ??= new List<TarotCard>();
            }
            set
            {
                _CardList = value;
            }

        }
    }
}
