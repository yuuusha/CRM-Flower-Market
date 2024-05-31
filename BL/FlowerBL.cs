using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Flower = Entities.Flower;

namespace BL
{
	public class FlowerBL
	{
		public async Task<int> AddOrUpdateAsync(Flower entity)
		{
			entity.Id = await new FlowerDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new FlowerDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(FlowerSearchParams searchParams)
		{
			return new FlowerDal().ExistsAsync(searchParams);
		}

		public Task<Flower> GetAsync(int id)
		{
			return new FlowerDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new FlowerDal().DeleteAsync(id);
		}

		public Task<SearchResult<Flower>> GetAsync(FlowerSearchParams searchParams)
		{
			return new FlowerDal().GetAsync(searchParams);
		}
	}
}

