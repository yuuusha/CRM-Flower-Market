﻿using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Cashier
{
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public int? Experience { get; set; }
}
