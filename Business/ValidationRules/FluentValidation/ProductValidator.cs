using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //kurallar buraya yazılır, dto içindede olabilir
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //diyelim ki ürünlerimin ismi a ile başlamalı
            //Bunu nasıl yazarız aşağıdaki gibi olur. Must olmalı demektir.StartwithA bizim methodumuzdur.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");
        }

        //arg=productname dir.
        //bool demek true ise çalışır false ise yukarıyı patlatır.
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
