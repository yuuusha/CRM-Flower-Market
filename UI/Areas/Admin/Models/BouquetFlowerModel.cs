using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BouquetFlowerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "BouquetId")]
		public int BouquetId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "FlowerId")]
		public int FlowerId { get; set; }

		[Display(Name = "Quantity")]
		public int? Quantity { get; set; }

		public static BouquetFlowerModel FromEntity(BouquetFlower obj)
		{
			return obj == null ? null : new BouquetFlowerModel
			{
				Id = obj.Id,
				BouquetId = obj.BouquetId,
				FlowerId = obj.FlowerId,
				Quantity = obj.Quantity,
			};
		}

		public static BouquetFlower ToEntity(BouquetFlowerModel obj)
		{
			return obj == null ? null : new BouquetFlower(obj.Id, obj.BouquetId, obj.FlowerId, obj.Quantity);
		}

		public static List<BouquetFlowerModel> FromEntitiesList(IEnumerable<BouquetFlower> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<BouquetFlower> ToEntitiesList(IEnumerable<BouquetFlowerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
