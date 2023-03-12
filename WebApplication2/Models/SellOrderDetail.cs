using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class SellOrderDetail
{
    public int Id { get; set; }

    public double? Quentite { get; set; }

    public DateTime? ItemTotal { get; set; }

    public int? ProdectId { get; set; }

    public int? SorderId { get; set; }
}
