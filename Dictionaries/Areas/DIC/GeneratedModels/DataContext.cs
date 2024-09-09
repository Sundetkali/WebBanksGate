namespace Dictionaries.Areas.DIC.Models
{
    using System.Data.Common;
    using System.Data.Entity;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base ("DefaultConnection")
        {
        }

        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DataContext(DbConnection existingConnection, bool contextOwnsConnection)
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