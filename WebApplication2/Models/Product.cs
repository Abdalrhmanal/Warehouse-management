using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public double? Discount { get; set; }

    public int? CountInStock { get; set; }

    public double? Expir { get; set; }

    public double? SellPrice { get; set; }

    public double? BuyPrice { get; set; }
}
