using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Login).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Cpf).IsRequired().HasMaxLength(25);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(60);
            builder.Property(a => a.Senha).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Ativo).IsRequired().HasMaxLength(2);
        }
    }
}