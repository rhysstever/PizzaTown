using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTown
{
	public enum ShopListType
	{
		Title,
		Mount,
		Time,
		Pizzas
	}

	class TierList
	{
		// Fields
		private Tier head;
		private Tier tail;
		private int count;
		private ShopListType type;

		// Properties
		public Tier Head { get { return head; } }
		public Tier Tail { get { return tail; } }
		public int Count { get { return count; } }
		public ShopListType Type { get { return type; } }

		// Constructor

		public TierList(ShopListType type)
		{
			head = null;
			tail = null;
			count = 0;
			this.type = type;
		}

		// Methods
		public void Add(Tier newTier)
		{
			// If LinkedList is empty
			// Sets both head and tail to the new node (tier)
			if(head == null)
			{
				head = newTier;
				tail = newTier;
			}
			else
			{
				// Points the last tier to the new tier
				tail.Next = newTier;
				newTier = tail;
			}

			count++;
		}
	}
}
