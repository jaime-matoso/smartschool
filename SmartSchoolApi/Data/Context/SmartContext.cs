using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SmartschoolApi.Model;
using System.Reflection.Emit;

namespace SmartschoolApi.Model.Context
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        //Initial Values Database.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>().HasKey(a => new { a.AlunoId, a.DisciplinaId });

            builder.Entity<Professor>()
                        .HasData(new List<Professor>(){
                    new Professor(1, "Lauro", "Professor", "(31)99898-8787"),
                    new Professor(2, "Roberto", "Professor", "(31)99898-8787"),
                    new Professor(3, "Ronaldo", "Professor", "(31)99898-8787"),
                    new Professor(4, "Rodrigo", "Professor", "(31)99898-8787"),
                    new Professor(5, "Alexandre", "Professor", "(31)99898-8787"),
                        });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Inglês", 4),
                    new Disciplina(5, "Programação", 5)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "(31)99898-8787", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(2, "Paula", "Isabela", "(31)99898-878 7", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(3, "Laura", "Antonia", "(31)99898-8787",DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(4, "Luiza", "Maria", "(31)99898-8787", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(5, "Lucas", "Machado", "(31)99898-8787", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(6, "Pedro", "Alvares", "(31)99898-8787", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true),
                    new Aluno(7, "Paulo", "José", "(31)99898-8787", DateTime.Parse("1989-10-01"), DateTime.Parse("01-05-2000"), true)
                }); 

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() { AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() { AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() { AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() { AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() { AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() { AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() { AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() { AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() { AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() { AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() { AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() { AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() { AlunoId = 7, DisciplinaId = 5 }
                });

            base.OnModelCreating(builder);
        }
    }
}
