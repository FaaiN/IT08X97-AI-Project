﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dieticianAI;

namespace dieticianAI.Migrations
{
    [DbContext(typeof(DietDbContext))]
    partial class DietDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("agent.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CHOCDF");

                    b.Property<double>("CHOLE");

                    b.Property<double>("ENERC_KCAL");

                    b.Property<double>("FASAT");

                    b.Property<double>("FAT");

                    b.Property<double>("FATRN");

                    b.Property<double>("FAT_KCAL");

                    b.Property<double>("FIBTG");

                    b.Property<string>("Name");

                    b.Property<double>("PROCNT");

                    b.Property<string>("RawData");

                    b.Property<double>("SUGAR");

                    b.Property<double>("WATER");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}
