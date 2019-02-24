using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTown
{
	class Tier
	{
		// Fields
		private int level;
		private string name;
		private int bonus;
		private int cost;
		private bool isPurchased;
		private Tier nextTier;

		// Properties
		public int Level { get { return level; } }
		public string Name { get { return name; } }
		public int Bonus { get { return bonus; } }
		public int Cost { get { return cost; } }
		public bool IsPurchased
		{
			get { return isPurchased; }
			set { isPurchased = value; }
		}
		public Tier Next
		{
			get { return nextTier; }
			set { nextTier = value; }
		}

		// Constructor

		/// <summary>
		/// Creates a tier level that can be added to a tier list object
		/// </summary>
		/// <param name="level">The tier level of the object</param>
		/// <param name="name">The name of the tier level</param>
		/// <param name="bonus">The numeric bonus of having this tier level</param>
		/// <param name="cost">The cost to buy this level</param>
		/// <param name="isPurchased">Whether the tier level has been bought</param>
		public Tier(int level, string name, int bonus, int cost, bool isPurchased)
		{
			this.level = level;
			this.name = name;
			this.bonus = bonus;
			this.cost = cost;
			this.isPurchased = isPurchased;
		}

		// Methods
	}
}
