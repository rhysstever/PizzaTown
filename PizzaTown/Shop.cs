using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTown
{
	class Shop
	{
		// Fields
		private TierList title;
		private TierList mount;
		private TierList time;
		private TierList pizzas;

		private Tier currentTitle;
		private Tier currentMount;
		private Tier currentTimeBonus;
		private Tier currentPizzaBonus;

		// Properties
		public TierList Title { get { return title; } }
		public TierList Mount { get { return mount; } }
		public TierList Time { get { return time; } }
		public TierList Pizzas { get { return pizzas; } }
		public Tier CurrentTitle { get { return currentTitle; } }
		public Tier CurrentMount { get { return currentMount; } }
		public Tier CurrentTimeBonus { get { return currentTimeBonus; } }
		public Tier CurrentPizzaBonus { get { return currentPizzaBonus; } }

		// Constructor

		public Shop()
		{
			// Initializes each Queue and 
			title = new TierList(ShopListType.Title);
			mount = new TierList(ShopListType.Mount);
			time = new TierList(ShopListType.Time);
			pizzas = new TierList(ShopListType.Pizzas);

			// Adds tier levels for each linkedlist
			title.Add(new Tier(0, "Pizza Peasant", 0, 0, true));
			title.Add(new Tier(1, "Pizza Knight", 1, 10, false));
			title.Add(new Tier(3, "Pizza King", 4, 40, false));
			title.Add(new Tier(4, "Pizza Peasant", 8, 80, false));
			title.Add(new Tier(5, "Pizza Peasant", 16, 160, false));
			title.Add(new Tier(2, "Pizza Lord", 2, 20, false));

			mount.Add(new Tier(0, "No Mount", 0, 0, true));
			mount.Add(new Tier(1, "Corgi", 1, 10, false));
			mount.Add(new Tier(2, "Super Corgi", 2, 20, false));
			mount.Add(new Tier(3, "Ultimate Corgi", 4, 40, false));

			time.Add(new Tier(0, "Starting Time", 0, 0, true));
			time.Add(new Tier(1, "", 1, 10, false));
			time.Add(new Tier(2, "", 2, 20, false));
			time.Add(new Tier(3, "", 4, 40, false));
			time.Add(new Tier(4, "", 8, 80, false));
			time.Add(new Tier(5, "", 16, 160, false));

			pizzas.Add(new Tier(0, "Starting Pizzas", 0, 0, true));
			pizzas.Add(new Tier(1, "", 1, 10, false));
			pizzas.Add(new Tier(2, "", 2, 20, false));
			pizzas.Add(new Tier(3, "", 4, 40, false));
			pizzas.Add(new Tier(4, "", 8, 80, false));
			pizzas.Add(new Tier(5, "", 16, 160, false));
			
			// Sets current tier level to the first (level 0) tier
			currentTitle = title.Head;
			currentMount = mount.Head;
			currentTimeBonus = time.Head;
			currentPizzaBonus = pizzas.Head;
		}

		public void Buy(TierList list)
		{
			switch(list.Type)
			{
				case ShopListType.Title:
					currentTitle = currentTitle.Next;
					break;
				case ShopListType.Mount:
					currentMount = currentMount.Next;
					break;
				case ShopListType.Time:
					currentTimeBonus = currentTimeBonus.Next;
					break;
				case ShopListType.Pizzas:
					currentPizzaBonus = currentPizzaBonus.Next;
					break;
			}
		}
	}
}
