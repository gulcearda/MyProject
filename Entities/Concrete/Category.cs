﻿using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
