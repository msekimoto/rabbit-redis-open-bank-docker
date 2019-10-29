using Core.Models;
using Core.Validations;
using FluentValidation;

namespace Core.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, DomainSpecification<T> predicate) where T : Entity<T>
        {
            return ruleBuilder.Must(p => predicate.IsValid());
        }
    }
}
