using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Bouquet = Entities.Bouquet;

namespace BL
{
	public class BouquetBL
	{
		public async Task<int> AddOrUpdateAsync(Bouquet entity)
		{
			entity.Id = await new BouquetDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BouquetDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BouquetSearchParams searchParams)
		{
			return new BouquetDal().ExistsAsync(searchParams);
		}

		public Task<Bouquet> GetAsync(int id)
		{
			return new BouquetDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BouquetDal().DeleteAsync(id);
		}

		public Task<SearchResult<Bouquet>> GetAsync(BouquetSearchParams searchParams)
		{
			return new BouquetDal().GetAsync(searchParams);
		}
	}
}

