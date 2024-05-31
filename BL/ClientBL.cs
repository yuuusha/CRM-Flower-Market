using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Client = Entities.Client;

namespace BL
{
	public class ClientBL
	{
		public async Task<int> AddOrUpdateAsync(Client entity)
		{
			entity.Id = await new ClientDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new ClientDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(ClientSearchParams searchParams)
		{
			return new ClientDal().ExistsAsync(searchParams);
		}

		public Task<Client> GetAsync(int id)
		{
			return new ClientDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new ClientDal().DeleteAsync(id);
		}

		public Task<SearchResult<Client>> GetAsync(ClientSearchParams searchParams)
		{
			return new ClientDal().GetAsync(searchParams);
		}
	}
}

