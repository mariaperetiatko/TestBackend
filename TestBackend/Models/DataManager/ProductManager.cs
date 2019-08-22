using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestBackend.Models.Repository;

namespace TestBackend.Models.DataManager
{
    public class ProductManager : IDataRepository<Product>
    {
        readonly TestContext testContext;
        private bool disposed = false;


        public ProductManager(TestContext context)
        {
            testContext = context;
        }

        public IEnumerable<Product> GetEntitySet()
        {
            return testContext.Products;
        }

        public Product GetEntity(object key)
        {
            return testContext.Products.SingleOrDefault(x => x.Id == (long)key);
        }

        public void Create(Product product)
        {
            testContext.Products.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            testContext.Entry(product).State = EntityState.Modified;

            Save();
        }

        public void Delete(Product product)
        {
            if (product != null)
                testContext.Products.Remove(product);

            Save();
        }

        public void Save()
        {
            testContext.SaveChanges();
        }

        public IEnumerable<Product> SearchByField(object name)
        {
            string productName = name as string;
            return testContext.Products.Where(x => x.Name == productName);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    testContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
