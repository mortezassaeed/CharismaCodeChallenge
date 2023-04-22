using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Order.Domain.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charisma.Infrastructure.Persistence.SQLEF.Mappings;

internal class CartConfiguration : IEntityTypeConfiguration<Cart>
{
	public void Configure(EntityTypeBuilder<Cart> builder)
	{
		builder.ToTable("Carts")
			.HasKey(m => m.Id);

		builder.Property(m => m.Id)
			.HasColumnName("Id")
			//.ValueGeneratedNever()
			//.HasConversion(
			//	id => id.Value,
			//	value => CartId.CreateWith(value)
			//)
			;

		builder.OwnsMany(m => m.CartItems, b =>
		{
			b.ToTable("CartItems");
			b.HasKey("Id");
			b.WithOwner().HasForeignKey("CardId");
			b.OwnsOne(m => m.Price, b =>
			{
				b.Property(m => m.Value).HasColumnName("Price_Amount");
				b.Property(m => m.CurrencyType).HasColumnName("Price_CurrencyType").HasConversion(
					v => v.ToString(),
					v => (CurrencyType)Enum.Parse(typeof(CurrencyType), v)).HasMaxLength(10);
			});
		});
	}
}


