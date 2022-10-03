
using System;

namespace burgerbuddy
{
  public class OrderBuilder
  {
    private readonly Order _order = new Order();
    public OrderBuilder AddBurger(Burger burger)
    {
      _order.Items.Add(burger);
      return this;
    }
    public OrderBuilder AddChips(Chips chips)
    {
      _order.Items.Add(chips);
      return this;
    }
    public OrderBuilder AddSoda(Drink soda)
    {
      _order.Items.Add(soda);
      return this;
    }
    public OrderBuilder AddSmileyMeal(SmileyMeal smileyMeal)
    {
      _order.Items.Add(smileyMeal);
      return this;
    }

    public OrderBuilder SetCustomerType(CustomerType customerType)
    {
      _order.CustomerType = customerType;
      return this;
    }
    public OrderBuilder SetTimeCreated(DateTime timeCreated)
    {
      _order.CreatedAt = timeCreated;
      return this;
    }
    public OrderBuilder SetTimeCollected(DateTime timeCollected)
    {
      _order.CollectedAt = timeCollected;
      return this;
    }
    public OrderBuilder SetOrderNumber(int number)
    {
      _order.Number = number;
      return this;
    }


    public Order Build() => _order;
  }
}
