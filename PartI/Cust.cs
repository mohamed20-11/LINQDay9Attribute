using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartI;

[Table("cust")]
[Serializable]
[AdditionalInfo("Data")]
[AdditionalInfo("Data")]

public partial class Customer
{
    [AdditionalInfo("Data")]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
