using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Flower
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<BouquetFlower> BouquetFlowers { get; set; } = new List<BouquetFlower>();
}
