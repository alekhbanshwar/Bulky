using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFormDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFormDb != null)
            {
                objFormDb.Title = product.Title;
                objFormDb.ISBN = product.ISBN;
                objFormDb.Price = product.Price;
                objFormDb.Price50 = product.Price50;
                objFormDb.ListPrice = product.ListPrice;
                objFormDb.Price100 = product.Price100;
                objFormDb.Description = product.Description;
                objFormDb.CategoryId = product.CategoryId;
                objFormDb.Author = product.Author;
                if(product.ImageUrl != null)
                {
                    objFormDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
