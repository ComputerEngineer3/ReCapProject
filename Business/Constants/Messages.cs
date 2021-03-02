using System;
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
        
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar listelendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz.";
        public static string UserUpdated = "Kullanıcı güncellendi.";

        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerNameInvalid = "Müşteri ismi geçersiz.";
        public static string CustomerUpdated = "Müşteri güncellendi.";

        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalsListed = "Kiralamalar listelendi.";
        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalNameInvalid = "Kiralama ismi geçersiz.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string CarUndelivered = "Kiralanan araba teslim edilmemiş";

        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageListed = "Araba resmi listelendi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        internal static string PictureLimitExceded = "Bir arabanın en fazla 5 resmi olabilir";
    }
}
