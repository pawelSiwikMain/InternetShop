using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int QuqntityInStorage { get; set; }
        public string UrlToPicture { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string description, string category, float price, int quqntityInStorage, string urlToPicture)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            QuqntityInStorage = quqntityInStorage;
            UrlToPicture = urlToPicture;
        }
    }
}
