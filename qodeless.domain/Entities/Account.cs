using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using qodeless.domain.Enums;

namespace qodeless.domain.Entities
{
    public class Account : Entity, IEntityTypeConfiguration<Account>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CellPhone { get; set; }
        public EAccountStatus Status { get; set; }
        public Account(Guid id) { Id = id; }

        public Account(string name, string description)
        {
            Name = name;
            Description = description;
            Status = EAccountStatus.Actived;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}