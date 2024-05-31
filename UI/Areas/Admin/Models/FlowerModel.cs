using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class FlowerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		public double? Price { get; set; }

		public static FlowerModel FromEntity(Flower obj)
		{
			return obj == null ? null : new FlowerModel
			{
				Id = obj.Id,
				Name = obj.Name,
				Price = obj.Price,
			};
		}

		public static Flower ToEntity(FlowerModel obj)
		{
			return obj == null ? null : new Flower(obj.Id, obj.Name, obj.Price);
		}

		public static List<FlowerModel> FromEntitiesList(IEnumerable<Flower> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Flower> ToEntitiesList(IEnumerable<FlowerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
