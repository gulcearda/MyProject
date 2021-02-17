using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //injection bu

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            //loglama
            //cacheremove
            //performance
            //transaction
            //authorization
            //business codes



            //GEREK YOK BUNLARA ARTIK SİLDİK---------------------
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            ////bu 2 if validationdur ve heryerde kullanılmak
            ////isteneceği için ayrı bir yerde kodlanır buraya çağırılır.
            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //if çalışırsa biter çalışmazsa altakine geçer ve biter. Else'e gerek yok.

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            //Burası iş kodları kullanılır ve entity ile kurulmamalıdır. İşin gereklerine göre sistem düzenlenir.
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
                //sistemi her 22 olduğunda kapatmak istediğimide yazılacak bir formül
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
            
        }
    }
}
