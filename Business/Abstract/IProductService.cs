using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        //T'miz burada list<product> tır.

        IDataResult<List<Product>> GetAllByCategoryId(int id);
        //category idsine göre ürünleri getiren sistem

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        //e ticarette min şu fiyat ve şu fiyat aralığını getir dedik.

        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();

        IDataResult<Product> GetById(int productId);

        IResult Add(Product product);
        //voide Iresult dedik
        IResult Update(Product product);

        IResult AddTransactionTest(Product product);

        //RESTFULL --> HTTP -->
    }
}
