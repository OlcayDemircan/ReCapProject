using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public class Messages // temel mesajları tutan class, static olarak tanımlandığı için new'lenmeden kullanılır ve sadece bir adet instance olabilir.
    {
        // Ortak mesajlar    
        public static string Added = "Ekleme işlemi başarılı.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string Updated = "Güncelleme işlemi başarılı.";
        public static string MaintenanceTime = "Sistem bakımdadır.";
        public static string Listed = "Listeleme işlemi başarılı.";
        internal static string AuthorizationDenied = "Yetkiniz yok";

        //Car nesnesi ile ilgili mesajlar
        public static string CarNameInvalid = "Araç ismi geçersiz";

        //Brand nesnesi ile ilgili mesajar
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        
        //Color nesnesi ile ilgili mesajar        
        public static string ColorNameInvalid = "Renk ismi geçersiz";

        //Rental nesnesi ile ilgili mesajar 
        public static string RentalValid = "Araç kiralandı";
        public static string RentalInvalid = "Araç kiralanamaz çünkü şu anda kiralık durumda";

        //CarImage nesnesi ile ilgili mesajar 
        internal static string CarHasAlreadyFiveImages = "Bu otomobil için zaten 5 adet resim yüklenmiş durumdadır";
        internal static string CarImageAdded = "Araba resmi eklendi";
    }
}
