﻿using Microservise.Data.ModelConfigurations.Base;
using Microservise.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Microservise.Data.ModelConfigurations
{
    /// <summary>
    /// Entity Type Configuration for <see cref="Log"/> entity
    /// </summary>
    public class LogModelConfiguration : IdentityModelConfigurationBase<Log>
    {
        protected override void AddBuilder(EntityTypeBuilder<Log> builder)
        {
            builder.Property(x => x.Logger).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Level).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(4000).IsRequired();
            builder.Property(x => x.CreatedAt).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
            builder.Property(x => x.ThreadId).HasMaxLength(255);
            builder.Property(x => x.ExceptionMessage).HasMaxLength(2000);
        }

        protected override string TableName()
        {
            return "Logs";
        }
    }
}
