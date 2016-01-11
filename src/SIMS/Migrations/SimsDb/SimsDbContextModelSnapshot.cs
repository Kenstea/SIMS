using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SIMS.Models;

namespace SIMS.Migrations.SimsDb
{
    [DbContext(typeof(SimsDbContext))]
    partial class SimsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SIMS.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Actual");

                    b.Property<int>("Atp");

                    b.Property<bool>("Endangered");

                    b.Property<int>("EndangeredQuantity");

                    b.Property<int>("Expected");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");
                });
        }
    }
}
