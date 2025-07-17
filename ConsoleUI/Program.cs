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
        decimal fiyat = 31.80m;
        int tekrar = 600;
        decimal ortalamaYuzde = 1m;
        decimal sonuc = Hesapla(fiyat, tekrar, ortalamaYuzde);

        Console.WriteLine("Sonuc : " + sonuc * 4000);
        Console.ReadLine();
    }

    public static decimal Hesapla(decimal value, int tekrar, decimal ortalamaYuzde)
    {
        for (int i = 0; i <= tekrar; i++)
        {
            Console.WriteLine(i + ". value : " + value);
            decimal yuzde = (value * ortalamaYuzde) / 100;
            value = value + yuzde;
        }
        return value;
    }
}


/*
Create Trigger TerminateRegions
On Cities
After Delete
As
Begin
Declare @CityId varchar(50)
Select @CityId = Id from deleted
Delete From Regions where CityId = @CityId
End
 */