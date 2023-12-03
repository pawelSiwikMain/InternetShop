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
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int QuqntityInCart { get; set; }
        public string UrlToOffer { get; set; }

        public ShopCart()
        {
        }

        public ShopCart(int id, int userId, int productId, string name, float price, int quqntityInCart, string urlToOffer)
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
