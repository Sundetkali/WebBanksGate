using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using BanksGateDataModel.Properties;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

using CodeFirstStoreFunctions;
using BanksGateDataModel.Codes;


namespace BanksGateDataModel.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<DataContext>(null);
            Config();
        }

        public DataContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Database.SetInitializer<DataContext>(null);
            Config();
        }

        private void Config()
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            //this.Configuration.DisableFilterOverProjectionSimplificationForCustomFunctions = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Add(new FunctionsConvention<DataContext>("dbo"));
        }
        
        /// <summary>
        /// Sql версия.
        /// </summary>
        /// <param name="repartion"></param>
        /// <returns>если значение пусто, то 0</returns>
        [DbFunction("CodeFirstDatabaseSchema", nameof(GetRepartionDays))]
        public static int GetRepartionDays(string repartion)
        {
            if (string.IsNullOrEmpty(repartion))
                return 0;

            return Convert.ToInt32(repartion.Substring(0, 3)) + Convert.ToInt32(repartion.Substring(4, 2)) * 360;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repatriation"></param>
        /// <returns>если значение пусто, то 180</returns>
        public int GetRepatriationDays(string repatriation)
        {
            if (string.IsNullOrEmpty(repatriation))
                return 180;

            return Convert.ToInt32(repatriation.Substring(0, 3)) + Convert.ToInt32(repatriation.Substring(4, 2)) * 360;
        }
       

    }
}