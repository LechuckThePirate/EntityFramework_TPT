using System.Data.Entity.ModelConfiguration;
using EF_TPT.Domain.Entities;
using EF_TPT.Domain.Entities.Base;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class BaseEntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity> 
        where TEntity : BaseEntity
    {
        public BaseEntityConfiguration()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
