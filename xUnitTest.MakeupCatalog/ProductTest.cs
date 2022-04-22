using System;
using System.Collections.Generic;
using Domain.MakeupCatalog;
using Infrastructure.MakeupCatalog;
using MakeupCatalog.Controllers;
using Microsoft.EntityFrameworkCore;
using Repository.MakeupCatalog;
using Xunit;

namespace xUnitTest.MakeupCatalog
{
    public class ProductTest
    {
        private readonly IRepository<Product> _product;
        //private readonly IProductRepository _product;
        private readonly MakeupDbContext _dbContext;

        //public RepositoryTests()
        //{
        //    var options = new DbContextOptionsBuilder<MakeupDbContext>()
        //        .UseInMemoryDatabase(databaseName: "MakeupkDbMock")
        //        .Options;

        //    _dbContext = new MakeupDbContext(options);
        //    _dbContext.Product.Add(new Product{ProductId = 1, Name = "Lipstick", Color = "Pink"});

        //    _product = new Repository<Product>(_dbContext);
        //}

        [Fact]
        public void GetProductsTest()
        {
            var GetProduct = _product.Get();

            Assert.NotNull(GetProduct);
        }
    }
}
