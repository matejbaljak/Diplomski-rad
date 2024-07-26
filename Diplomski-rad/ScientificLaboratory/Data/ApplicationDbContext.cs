using Microsoft.EntityFrameworkCore;
using ScientificLaboratory.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ScientificLaboratory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<News> News { get; set; }

        public DbSet<Funding> Fundings { get; set; }
        public DbSet<FundingByYear> FundingByYears { get; set; }

        public DbSet<Publication> Publications { get; set; }
        public DbSet<Pdf> PdfFiles { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<PublicationAuthor> PublicationAuthors { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Researcher> Researchers { get; set; }

        public DbSet<ProjectResearcher> ProjectResearchers { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funding>()
                .HasMany(f => f.FundingbyYears)
                .WithOne(fy => fy.Funding)
                .HasForeignKey(fy => fy.FundingId);


            modelBuilder.Entity<Publication>()
                .HasOne(p => p.Pdf)
                .WithOne(pdf => pdf.Publication)
                .HasForeignKey<Pdf>(pdf => pdf.PublicationId);
        }
    }
}
