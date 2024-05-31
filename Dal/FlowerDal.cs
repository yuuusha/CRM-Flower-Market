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
	public class FlowerDal : BaseDal<DefaultDbContext, Flower, Entities.Flower, int, FlowerSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public FlowerDal()
		{
		}

		protected internal FlowerDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Flower entity, Flower dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.Price = entity.Price;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Flower>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Flower> dbObjects, FlowerSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Flower>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Flower> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Flower, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Flower, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Flower ConvertDbObjectToEntity(Flower dbObject)
		{
			return dbObject == null ? null : new Entities.Flower(dbObject.Id, dbObject.Name, dbObject.Price);
		}
	}
}
