namespace burgerbuddy
{
  public class Burger: Item
  {
    public FoodSize Size;

    public Burger(FoodSize size)
    {
      Size = size;
    }
    public override void CalculatePrice()
    {
      Price = (int)Size * 25 + 30;
    }
  }
}
