using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class ShopCart
    {
        public string Id { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int QuqntityInCart { get; set; }
        public string UrlToOffer { get; set; }

        public ShopCart()
        {
        }

        public ShopCart(string id, string userId, string productId, string name, float price, int quqntityInCart, string urlToOffer)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Name = name;
            Price = price;
            QuqntityInCart = quqntityInCart;
            UrlToOffer = urlToOffer;
        }
    }
}
