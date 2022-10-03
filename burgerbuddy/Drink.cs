using System.Drawing;

namespace burgerbuddy
{
  public class Drink: Item
  {
    public DrinkSize Size;
    public Drink(DrinkSize size)
    {
      Size = size;
    }
    public override void CalculatePrice()
    {
      Price = (int)Size * 15 + 15;
    }
  }
}
