using System;
using Models;

namespace Core
{
    public interface IBookValidator
    {
        void Validate(Book book);
    }
}
