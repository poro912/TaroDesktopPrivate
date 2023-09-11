using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
    public class Card
	{
		// private int number = -1;
		// private string name = "";
		// private string? category = "";

		
		public int Number{ get; set; }
		public string Name { get; set; }	// int -> string
		public string? Category { get; set; } // int -> string?

		public List<string> forward;
		public List<string> reverse;

		public Card(string name, int number) 
		{ 
			this.Name = name;	// name -> Name
			this.Number = number;	// number -> Number
			forward = new List<string>();
			reverse = new List<string>();
		}
		public Card(string name, int number, string category)
		{
			this.Name = name;   // name -> Name
            this.Number = number;   // number -> Number
            this.Category = category; // category -> Category
			forward = new List<string>();
			reverse = new List<string>();
		}

		public void addForwardMean(string mean) { forward.Add(mean);  }
		public void addFrontMean(string mean) { forward.Add(mean); }

	}
}
