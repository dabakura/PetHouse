namespace PetHouse.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetHouseModel : DbContext
    {
        public PetHouseModel()
            : base("name=PetHouseConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
