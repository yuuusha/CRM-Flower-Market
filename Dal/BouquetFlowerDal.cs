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
	public class BouquetFlowerDal : BaseDal<DefaultDbContext, BouquetFlower, Entities.BouquetFlower, int, BouquetFlowerSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BouquetFlowerDal()
		{
		}

		protected internal BouquetFlowerDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.BouquetFlower entity, BouquetFlower dbObject, bool exists)
		{
			dbObject.BouquetId = entity.BouquetId;
			dbObject.FlowerId = entity.FlowerId;
			dbObject.Quantity = entity.Quantity;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<BouquetFlower>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<BouquetFlower> dbObjects, BouquetFlowerSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.BouquetFlower>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<BouquetFlower> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<BouquetFlower, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.BouquetFlower, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.BouquetFlower ConvertDbObjectToEntity(BouquetFlower dbObject)
		{
			return dbObject == null ? null : new Entities.BouquetFlower(dbObject.Id, dbObject.BouquetId,
				dbObject.FlowerId, dbObject.Quantity);
		}
	}
}
