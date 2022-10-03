namespace burgerbuddy
{
  public class Item
  {
    public string Name { get; set; }
    public string Description { get; set; }
    protected double Price;

    public virtual void CalculatePrice()
    {
      Price = 0;
    }

    public double GetPrice()
    {
      return Price;
    }
  }
}
