namespace burgerbuddy
{
  public class Chips: Item
  {
    public FoodSize Size { get; set; }
    public Chips(FoodSize size)
    {
      Size = size;
    }
    public override void CalculatePrice()
    {
      Price = (int)Size * 15 + 20;
    }
  }
}
