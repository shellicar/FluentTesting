﻿namespace FluentFixture.Delegates
{
    public delegate TResult TestFunctionWithResult<in TFixture, out TResult>(TFixture fixture, object previousResult);
}