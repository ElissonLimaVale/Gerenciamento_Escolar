using Microsoft.EntityFrameworkCore;
using SGIEscolar.Data.Models;
using System.Linq;

namespace SGIEscolar.Data.Context
{
    public class SGIEscolarContext : DbContext
    {
        public SGIEscolarContext(DbContextOptions options) : base(options)
        {
        }

        #region DATASETERS 
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Aluno> aluno { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<Licenca> licenca { get; set; }
        public DbSet<Permissao> permissao { get; set; }
        public DbSet<Professor> professor { get; set; }
        public DbSet<Turma> turma { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var Item in builder.Model.GetEntityTypes().SelectMany(x => x.GetProperties().Where(x => x.ClrType == typeof(string))))
            {
                Item.SetColumnType("varchar(500)");
            }
            builder.ApplyConfigurationsFromAssembly(typeof(SGIEscolarContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
