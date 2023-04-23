using Charisma.Submission.Domain.SubmissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charisma.Submission.Infra.SQLEF.Mappings;

internal class OrderSubmissionConfiguration : IEntityTypeConfiguration<OrderSubmission>
{
	public void Configure(EntityTypeBuilder<OrderSubmission> builder)
	{
		builder.ToTable("OrderSubmission");
		builder.HasKey(x  => x.Id);

		builder.Property(m => m.SubmissionType).HasConversion(
				v => v.ToString(),
				v => (SubmissionType)Enum.Parse(typeof(SubmissionType), v)).HasMaxLength(20);
	}
}
