using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class BuyOrder
{
    public int Id { get; set; }

    public string? OrderDate { get; set; }

    public double? BeforDiscountTotal { get; set; }

    public double? AfterDiscount { get; set; }

    public double? DiscountPercent { get; set; }

    public int? DiscountValue { get; set; }

    public int? CostumerId { get; set; }

    public int? EmplyeeId { get; set; }
}
