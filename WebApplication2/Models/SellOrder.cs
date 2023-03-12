using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class SellOrder
{
    public int Id { get; set; }

    public string? OrderDate { get; set; }

    public double? DiscountValue { get; set; }

    public double? DiscountPrecentage { get; set; }

    public double? BeforDiscountTotal { get; set; }

    public double? AfterDiscount { get; set; }
}
