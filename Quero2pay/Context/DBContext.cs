using Quero2pay.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quero2pay.Context
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=Quero2Connection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Cargo
            modelBuilder.Entity<Cargo>().HasKey(c => c.idCargo);
            modelBuilder.Entity<Cargo>().Property(c => c.idCargo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Empresa
            modelBuilder.Entity<Empresa>().HasKey(e => e.idEmpresa);
            modelBuilder.Entity<Empresa>().Property(e => e.idEmpresa).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Funcionário
            modelBuilder.Entity<Funcionario>().HasKey(f => f.idFuncionario);
            modelBuilder.Entity<Funcionario>().Property(f => f.idFuncionario).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Funcionario>().HasRequired(f => f.Empresa).WithMany(e => e.Funcionarios);
            modelBuilder.Entity<Funcionario>().HasRequired(f => f.Cargo).WithMany(c => c.Funcionario);
        }
    }
}