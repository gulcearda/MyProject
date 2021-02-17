using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //reflectiondır üsteki; çalışma anında bir şeyleri çalıştırmaya yardımcı olur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //validatorun çalışma base tipini bul ve onun generic olanın ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //bu seferde parametrelerini bul. bunlardanda entity tipine eşit olan parametereli bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
            //her birini tek tek gez, validationtool u kullanarak
        }
    }
}
