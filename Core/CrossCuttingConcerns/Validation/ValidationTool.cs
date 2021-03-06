﻿using System;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            //ivalidator doğrulama methodunu içeren validator ver mesela productvalidator
            //objectte validate edilecek nesneyi ver mesela product
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
                //yukarıdaki ünlem eğer sonuç geçerli değilse demektir
                //aşağıda error gönder komutu yer alır.
            }
        }
    }
}
