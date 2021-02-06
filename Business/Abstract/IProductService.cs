using System;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        //category idsine göre ürünleri getiren sistem
        List<Product> GetByUnitPrice(decimal min, decimal max);
        //e ticarette min şu fiyat ve şu fiyat aralığını getir dedik.

        List<ProductDetailDto> GetProductDetailDtos();

    }
}
