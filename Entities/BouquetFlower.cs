using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class BouquetFlower
	{
		public int Id { get; set; }
		public int BouquetId { get; set; }
		public int FlowerId { get; set; }
		public int? Quantity { get; set; }

		public BouquetFlower(int id, int bouquetId, int flowerId, int? quantity)
		{
			Id = id;
			BouquetId = bouquetId;
			FlowerId = flowerId;
			Quantity = quantity;
		}
	}
}
