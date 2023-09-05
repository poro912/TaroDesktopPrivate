using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
	internal class Card
	{
		private int number = -1;
		private string name = "";
		private string? category = "";

		
		public int Number{ get; set; }
		public int Name { get; set; }
		public int Category { get; set; }

		public List<string> forward;
		public List<string> reverse;

		public Card(string name, int number) 
		{ 
			this.name = name;
			this.number = number;
			forward = new List<string>();
			reverse = new List<string>();
		}
		public Card(string name, int number, string category)
		{
			this.name = name;
			this.number = number;
			this.category = category;
			forward = new List<string>();
			reverse = new List<string>();
		}

		public void addForwardMean(string mean) { forward.Add(mean);  }
		public void addFrontMean(string mean) { forward.Add(mean); }

	}
}
