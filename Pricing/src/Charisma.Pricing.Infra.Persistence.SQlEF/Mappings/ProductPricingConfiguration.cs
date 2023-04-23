using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Domain.PricingAggregate;
using Charisma.Pricing.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Infra.Persistence.SQlEF.Mappings;

internal class ProductPricingConfiguration : IEntityTypeConfiguration<ProductPricing>
{
	public void Configure(EntityTypeBuilder<ProductPricing> builder)
	{
		builder.HasKey("Id");
		builder.ToTable("ProductPricing");

		builder.OwnsOne(m => m.ActualPrice, b =>
		{
			b.Property(m => m.Value).HasColumnName("Actual_Price_Amount");
			b.Property(m => m.CurrencyType).HasColumnName("Actual_Price_CurrencyType").HasConversion(
				v => v.ToString(),
				v => (CurrencyType)Enum.Parse(typeof(CurrencyType), v)).HasMaxLength(10);
		});
		builder.OwnsOne(m => m.FinalPrice, b =>
		{
			b.Property(m => m.Value).HasColumnName("Final_Price_Amount");
			b.Property(m => m.CurrencyType).HasColumnName("Final_Price_CurrencyType").HasConversion(
				v => v.ToString(),
				v => (CurrencyType)Enum.Parse(typeof(CurrencyType), v)).HasMaxLength(10);
		});
	}
}
