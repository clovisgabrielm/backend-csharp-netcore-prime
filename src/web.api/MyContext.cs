using PrimeControl.Core.Modelo;
using Microsoft.EntityFrameworkCore;

namespace PrimeControl.Core
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<ClientePessoaFisica> ClientesPessoaFisica { get; set; }

        public DbSet<ClientePessoaJuridica> ClientesPessoaJuridica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TestePrimeControl;Integrated Security=True;User ID=sa;Password=@PrimeControl");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            builder.Entity<ClientePessoaFisica>()
                .HasKey(c => new { c.Identificador });

            // Define composite key.
            builder.Entity<ClientePessoaJuridica>()
                .HasKey(c => new { c.Identificador });

            // Define composite key.
            builder.Entity<Contato>()
                .HasKey(c => new { c.Identificador });

            builder.Entity<Contato>()
                .HasOne(c => c.ClientePessoaFisica)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.ClientePessoaFisicaIdentificador);

            builder.Entity<ClientePessoaFisica>().HasData(
                   new ClientePessoaFisica
                   {
                       Identificador = 1,
                       Nome = "Cliente 1",
                       CPF = "152555455445",
                       InstituicaoFinanceira = "Banco 1",
                       DataCadastro = new System.DateTime().AddDays(2)
                   }
               ); ;
        }
    }
}
