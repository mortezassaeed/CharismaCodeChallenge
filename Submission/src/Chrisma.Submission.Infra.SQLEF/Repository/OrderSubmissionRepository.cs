using Charisma.Submission.Domain.SubmissionAggregate;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Submission.Infra.SQLEF.Repository;

internal class OrderSubmissionRepository : IOrderSubmissionRepository
{
	private readonly IDbContextFactory<SubmissionDbContext> _dbFactory;

	public OrderSubmissionRepository(IDbContextFactory<SubmissionDbContext> dbFactory)
	{
		_dbFactory = dbFactory;
	}

	public async Task<int> CreateAsync(OrderSubmission entity)
	{
		using var db = _dbFactory.CreateDbContext();	
		await db.AddAsync(entity);
		await db.SaveChangesAsync();
		return entity.Id;
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<OrderSubmission>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<OrderSubmission?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(OrderSubmission entity)
	{
		throw new NotImplementedException();
	}
}
