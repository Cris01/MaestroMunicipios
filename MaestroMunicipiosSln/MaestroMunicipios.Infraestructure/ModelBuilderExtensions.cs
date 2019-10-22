using MaestroMunicipios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace MaestroMunicipios.Infraestructure
{
    public static class ModelBuilderExtensions
    {
        public static void ShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var tp in modelBuilder.Model.GetEntityTypes())
            {
                var t = tp.ClrType;
                if (typeof(DomainEntity).IsAssignableFrom(t))
                {
                    var method = SetAuditingShadowPropertiesMethodInfo.MakeGenericMethod(t);
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }
            }
        }


        private static readonly MethodInfo SetAuditingShadowPropertiesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetAuditingShadowProperties");



        public static void SetAuditingShadowProperties<T>(ModelBuilder builder) where T : DomainEntity
        {
            if (builder != null)
            {
                builder.Entity<T>().Property<DateTime>("Created").HasDefaultValueSql("GETDATE()");
                builder.Entity<T>().Property<DateTime>("Modified").HasDefaultValueSql("GETDATE()");
            }

        }
    }
}








