﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDescriptionInvalid = "Araba ismi minimum 2 karakter olmalıdır.";
        public static string CarDailyPriceInvalid = "Araba günlük fiyatı 0'dan büyük olmalıdır.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarDeleted = "Araba silindi";

        public static string ColorDeleted = "Renk silindi";
        public static string ColorsListed = "Renkler listelendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorNameInvalid = "Renk ismi geçersiz.";
        public static string ColorUpdated = "Renk güncellendi.";

        public static string BrandDeleted = "Marka silindi";
        public static string BrandsListed = "Markalar listelendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz.";
        public static string BrandUpdated = "Marka güncellendi.";
    }
}