using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BouquetFlower
{
    public int Id { get; set; }

    public int BouquetId { get; set; }

    public int FlowerId { get; set; }

    public int? Quantity { get; set; }

    public virtual Bouquet Bouquet { get; set; }

    public virtual Flower Flower { get; set; }
}
