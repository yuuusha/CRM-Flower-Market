using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ClientModel
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

		[Display(Name = "ClientAddress")]
		public string ClientAddress { get; set; }

		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Discount")]
		public double? Discount { get; set; }

		public static ClientModel FromEntity(Client obj)
		{
			return obj == null ? null : new ClientModel
			{
				Id = obj.Id,
				LastName = obj.LastName,
				FirstName = obj.FirstName,
				MiddleName = obj.MiddleName,
				DateOfBirth = obj.DateOfBirth,
				ClientAddress = obj.ClientAddress,
				PhoneNumber = obj.PhoneNumber,
				Email = obj.Email,
				Discount = obj.Discount,
			};
		}

		public static Client ToEntity(ClientModel obj)
		{
			return obj == null ? null : new Client(obj.Id, obj.LastName, obj.FirstName, obj.MiddleName,
				obj.DateOfBirth, obj.ClientAddress, obj.PhoneNumber, obj.Email, obj.Discount);
		}

		public static List<ClientModel> FromEntitiesList(IEnumerable<Client> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Client> ToEntitiesList(IEnumerable<ClientModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
