using Business.Abstract;
using Business.Concrete;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        GetAlllCity(new CityManager(new EfCityDal(), new CountryManager(new EfCountryDal())));
        GetCityById(new CityManager(new EfCityDal(), new CountryManager(new EfCountryDal())), 5);


        //DTO
        GetCityDTO(new CityManager(new EfCityDal(), new CountryManager(new EfCountryDal())));

        Console.ReadLine();
    }



    private static void GetAlllCity(CityManager cityManager)
    {
        if (cityManager.GetAll().IsSuccess)
        {
            Console.WriteLine(cityManager.GetAll().Message);
            Console.WriteLine("İşlem Sonucu : " + cityManager.GetAll().IsSuccess);
            foreach (City city in cityManager.GetAll().Data)
            {
                Console.WriteLine(city.Id + " " + city.CityName + " " + city.CountryId);
            }
        }
        else
        {
            Console.WriteLine(cityManager.GetAll().Message);
            Console.WriteLine("İşlem Sonucu : " + cityManager.GetAll().IsSuccess);
        }

    }
    private static void GetCityById(CityManager cityManager, int cityId)
    {
        if (cityManager.GetById(cityId).IsSuccess)
        {
            Console.WriteLine(cityManager.GetById(cityId).Message);
            Console.WriteLine("İşlem Sonucu : " + cityManager.GetById(cityId).IsSuccess);

            City city1 = cityManager.GetById(cityId).Data;
            Console.WriteLine(city1.Id + " " + city1.CityName + " " + city1.CountryId);
        }
        else
        {
            Console.WriteLine(cityManager.GetById(cityId).Message);
            Console.WriteLine("İşlem Sonucu : " + cityManager.GetById(cityId).IsSuccess);
        }
    }


    //DTO
    private static void GetCityDTO(CityManager cityManager)
    {
        Console.WriteLine(cityManager.GetAllDTO().Message);
        Console.WriteLine("İşlem Sonucu : " + cityManager.GetAllDTO().IsSuccess);
        if (cityManager.GetAllDTO().IsSuccess)
        {
            foreach (var city in cityManager.GetAllDTO().Data)
            {
                Console.WriteLine(city.Id + " " + city.CityName + " / " + city.CountryName);
            }
        }
        else
        {
            Console.WriteLine(cityManager.GetAllDTO().Message);
            Console.WriteLine("İşlem Sonucu : " + cityManager.GetAllDTO().IsSuccess);
        }
    }


}