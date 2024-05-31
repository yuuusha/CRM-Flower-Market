using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class ClientDal : BaseDal<DefaultDbContext, Client, Entities.Client, int, ClientSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public ClientDal()
		{
		}

		protected internal ClientDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Client entity, Client dbObject, bool exists)
		{
			dbObject.LastName = entity.LastName;
			dbObject.FirstName = entity.FirstName;
			dbObject.MiddleName = entity.MiddleName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.ClientAddress = entity.ClientAddress;
			dbObject.PhoneNumber = entity.PhoneNumber;
			dbObject.Email = entity.Email;
			dbObject.Discount = entity.Discount;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Client>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Client> dbObjects, ClientSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Client>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Client> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Client, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Client, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Client ConvertDbObjectToEntity(Client dbObject)
		{
			return dbObject == null ? null : new Entities.Client(dbObject.Id, dbObject.LastName, dbObject.FirstName,
				dbObject.MiddleName, dbObject.DateOfBirth, dbObject.ClientAddress, dbObject.PhoneNumber,
				dbObject.Email, dbObject.Discount);
		}
	}
}
