using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
	// 필드에 카드가 배치될 때 필요한 데이터
	public class Spread
	{
		public string name { get; set; }
		public string description { get; set; }
		public List<Slot> slots { get; set; }


		public Slot? this[int index]
		{
			get
			{
				if (0 <= index && index < slots.Count)
					return slots[index];
				return null;
			}
		}
	}
}
