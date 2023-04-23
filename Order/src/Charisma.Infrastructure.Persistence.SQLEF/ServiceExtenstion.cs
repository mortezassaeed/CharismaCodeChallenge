using Charisma.Infrastructure.Persistence.SQLEF.Repository;
using Charisma.Order.Domain.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Infrastructure.Persistence.SQLEF;

public static class ServiceExtension
{
	public static void UseOrderEFDataAccess(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContextFactory<OrderDbContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("Default")
			)) ;
		services.AddSingleton<ICartRepository, CartRepository>();
		services.AddSingleton<IProductRepository, ProductRepository>();
	}
}
