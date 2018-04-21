using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFixture
{
    public static class BuilderExtensions
    {
        public static IEntityBuilder<TEntity> With<TEntity>(this IEntityBuilder<TEntity> builder, Modify<TEntity> func)
        {
            builder.AddMethod(func);
            return builder;
        }

        public static IEntityBuilder<TEntity> With<TEntity>(this IEntityBuilder<TEntity> builder, Action<TEntity> action)
        {
            
            builder.AddMethod(x =>
            {
                action(x);
                return x;
            });
            return builder;
        }
    }
}
