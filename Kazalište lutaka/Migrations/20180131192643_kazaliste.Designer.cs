using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Kazalište_lutaka.Models;

namespace Kazalištelutaka.Migrations
{
    [DbContext(typeof(Kazalište_lutakaContext))]
    [Migration("20180131192643_kazaliste")]
    partial class kazaliste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kazalište_lutaka.Models.Predstave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("Trajanje");

                    b.Property<string>("Uzrast");

                    b.HasKey("Id");

                    b.ToTable("Predstave");
                });

            modelBuilder.Entity("Kazalište_lutaka.Models.Raspored", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatPredstave");

                    b.Property<int>("PredstaveId");

                    b.HasKey("Id");

                    b.HasIndex("PredstaveId");

                    b.ToTable("Raspored");
                });

            modelBuilder.Entity("Kazalište_lutaka.Models.Raspored", b =>
                {
                    b.HasOne("Kazalište_lutaka.Models.Predstave", "Predstave")
                        .WithMany()
                        .HasForeignKey("PredstaveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
