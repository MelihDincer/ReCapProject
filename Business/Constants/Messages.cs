
namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Araçlar listelendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string BrandsListed = "Araç markaları listelendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string RentalsListed = "Kiralama bilgileri listelendi.";

        public static string CarAdded = "Yeni araç eklendi.";
        public static string ColorAdded = "Yeni renk seçeneği eklendi.";
        public static string BrandAdded = "Yeni araç markası eklendi.";
        public static string UserAdded = "Yeni kullanıcı eklendi.";
        public static string CustomerAdded = "Yeni müşteri eklendi.";
        public static string RentalAdded = "Araç kiralama işlemi başarılı!";

        public static string CarDeleted = "Araba silindi";
        public static string ColorDeleted = "Renk silindi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string RentalDeleted = "Araç kiralama bilgileri silindi";

        public static string CarUpdated = "Araba bilgisi güncellendi.";
        public static string ColorUpdated = "Renk bilgisi güncellendi.";
        public static string BrandUpdated = "Marka bilgisi güncellendi.";
        public static string UserUpdated = "Kullanıcı bilgisi güncellendi.";
        public static string CustomerUpdated = "Müşteri bilgisi güncellendi.";
        public static string RentalUpdated = "Araç kiralama bilgileri güncellendi.";

        public static string CarNameInvalid = "Araç adı geçersiz!";
        public static string ColorNameInvalid = "Renk adı geçersiz!";
        public static string BrandNameInvalid = "Araç markası geçersiz!";
        public static string CarNameLengthInvalid = "Yeni araç eklenememiştir. Araç ismi minimum 2 karakterden oluşmalıdır.";
        public static string CarDailyPriceInvalid = "Yeni araç eklenememiştir. Günlük fiyat 0'dan büyük olmalıdır.";
        public static string RentalInvalid = "Kiralama işlemi başarısız! Araç mevcut değil ya da kirada. (Aracın kiralanabilmesi için daha önce aracı kiralayan kişinin teslim işlemini tamamlaması gerekmektedir.)";

        public static string CarListed = "İstenilen aracın bilgileri verildi.";

        public static string UnknownCar = "İstenilen id bilgisinde araç bulunamadı.";

        public static string UnknownError = "Bilinmeyen bir hata oluştu.";

        public static string CarDeliver = "Araç teslim edilmiştir..";
        public static string CarDeliverEmpty = "Araç teslim edilememiştir. Belirtilen bilgide araç bulunmamaktadır!";

        public static string ImageLimitExceded = "Bu araba için daha fazla resim ekleyemezsiniz. Bir arabanın en fazla 5 resmi olabilir!";
        public static string ImageUploaded = "Araba resmi başarıyla yüklendi.";
        public static string ImageDeleted = "Araba resmi başarıyla silindi.";
    }
}
