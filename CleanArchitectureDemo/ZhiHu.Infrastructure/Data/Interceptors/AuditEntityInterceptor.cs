﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZhiHu.Core.Common;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.Infrastructure.Data.Interceptors
{
    public class AuditEntityInterceptor(IUser currentUser) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditEntity>())
            {
                if (entry.State is not (EntityState.Added or EntityState.Modified)) continue;

                var now = DateTimeOffset.Now;

                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = now;
                else
                    entry.Entity.LastModifiedAt = now;
            }

            foreach (var entry in context.ChangeTracker.Entries<AuditWithUserEntity>())
            {
                if (entry.State is not (EntityState.Added or EntityState.Modified)) continue;

                if (currentUser.Id is null) continue;

                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedBy =currentUser.Id.Value;
                else
                    entry.Entity.LastModifiedBy =currentUser.Id.Value;
            }
        }
    }
}
