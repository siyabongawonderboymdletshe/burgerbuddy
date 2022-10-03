using System.Drawing;

namespace burgerbuddy
{
  public class SmileyMeal: Item
  {
    public FoodSize Size;
    public int BirdmanToy { get; set; }

    public SmileyMeal(FoodSize size)
    {
      Size = size;
    }
    public override void CalculatePrice()
    {
      Price = (int)Size * 25 + 25;
    }
  }
}
