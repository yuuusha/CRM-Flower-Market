using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Bouquet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double? Price { get; set; }

		public Bouquet(int id, string name, double? price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
	}
}
