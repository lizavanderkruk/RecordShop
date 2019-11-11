using RecordShop.Models;
using RecordShopClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Repositories
{
    public class ProductenRepository : IProductenRepository
    {
        private readonly RecordshopContext context;

        public ProductenRepository(RecordshopContext context)
        {
            this.context = context;
        }
        public List<ProductenModel> GetAllProducts()
        {
            var productenLijst = new List<ProductenModel>();

            foreach (var product in context.Productens)
            {
                productenLijst.Add(new ProductenModel
                {
                    ProductID = product.ProductId,
                    Naam = product.Naam,
                    ReleaseDate = product.ReleaseDate,
                    Artiest = product.Artiest,
                    Genre = product.Genre,
                    Prijs = product.Price,
                    Populair = product.Populair
                });
            }
            return productenLijst;
        }
        
        public ProductenModel GetOneProduct(int productID)
        {
            var dbcontext = context.Productens.Single(p => p.ProductId == productID);
            return new ProductenModel
            {
                ProductID = dbcontext.ProductId,
                Naam = dbcontext.Naam,
                ReleaseDate = dbcontext.ReleaseDate,
                Artiest = dbcontext.Artiest,
                Genre = dbcontext.Genre,
                Prijs = dbcontext.Price,
                Populair = dbcontext.Populair
            };
        }

        public void AddNieuwProduct(ProductenModel productModel)
        {
            context.Productens.Add(new RecordShopClassLibrary.Producten
            {
                ProductId = productModel.ProductID,
                Naam = productModel.Naam,
                ReleaseDate = productModel.ReleaseDate,
                Artiest = productModel.Artiest,
                Genre = productModel.Genre,
                Price = productModel.Prijs,
                Populair = productModel.Populair
            });
            context.SaveChanges();
        }

        public void UpdateProduct(ProductenModel productModel)
        {
            var entity = context.Productens.Single(p => p.ProductId == productModel.ProductID);

            entity.ProductId = productModel.ProductID;
            entity.Naam = productModel.Naam;
            entity.ReleaseDate = productModel.ReleaseDate;
            entity.Artiest = productModel.Artiest;
            entity.Genre = productModel.Genre;
            entity.Price = productModel.Prijs;
            entity.Populair = productModel.Populair;

            context.SaveChanges();
        }

        public void DeleteProduct(int productID)
        {
            var entity = context.Productens.Single(p => p.ProductId == productID);
            context.Productens.Remove(entity);
            context.SaveChanges();
        }
        
    }
}
