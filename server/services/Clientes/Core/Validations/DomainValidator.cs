using Core.Models;
using FluentValidation;

namespace Core.Validations
{
    public abstract class DomainValidator<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected readonly T _entidade;

        protected DomainValidator(T entidade)
        {
            _entidade = entidade;
        }
    }
}
