using Charisma.Submission.Domain.ProductAggregate;
using Charisma.Submission.Domain.SubmissionAggregate;
using Charisma.Submission.Infra.SQLEF.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Submission.Infra.SQLEF;

public static class ServiceExtension
{
	public static void UseSubmissionEFDataAccess(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContextFactory<SubmissionDbContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("Default")
			));
		services.AddSingleton<IProductRepository, ProductRepository>();
		services.AddSingleton<IOrderSubmissionRepository, OrderSubmissionRepository>();
	}
}
