using System;

namespace FluentFixture.Extensions
{
    public static class BuilderExtensions
    {
        public static FixtureBuilder<TEntity> With<TEntity>(this FixtureBuilder<TEntity> builder, Modify<TEntity> func)
        {
            builder.AddMethod(func);
            return builder;
        }

        public static FixtureBuilder<TEntity> With<TEntity>(this FixtureBuilder<TEntity> builder, Action<TEntity> action)
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
