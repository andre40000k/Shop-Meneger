﻿using Microsoft.EntityFrameworkCore;
using ShopMeneger.Application.Interfaces;
using ShopMeneger.Data.Context;
using ShopMeneger.Domain.Entityes;

namespace ShopMeneger.Data.Tests.Helpers
{
    public class DbContextDecorator<T> where T : ShopMenegerContext
    {
        private readonly DbContextOptions<T> _options;

        private T CreateDbContextInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), _options);
        }

        public DbContextDecorator(DbContextOptions<T> options)
        {
            _options = options;
        }

        public void AddAndSaveShop<TEntity>(TEntity entity, CancellationToken token) where TEntity : Shop
            => Using(CreateDbContextInstance(), async context =>
            {
                context.Shops.Add(entity);
                await context.SaveChangesAsync(token);
            });

        public void AddRangeAndSaveShop<TEntity>(TEntity entity, CancellationToken token) where TEntity : class
            => Using(CreateDbContextInstance(), async context =>
            {
                context.Shops.AddRange((IEnumerable<Shop>)entity);
                await context.SaveChangesAsync(token);
            });

        public void Assert(Action<T> assert)
            => Using(CreateDbContextInstance(), assert);

        public void Clear() => Using(CreateDbContextInstance(), context =>
        {
            context.Database.EnsureDeleted();
        });

        private static void Using<TDisposable>(TDisposable disposable, 
            Action<TDisposable> action) where TDisposable : IDisposable
        {
            using (disposable) 
                action(disposable);
        }
    }
}