using System.Data.Entity;
using System.Transactions;

namespace S360Entity
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly S360Entities _db;


        public UnitOfWork()
        {
            _db = new S360Entities();
          
        }

        public void Dispose()
        {
           
        }

        public void StartTransaction()
        {

            _transaction = new TransactionScope();   
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }


        
    }
}
