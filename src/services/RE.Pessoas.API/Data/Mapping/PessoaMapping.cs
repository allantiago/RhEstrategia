using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RE.Core.DomainObjects;
using RE.Pessoas.API.Models;

namespace RE.Pessoas.API.Data.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(Cpf.CpfMaxLength)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.Property(c => c.Nacionalidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.EnderecoEmail)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EmailMaxLenght})");
            });


            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Pessoa);

            builder.ToTable("Pessoas");

        }
    }
}
