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