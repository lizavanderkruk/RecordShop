using RecordShop.Models;
using RecordShopClassLibrary;
using System.Collections.Generic;

namespace RecordShop.Repositories
{
    public interface IProductenRepository
    {
        public List<ProductenModel> GetAllProducts();
        public ProductenModel GetOneProduct(int productID);
        public void AddNieuwProduct(ProductenModel productModel);
        public void UpdateProduct(ProductenModel productModel);
        public void DeleteProduct(int productID);
    }

    
}