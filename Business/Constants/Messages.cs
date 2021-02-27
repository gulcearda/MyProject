﻿using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserRegistered = "Kayıt oldu";

        public static string UserNotFound =" Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserAdded = "Kullanıcı eklendi";

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten bulunuyor";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor"
    }
}
