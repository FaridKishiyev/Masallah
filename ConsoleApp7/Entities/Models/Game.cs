using System;
using System.Collections.Generic;
using System.Text;
using static Utils.Enums.Enums;

namespace Entities.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Platform Platform { get; set; }
        public double Price { get; set; }
        public double DisCountPercent { get; set; }
        public string Publisher { get; set; }
        public bool IsDeleted { get; set; }

        public Game(string name, int platform, double price)
        {
            Name = name;
            Platform = (Platform)platform;
            Price = price;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}\nName: {Name}\nPlatform: {Platform}\nPrice: {Price}\nDisCountPercent: {DisCountPercent}\nPublisher: {Publisher}\nIsDeleted: {IsDeleted}");
        }

        public double GetDisCountedPrice(double DisCountPercent)
        {
            return Price-Price * (DisCountPercent / 100);
        }
    }
}
