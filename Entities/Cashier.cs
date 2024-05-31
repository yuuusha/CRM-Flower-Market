using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Cashier
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string PhoneNumber { get; set; }
		public int? Experience { get; set; }

		public Cashier(int id, string lastName, string firstName, string middleName, DateTime? dateOfBirth,
			string phoneNumber, int? experience)
		{
			Id = id;
			LastName = lastName;
			FirstName = firstName;
			MiddleName = middleName;
			DateOfBirth = dateOfBirth;
			PhoneNumber = phoneNumber;
			Experience = experience;
		}
	}
}
