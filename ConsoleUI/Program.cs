using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//CarTest();
//BrandTest();
//UserTest();
//CustomerTest();
RentalTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetails();
    //var result = carManager.GetCarsByBrandId(11);
    if (result.Success)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
        }
        //foreach (var car in result.Data)
        //{
        //    Console.WriteLine(car.CarName);
        //}
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    //foreach (var car in carManager.GetCarDetails())
    //{
    //    Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
    //}
    var result2 = carManager.Add(new Car
    {
        ColorId = 3,
        BrandId = 3,
        CarName = "Canavar Bir Model",
        DailyPrice = 299.54565456465456465465456415144561654M,
        ModelYear = 2023,
        Description = "Testt"
    });
    if (result2.Success)
    {
        Console.WriteLine(result2.Message);
    }
    else
    {
        Console.WriteLine(result2.Message);
    }


    //Console.WriteLine("**********************************************************************************************************************");


    //foreach (var car in carManager.GetCarDetails())
    //{
    //    Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
    //}
}
static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    var result = brandManager.GetAll();
    if (result.Success)
    {
        foreach (var brand in result.Data)
        {
            Console.WriteLine(brand.Name);
        }
    }
    //foreach (var brand in brandManager.GetAll())
    //{
    //    Console.WriteLine(brand.Name);
    //}
    //brandManager.Add(new Brand
    //{
    //    Name = "Toyota"
    //});
    //Console.WriteLine("**********************************************************************************************************************");

    //foreach (var brand in brandManager.GetAll())
    //{
    //    Console.WriteLine(brand.Name);
    //}
}
static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    var result = customerManager.GetAll();
    if (result.Success)
    {
        foreach (var customer in result.Data)
        {
            Console.WriteLine(customer.Id + "--" + customer.UserId + "--" + customer.CompanyName);
        }
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    customerManager.Add(new Customer
    {
        UserId = 2,
        CompanyName = "Dinçer Emlak & Gayrimenkul Ltd. Şti.",
    });

    var result2 = customerManager.GetAll();

    if (result.Success)
    {
        foreach (var customer in result2.Data)
        {
            Console.WriteLine(customer.Id + "--" + customer.UserId + "--" + customer.CompanyName);
        }
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result2.Message);
    }
}
static void UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Add(new User
    {
        FirstName = "Melih",
        LastName = "Dinçer",
        Email = "m_dincer41@hotmail.com",
        Password = "123456"
    });

    var result = userManager.GetAll();
    if (result.Success)
    {
        foreach (var user in result.Data)
        {
            Console.WriteLine(user.Id + "--" + user.FirstName + "--" + user.LastName + "--" + user.Email + "--" + user.Password);
        }
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}
static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    var result = rentalManager.GetRentalDetails();
    if (result == null)
    {
        Console.WriteLine("Daha önce kiralanan bir araç bulunmamaktadır..");
    }
    else
    {
        foreach (var rental in result.Data)
        {
            Console.WriteLine(rental.RentalId + " -- " + rental.CarName + " -- " + rental.CustomerName + " -- " + rental.RentDate.ToString("dd MMM yyyy"));
        }
        Console.WriteLine(result.Message);
    }

    var addedRental = rentalManager.Add(new Rental
    {
        CustomerId = 2,
        CarId = 7,
        RentDate = DateTime.Now
    });

    if (addedRental.Success)
    {
        Console.WriteLine(addedRental.Message);
    }
    else
    {
        Console.WriteLine(addedRental.Message);
    }

    //var result3 = rentalManager.CarDeliver(2);
    //if (result3.Success)
    //{
    //    Console.WriteLine(result3.Message);
    //}
    //else
    //{
    //    Console.WriteLine(result3.Message);
    //}

    var result2 = rentalManager.GetRentalDetails();
    foreach (var rental in result2.Data)
    {
        Console.WriteLine(rental.RentalId + " -- " + rental.CarName + " -- " + rental.CustomerName + " -- " + rental.RentDate.ToString("dd MMM yyyy"));
    }
    Console.WriteLine(result2.Message);

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