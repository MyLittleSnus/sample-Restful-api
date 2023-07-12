using GoodsApi.Context;
using GoodsApi.Models;
using GoodsApi.Repositories;

namespace GoodsApi.Infrustructure;

public interface IGenerator
{
	Task Generate();
}

public abstract class Generator<TEntity> where TEntity : BaseEntity
{
	protected BaseRepo<TEntity> _repo;

	public Generator(BaseRepo<TEntity> repo) => _repo = repo;
}

public class GoodGenerator : Generator<Good>, IGenerator
{
    public GoodGenerator(BaseRepo<Good> repo) : base(repo) { }

    public async Task Generate()
    {
		var genEnv = Environment.GetEnvironmentVariable("GENERATOR");

        if (genEnv != null && genEnv.ToLower() == "off")
			return;

            var tasks = new List<Task>() {
			_repo.Create(new Good() { Id = Guid.NewGuid().ToString(), Name = "TV LG 520", Category  = 0, Cost = 20000}),
			_repo.Create(new Good() { Id = Guid.NewGuid().ToString(), Name = "IPhone 11", Category  = 0, Cost = 18000}),
			_repo.Create(new Good() { Id = Guid.NewGuid().ToString(), Name = "MacBook Air M1", Category  = 0, Cost = 30000}),
			_repo.Create(new Good() { Id = Guid.NewGuid().ToString(), Name = "MacBook Air M2", Category  = 0, Cost = 45000}),
			_repo.Create(new Good() { Id = Guid.NewGuid().ToString(), Name = "Samsumg S20 Ultra", Category  = 0, Cost = 25000})
		};

		await Task.WhenAll(tasks);
	}
}

public enum GeneratorType
{
	GoodsGenerator,
	OrdersGenerator
}

public class Generators
{
	private ShopContext _context;

	public Generators(ShopContext context) => _context = context;

	public IGenerator CreateGenerator(GeneratorType type)
	{
		switch (type)
		{
			case GeneratorType.GoodsGenerator:
				return new GoodGenerator(new BaseRepo<Good>(_context));
		}

		return null;
	}
}