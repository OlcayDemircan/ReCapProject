using Business.Concrete;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfBrandDal efBrandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(efBrandDal);

            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(efCarDal);

            EfColorDal efColorDal = new EfColorDal();
            ColorManager colorManager = new ColorManager(efColorDal);

            EfCustomerDal efCustomerDal = new EfCustomerDal();
            CustomerManager customerManager = new CustomerManager(efCustomerDal);

            EfRentalDal efRentalDal = new EfRentalDal();
            RentalManager rentalManager = new RentalManager(efRentalDal);

            Rental rental1 = new Rental(); rental1.CarId = 1; rental1.CustomerId = 2;
            rental1.RentDate = new DateTime(2021, 2, 15); rental1.ReturnDate = new DateTime(2021, 2, 16);
            Rental rental2 = new Rental(); rental2.CarId = 1; rental2.CustomerId = 1;
            rental2.RentDate = new DateTime(2021, 2, 16);
            Rental rental3 = new Rental(); rental3.CarId = 1; rental3.CustomerId = 1;
            rental3.RentDate = new DateTime(2021, 2, 17);

            //rentalManager.Add(rental1); // İlk kiralamanın tabloya eklenmesi. Dönüş tarihi verilmiştir.
            //rentalManager.Add(rental2); // İkinci kiralamanın tabloya eklenmesi. Dönüş tarihi bilinmiyor.
            //rentalManager.Add(rental2); // Üçüncü kiralamanın tabloya eklenmesi. Araç dönüş tarihi boş olmadığı için başarısızlıkla sonuçlanır.
                                    
            



            //Customer customer1 = new Customer(); customer1.Id = 1; customer1.CompanyName = "ABC Kimya";
            //Customer customer2 = new Customer(); customer2.Id = 2; customer2.CompanyName = "Nera Mühendislik";
            //Customer customer3 = new Customer(); customer3.Id = 3; customer3.CompanyName = "Demircan Otel";               

            //Brand brand1 = new Brand();
            //Brand brand2 = new Brand();
            //Brand brand3 = new Brand();
            //Brand brand4 = new Brand();
            //Brand brand5 = new Brand();
            //brand1.Id = 1; brand1.BrandName = "Fiat";
            //brand2.Id = 2; brand2.BrandName = "Opel";
            //brand3.Id = 3; brand3.BrandName = "Renault";
            //brand4.Id = 4; brand4.BrandName = "Peugeot";
            //brand5.Id = 5; brand5.BrandName = "Mercedes";


            //Color color1 = new Color();
            //Color color2 = new Color();
            //Color color3 = new Color();
            //Color color4 = new Color();
            //color1.Id = 1; color1.ColorName = "Siyah";
            //color2.Id = 2; color2.ColorName = "Beyaz";
            //color3.Id = 3; color3.ColorName = "Kırmızı";





        }



    }
}
