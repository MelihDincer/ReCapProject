using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarTest();
//BrandTest();
static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
    }

    carManager.Add(new Car
    {
        ColorId = 3,
        BrandId = 3,
        CarName = "Süüü",
        DailyPrice = 299.54565456465456465465456415144561654M,
        ModelYear = 2023,
        Description = "DENEMEEEE"
    });


    Console.WriteLine("**********************************************************************************************************************");


    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
    }
}
static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.Name);
    }
    brandManager.Add(new Brand
    {
        Name = "Toyota"
    });
    Console.WriteLine("**********************************************************************************************************************");

    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.Name);
    }
}


//--- INMEMORY TESTLERİ ---

//Console.WriteLine("Mevcut Liste \n");
//GetCarList(carManager);

////Ekleme işlemi
//carManager.TAdd(new Car
//{
//    Id = 6,
//    ModelYear = 2018,
//    DailyPrice = 180.60M,
//    Description = "Deneme"
//});

//Console.WriteLine("Ekleme İşlemi Sonrası \n");
//GetCarList(carManager);

////Silme İşlemi
//carManager.TDelete(new Car
//{
//    Id = 6,
//});

//Console.WriteLine("Silme İşlemi Sonrası \n");
//GetCarList(carManager);

////Güncelleme İşlemi
//carManager.TUpdate(new Car
//{
//    Id = 5,
//    BrandId = 5,
//    ColorId = 5,
//    ModelYear = 2010,
//    DailyPrice = 150.20M,
//    Description = "Güncelleme Başarılı..."
//});

//Console.WriteLine("Güncelleme İşlemi Sonrası \n");
//GetCarList(carManager);

////Id Değerine Göre Listeleme İşlemi
//Console.WriteLine("1 Numaralı Araba Bilgisi \n");
//foreach (var car in carManager.TGetById(1))
//{
//    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
//}

//static void GetCarList(CarManager carManager)
//{
//    foreach (var car in carManager.TGetAll())
//    {
//        Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
//        Console.WriteLine("\n");
//    }
//    Console.WriteLine("**********************************************************************************************************************");
//    Console.WriteLine("********************************************************************************************************************** \n\n");
//}