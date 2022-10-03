using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace burgerbuddy
{
  internal class Program
  {
    private static List<Order> _orders = new List<Order>();
    private static int _availableBirdmanToy = 50;
    private static int _mrDOrderNumber = 10000;
    private static int _posOrderNumber = 1;
    private static OrderBuilder _orderBuilder;

    private static List<Order> _rejectedOrders = new List<Order>();
    private static bool _rejected = false;
    private static int _customers;

    private static void AddItemToOrder(int item)
    {
      switch (item)
      {
        case 0:
         
          var rnd = new Random();
          var randomSize = rnd.Next(0, 3);

          var burger = new Burger((FoodSize)randomSize)
          {
            Name = "Cheese Burger",
            Description = "Nice burger with cheese and extra sauces.",
          };
          burger.CalculatePrice();
          _orderBuilder.AddBurger(burger);
          break;

        case 1:
          rnd = new Random();
          randomSize = rnd.Next(0, 2);

          var soda = new Drink((DrinkSize)randomSize)
          {
            Name = "Soda",
            Description = "Very cold soda.",
          };
          soda.CalculatePrice();
          _orderBuilder.AddSoda(soda);
          break;

        case 2:
          rnd = new Random();
          randomSize = rnd.Next(0, 3);

          var chips = new Chips((FoodSize)randomSize)
          {
            Name = "Spicy Chips",
            Description = "Nice spicy chips.",
          };
          chips.CalculatePrice();
          _orderBuilder.AddChips(chips);
          break;

        case 3:
          rnd = new Random();
          randomSize = rnd.Next(0, 3);

          var smileyMeal = new SmileyMeal((FoodSize)randomSize)
          {
            Name = "Smiley Meal",
            Description = "Nice Smiley Meal with a Birdman Toy",
            BirdmanToy = 1
          };
          smileyMeal.CalculatePrice();
          _orderBuilder.AddSmileyMeal(smileyMeal);
          if (_availableBirdmanToy <= 0)
          {
            _rejected = true;
          }
          else
          {
            _availableBirdmanToy--;
          }

          break;

        default: break;
      }
    }
    private static int GenerateOrderNumber(int customerType)
    {
      return customerType == 1 ? _mrDOrderNumber++ : _posOrderNumber++;
    }
    private static void GenerateRandomOrders()
    {
      var rnd = new Random();
       _customers = rnd.Next(1, 5);
       
      for (var i = 0; i < _customers; i++)
      {

        //New oder builder
        _orderBuilder = new OrderBuilder();

        //Select customer type. 0 - Pos and 1 - Mr D.
        rnd = new Random();
        var customerType = rnd.Next(0, 2);

        //Generate order number
        var orderNumber = GenerateOrderNumber(customerType);

        //Time of creation
        var time = DateTime.UtcNow;


        //Select number of items to be added to the order
        rnd = new Random();
        var numberOfItems = rnd.Next(1, 5);

        for (var j = 0; j < numberOfItems; j++)
        {
          //Random item
          rnd = new Random();
          var item = rnd.Next(1, 5);
          AddItemToOrder(item);
        }

        _orderBuilder.SetCustomerType((CustomerType)customerType);
        _orderBuilder.SetOrderNumber(orderNumber);
        _orderBuilder.SetTimeCreated(time);

        if (_rejected)
        {
          _rejectedOrders.Add(_orderBuilder.Build());
          _rejected = false;
          continue;
        }
        //_orders.Add(_orderBuilder.Build());
        CollectOrders(_orderBuilder.Build());

      }
    }
    static void Main(string[] args)
    {
      GenerateRandomOrders();
      //CollectOrders();
      //PrintRejectedOrders();
    }
    private static void CollectOrders(Order order)
    {
      //var customers = _orders.Count;
      //foreach (var order in _orders)
      //{

      //await Task.Run(() =>
      //{
        Console.WriteLine($"\nWaiting customers: {_customers--}");
        Thread.Sleep(10000);
       
        Console.WriteLine($"\nReady for collection...");
        order.CollectedAt = DateTime.UtcNow;
        Console.WriteLine($"Order number: {order.Number} \nCustomer type: {order.CustomerType} \nCreated At: {order.CreatedAt} \nCollected At: {order.CollectedAt}");
        Console.WriteLine("----------------Items-----------------------------");
        foreach (var item in order.Items)
        {
          Console.WriteLine($"Name: {item.Name}, Price: {item.GetPrice()}");
        }
        Console.WriteLine("--------------------------------------------------");
        //_orders.Remove(order);
      //});
        
      //}
    }
    private static void PrintRejectedOrders()
    {
      if(_rejectedOrders.Count == 0)
        return;

      Console.WriteLine("The following orders were rejected due to the shortage of Birdman Toys:");
      foreach (var order in _rejectedOrders)
      { 
        Console.WriteLine($"\nOrder number: {order.Number} \nCreated At: {order.CreatedAt} \nCustomer type: {order.CustomerType}");
        Console.WriteLine("----------------Items-----------------------------");
        foreach (var item in order.Items)
        {
          Console.WriteLine($"Name: {item.Name}, Price: {item.GetPrice()}");
        }
        Console.WriteLine("--------------------------------------------------");
      }
    }
  }
}
