using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CashierModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Display(Name = "MiddleName")]
		public string MiddleName { get; set; }

		[Display(Name = "DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Experience")]
		public int? Experience { get; set; }

		public static CashierModel FromEntity(Cashier obj)
		{
			return obj == null ? null : new CashierModel
			{
				Id = obj.Id,
				LastName = obj.LastName,
				FirstName = obj.FirstName,
				MiddleName = obj.MiddleName,
				DateOfBirth = obj.DateOfBirth,
				PhoneNumber = obj.PhoneNumber,
				Experience = obj.Experience,
			};
		}

		public static Cashier ToEntity(CashierModel obj)
		{
			return obj == null ? null : new Cashier(obj.Id, obj.LastName, obj.FirstName, obj.MiddleName,
				obj.DateOfBirth, obj.PhoneNumber, obj.Experience);
		}

		public static List<CashierModel> FromEntitiesList(IEnumerable<Cashier> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Cashier> ToEntitiesList(IEnumerable<CashierModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
