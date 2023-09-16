using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
    public class Card
	{
		public int number{ get; set; }
		public string name { get; set; }
		public string? category { get; set; }

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
