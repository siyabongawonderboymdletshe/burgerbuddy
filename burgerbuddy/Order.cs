using System;
using System.Collections.Generic;

namespace burgerbuddy
{
  public class Order
  {
    public int Number { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime CollectedAt { get; set; }
    public CustomerType CustomerType { get; set; }

    public List<Item> Items { get; set; } = new List<Item>();


  }
}
