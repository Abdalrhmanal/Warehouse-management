using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class BuyOrderDetail
{
    public int Id { get; set; }

    public double? Quentite { get; set; }

    public double? ItemTotal { get; set; }

    public int? PruductId { get; set; }

    public int? BorderId { get; set; }
}
