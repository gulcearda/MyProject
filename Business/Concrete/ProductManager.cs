using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        ICategoryService _categoryService;
        //ILogger _logger;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //_logger = logger;
        }


        //claim
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),CheckIFCategoryLimitExceeded());

            if (result !=null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);



            //_logger.Log();
            //try
            //{
            //    //bu kodu dene dersin olmazsa hata olursa ne yapsın diye
            //    //aşağıda söyleriz yazarız.
            //}
            //catch (Exception exception)
            //{
            //    _logger.Log();
            //}
            //return new ErrorResult();
            

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


        }

        [CacheAspect] //key,value
        public IDataResult<List<Product>> GetAll()
        {
            
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

        [CacheAspect]
        [PerformanceAspect(5)]
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


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")] //Iproductservice teki tüm getleri sil
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)//Product productta yazılabilirdi
        {
            //select count(*) from products where categoryId=1
            //aşağıdaki kod üstekini çalıştırır.
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //any var mı demektir. Şuna uyan kayıt var mı demektir. Bool döndürür
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if(result == true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIFCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);

            return null;
        }
    }
}
