using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IDataService
    {
        IAddressService AddressService { get; }
        IProductService ProductService { get; }
        IShopCartService ShopCartService { get; }
        IUserService UserService { get; }
    }
}
