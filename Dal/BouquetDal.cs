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
	public class BouquetDal : BaseDal<DefaultDbContext, Bouquet, Entities.Bouquet, int, BouquetSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BouquetDal()
		{
		}

		protected internal BouquetDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Bouquet entity, Bouquet dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.Price = entity.Price;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Bouquet>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Bouquet> dbObjects, BouquetSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Bouquet>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Bouquet> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Bouquet, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Bouquet, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Bouquet ConvertDbObjectToEntity(Bouquet dbObject)
		{
			return dbObject == null ? null : new Entities.Bouquet(dbObject.Id, dbObject.Name, dbObject.Price);
		}
	}
}
