using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
	public class Slot
	{
		public int x { get; set; }
		public int y { get; set; }
		public string? mean { get; set; }
		public Card? card { get; private set; }
		
		public bool registCard(Card card)
		{
			this.card = card;
			return true;
		}

		public bool removeCard()
		{
			if (this.card == null)
				return false; 
			
			this.card = null;
				return true;
		}
	}
}
