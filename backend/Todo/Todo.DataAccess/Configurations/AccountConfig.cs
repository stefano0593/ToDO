using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Accounts.Identifiers;
using Todo.Domain.Accounts.Models;
using Todo.Domain.Shared.Validators;

namespace Todo.DataAccess.Configurations;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasKey(account => account.AccountId);

        builder
            .Property(account => account.AccountId)
            .HasConversion(id => id.Value,
                value => new AccountId(value))
            .IsRequired();

        builder
            .Property(account => account.IdentityId)
            .IsRequired();

        builder
            .HasIndex(account => account.IdentityId)
            .IsUnique();

        builder
            .Property(account => account.FirstName)
            .HasMaxLength(RuleConstants.AccountNameMaxLength)
            .IsRequired();
        
        builder
            .Property(account => account.LastName)
            .HasMaxLength(RuleConstants.AccountNameMaxLength)
            .IsRequired();
    }
}