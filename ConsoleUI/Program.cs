using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());

Console.WriteLine("Mevcut Liste \n");
foreach (var car in carManager.TGetAll())
{
    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
    Console.WriteLine("\n");
}

Console.WriteLine("**********************************************************************************************************************");
Console.WriteLine("********************************************************************************************************************** \n\n");

//Ekleme işlemi
carManager.TAdd(new Car
{
    Id = 6,
    ModelYear = 2018,
    DailyPrice = 180.60M,
    Description = "Deneme"
});

Console.WriteLine("Ekleme İşlemi Sonrası \n");
foreach (var car in carManager.TGetAll())
{
    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
    Console.WriteLine("\n");
}

Console.WriteLine("**********************************************************************************************************************");
Console.WriteLine("********************************************************************************************************************** \n\n");

//Silme İşlemi
carManager.TDelete(new Car
{
    Id = 6,
});

Console.WriteLine("Silme İşlemi Sonrası \n");
foreach (var car in carManager.TGetAll())
{
    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
    Console.WriteLine("\n");
}

Console.WriteLine("**********************************************************************************************************************");
Console.WriteLine("********************************************************************************************************************** \n\n");

//Güncelleme İşlemi
carManager.TUpdate(new Car
{
    Id=5,
    BrandId = 5,
    ColorId = 5,
    ModelYear = 2010,
    DailyPrice = 150.20M,
    Description = "Güncelleme Başarılı..."
});

Console.WriteLine("Güncelleme İşlemi Sonrası \n");
foreach (var car in carManager.TGetAll())
{
    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
    Console.WriteLine("\n");
}

Console.WriteLine("**********************************************************************************************************************");
Console.WriteLine("********************************************************************************************************************** \n\n");

//Id Değerine Göre Listeleme İşlemi
Console.WriteLine("1 Numaralı Araba Bilgisi \n");
foreach(var car in carManager.TGetById(1))
{
    Console.WriteLine("Araç Yılı: " + car.ModelYear + " Günlük Ücret: " + car.DailyPrice + " Açıklama: " + car.Description);
}