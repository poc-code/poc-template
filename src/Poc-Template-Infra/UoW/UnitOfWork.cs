using Microsoft.EntityFrameworkCore.Storage;
using Poc_Template_Domain.Interfaces.Services;
using Poc_Template_Infra.Context;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Poc_Template_Infra.UoW
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly EntityContext _entityContext;
        private bool disposedValue = false;

        public UnitOfWork(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public int Commit()
        {
            return _entityContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _entityContext.Database.BeginTransaction();
        }

        public void BeginCommit()
        {
            _transaction.Commit();
        }

        public void BeginRollback()
        {
            _transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _transaction != null)
                    _transaction.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
