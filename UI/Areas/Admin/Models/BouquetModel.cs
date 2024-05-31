using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BouquetModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		public double? Price { get; set; }

		public static BouquetModel FromEntity(Bouquet obj)
		{
			return obj == null ? null : new BouquetModel
			{
				Id = obj.Id,
				Name = obj.Name,
				Price = obj.Price,
			};
		}

		public static Bouquet ToEntity(BouquetModel obj)
		{
			return obj == null ? null : new Bouquet(obj.Id, obj.Name, obj.Price);
		}

		public static List<BouquetModel> FromEntitiesList(IEnumerable<Bouquet> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Bouquet> ToEntitiesList(IEnumerable<BouquetModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
