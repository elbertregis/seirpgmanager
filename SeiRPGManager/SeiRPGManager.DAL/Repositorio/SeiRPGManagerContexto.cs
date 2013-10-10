// -----------------------------------------------------------------------
// <copyright file="SeiRPGManagerContexto.cs" company="Playware">
// Todos os direitos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace SeiRPGManager.DAL.Repositorio
{
    using System.Data.Entity;
    using System.Data.Objects;    
    using SeiRPGManager.Entidades.Modelo.ClassesBasicas;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using MySql.Data.MySqlClient;
    using MySql.Web.Security;

    /// <summary>
    /// TODO: Update Header
    /// </summary>
    public class SeiRPGManagerContexto : MySqlSecurityDbContext
    {
        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public SeiRPGManagerContexto() : base("name=SeiRPGManagerCon")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static SeiRPGManagerContexto CriarContexto()
        {
            //this.Configuration.LazyLoadingEnabled = true;
            return new SeiRPGManagerContexto();
        }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Agenda> Agenda { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Anotacao> Anotacao { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Arma> Arma { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Campanha> Campanha { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Categoria> Categoria { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<EnredoPool> EnredoPool { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Equipamento> Equipamento { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Especializacao> Especializacao { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Habilitador> Habilitador { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Jogador> Jogador { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Mensagem> Mensagem { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<NomePool> NomePool { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Ocupacao> Ocupacao { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Parametro> Parametro { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Personagem> Personagem { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Personalidade> Personalidade { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Precedente> Precedente { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<PrologoPool> PrologoPool { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Raca> Raca { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Saude> Saude { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Sistema> Sistema { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<Talento> Talentos { get; set; }

        /// <summary>
        /// TODO: Update Header
        /// </summary>
        public DbSet<UserProperty> UserProperties { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //modelBuilder.Entity<Instructor>()
            //    .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);
            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("PersonID")
            //        .ToTable("CourseInstructor"));
            //modelBuilder.Entity<Department>()
            //    .HasOptional(x => x.Administrator);
        }
    }
}
