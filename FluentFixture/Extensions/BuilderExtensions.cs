using System;

namespace FluentFixture.Extensions
{
    public static class BuilderExtensions
    {
        public static IFixtureBuilder<TEntity> With<TEntity>(this IFixtureBuilder<TEntity> builder, Modify<TEntity> func)
        {
            builder.AddMethod(func);
            return builder;
        }

        public static IFixtureBuilder<TEntity> With<TEntity>(this IFixtureBuilder<TEntity> builder, Action<TEntity> action)
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
