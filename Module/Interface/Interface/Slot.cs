using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
    public class Slot
	{
		private int x, y;
		private Card? card;

		public int X
		{
			get; private set;
		}
		public int Y
        {
            get; private set;
        }
        public string? mean { get; set; }
		public Card? Card { get { return card; } }
		
		public bool registCard(Card card)
		{
			this.card = card;
			return true;
		}

		public bool removeCard()
		{
			if(this.card == null)
				return false; 
			
			this.card = null;
			return true;
		}
	}
}
