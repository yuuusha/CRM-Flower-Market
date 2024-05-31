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
	public class CashierDal : BaseDal<DefaultDbContext, Cashier, Entities.Cashier, int, CashierSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public CashierDal()
		{
		}

		protected internal CashierDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Cashier entity, Cashier dbObject, bool exists)
		{
			dbObject.LastName = entity.LastName;
			dbObject.FirstName = entity.FirstName;
			dbObject.MiddleName = entity.MiddleName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.PhoneNumber = entity.PhoneNumber;
			dbObject.Experience = entity.Experience;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Cashier>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Cashier> dbObjects, CashierSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Cashier>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Cashier> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Cashier, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Cashier, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Cashier ConvertDbObjectToEntity(Cashier dbObject)
		{
			return dbObject == null ? null : new Entities.Cashier(dbObject.Id, dbObject.LastName, dbObject.FirstName,
				dbObject.MiddleName, dbObject.DateOfBirth, dbObject.PhoneNumber, dbObject.Experience);
		}
	}
}
