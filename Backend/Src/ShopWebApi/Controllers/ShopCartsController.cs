﻿using Application.Dtos.ShopCartDtos;
using Application.Interfaces.DataService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartsController : ControllerBase
    {
        IShopCartService _shopCartService;

        public ShopCartsController(IShopCartService shopCartService)
        {
            _shopCartService = shopCartService;
        }
        [HttpGet("userId/{id}")]
        public IActionResult GetAllForUser(int id) 
        { 
            var shopCarts = _shopCartService.GetShopCartsForUser(id);
            return Ok(shopCarts);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var shopCart = _shopCartService.GetByIdShopCart(id);
            return Ok(shopCart);
        }
        [HttpPost]
        public IActionResult Create(CreateShopCartDto shopCart)
        {
            var resoult = _shopCartService.AddShopCart(shopCart);
            return Created($"api/shopcarts/{resoult.Id}", resoult);
        }
        [HttpPut]
        public IActionResult Update(UpdateShopCartDto shopCart) 
        { 
            _shopCartService.UpdateShopCart(shopCart);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _shopCartService.DeleteShopCart(id);
            return NoContent();
        }
    }
}
