using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Cashier = Entities.Cashier;

namespace BL
{
	public class CashierBL
	{
		public async Task<int> AddOrUpdateAsync(Cashier entity)
		{
			entity.Id = await new CashierDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new CashierDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(CashierSearchParams searchParams)
		{
			return new CashierDal().ExistsAsync(searchParams);
		}

		public Task<Cashier> GetAsync(int id)
		{
			return new CashierDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new CashierDal().DeleteAsync(id);
		}

		public Task<SearchResult<Cashier>> GetAsync(CashierSearchParams searchParams)
		{
			return new CashierDal().GetAsync(searchParams);
		}
	}
}

