using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceCalculationTest.TestDoubles;

public class ProductRepositoryStab : IProductRepository
{
    private readonly Price confinablePriceAmount;
    public ProductRepositoryStab(decimal priceAmount)
    {
        confinablePriceAmount = new Price(priceAmount);
    }

    public Task<int> CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetAync(string code)
    {
        return await Task.FromResult(
            new Product(code) { Id = 0, BasePrice = confinablePriceAmount }
        );
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
