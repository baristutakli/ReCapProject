using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}



/*
 * veri tabanı adı DB_ECommerce
 * (local)\MSSQLLocalDb
 * 
 * */


//2) Sql Server tarafında yeni bir veritabanı kurunuz. Cars, Brands, Colors tablolarını oluşturunuz. (Araştırma)

//3) Sisteme Generic IEntityRepository altyapısı yazınız.

//4) Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.

//5) GetCarsByBrandId , GetCarsByColorId servislerini yazınız.

//6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

//Araba ismi minimum 2 karakter olmalıdır

//Araba günlük fiyatı 0'dan büyük olmalıdır.