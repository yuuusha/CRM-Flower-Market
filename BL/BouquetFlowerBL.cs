using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using BouquetFlower = Entities.BouquetFlower;

namespace BL
{
	public class BouquetFlowerBL
	{
		public async Task<int> AddOrUpdateAsync(BouquetFlower entity)
		{
			entity.Id = await new BouquetFlowerDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BouquetFlowerDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BouquetFlowerSearchParams searchParams)
		{
			return new BouquetFlowerDal().ExistsAsync(searchParams);
		}

		public Task<BouquetFlower> GetAsync(int id)
		{
			return new BouquetFlowerDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BouquetFlowerDal().DeleteAsync(id);
		}

		public Task<SearchResult<BouquetFlower>> GetAsync(BouquetFlowerSearchParams searchParams)
		{
			return new BouquetFlowerDal().GetAsync(searchParams);
		}
	}
}

