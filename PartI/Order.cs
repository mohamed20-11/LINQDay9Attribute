using System;
using System.Collections.Generic;

namespace PartI;

[Serializable]
public partial class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public virtual Customer Customer { get; set; } = null!;
}
