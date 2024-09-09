namespace NotActualDic.Models
{
    using System.Data.Common;
    using System.Data.Entity;

    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public MainContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            OnModelCreatingInternal(modelBuilder);
        }
        
        partial void OnModelCreatingInternal(DbModelBuilder modelBuilder);
    }
}