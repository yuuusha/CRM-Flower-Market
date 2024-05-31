using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Client
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string ClientAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public double? Discount { get; set; }

		public Client(int id, string lastName, string firstName, string middleName, DateTime? dateOfBirth,
			string clientAddress, string phoneNumber, string email, double? discount)
		{
			Id = id;
			LastName = lastName;
			FirstName = firstName;
			MiddleName = middleName;
			DateOfBirth = dateOfBirth;
			ClientAddress = clientAddress;
			PhoneNumber = phoneNumber;
			Email = email;
			Discount = discount;
		}
	}
}
