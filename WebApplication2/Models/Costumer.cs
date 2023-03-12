using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Costumer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NumberPhone { get; set; }

    public int? CityId { get; set; }
}
