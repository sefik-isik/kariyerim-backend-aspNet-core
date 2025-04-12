using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builderItem)
        {
            builderItem.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builderItem.RegisterType<CompanyUserAddressManager>().As<ICompanyUserAddressService>().SingleInstance();
            builderItem.RegisterType<CompanyUserDepartmentManager>().As<ICompanyUserDepartmentService>().SingleInstance();
            builderItem.RegisterType<CompanyUserFileManager>().As<ICompanyUserFileService>().SingleInstance();
            builderItem.RegisterType<CompanyUserImageManager>().As<ICompanyUserImageService>().SingleInstance();
            builderItem.RegisterType<SectorManager>().As<ISectorService>().SingleInstance();
            builderItem.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvAboutManager>().As<IPersonelUserCvAboutService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvEducationManager>().As<IPersonelUserCvEducationService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvSummaryManager>().As<IPersonelUserCvSummaryService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvWorkExperienceManager>().As<IPersonelUserCvWorkExperienceService>().SingleInstance();
            builderItem.RegisterType<DriverLicenseManager>().As<IDriverLicenseService>().SingleInstance();
            builderItem.RegisterType<FacultyManager>().As<IFacultyService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvForeignLanguageManager>().As<IPersonelUserCvForeignLanguageService>().SingleInstance();
            builderItem.RegisterType<GenderManager>().As<IGenderService>().SingleInstance();
            builderItem.RegisterType<LanguageLevelManager>().As<ILanguageLevelService>().SingleInstance();
            builderItem.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builderItem.RegisterType<LicenseDegreeManager>().As<ILicenseDegreeService>().SingleInstance();
            builderItem.RegisterType<RegionManager>().As<IRegionService>().SingleInstance();
            builderItem.RegisterType<TaxOfficeManager>().As<ITaxOfficeService>().SingleInstance();
            builderItem.RegisterType<UniversityDepartmentManager>().As<IUniversityDepartmentService>().SingleInstance();
            builderItem.RegisterType<UniversityManager>().As<IUniversityService>().SingleInstance();
            builderItem.RegisterType<PersonelUserAddressManager>().As<IPersonelUserAddressService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCoverLetterManager>().As<IPersonelUserCoverLetterService>().SingleInstance();
            builderItem.RegisterType<PersonelUserFileManager>().As<IPersonelUserFileService>().SingleInstance();
            builderItem.RegisterType<PersonelUserImageManager>().As<IPersonelUserImageService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvManager>().As<IPersonelUserCvService>().SingleInstance();
            builderItem.RegisterType<WorkingMethodManager>().As<IWorkingMethodService>().SingleInstance();
            builderItem.RegisterType<UserManager>().As<IUserService>();
            builderItem.RegisterType<PersonelUserManager>().As<IPersonelUserService>();
            builderItem.RegisterType<CompanyUserManager>().As<ICompanyUserService>();
            builderItem.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builderItem.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builderItem.RegisterType<ModelMenuManager>().As<IModelMenuService>();

            builderItem.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserAddressDal>().As<ICompanyUserAddressDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserDepartmentDal>().As<ICompanyUserDepartmentDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserFileDal>().As<ICompanyUserFileDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserImageDal>().As<ICompanyUserImageDal>().SingleInstance();
            builderItem.RegisterType<EfSectorDal>().As<ISectorDal>().SingleInstance();
            builderItem.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvAboutDal>().As<IPersonelUserCvAboutDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvEducationDal>().As<IPersonelUserCvEducationDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvSummaryDal>().As<IPersonelUserCvSummaryDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvWorkExperienceDal>().As<IPersonelUserCvWorkExperienceDal>().SingleInstance();
            builderItem.RegisterType<EfDriverLicenceDal>().As<IDriverLicenseDal>().SingleInstance();
            builderItem.RegisterType<EfFacultyDal>().As<IFacultyDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvForeignLanguageDal>().As<IPersonelUserCvForeignLanguageDal>().SingleInstance();
            builderItem.RegisterType<EfGenderDal>().As<IGenderDal>().SingleInstance();
            builderItem.RegisterType<EfLanguageLevelDal>().As<ILanguageLevelDal>().SingleInstance();
            builderItem.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();
            builderItem.RegisterType<EfLicenceDegreeDal>().As<ILicenseDegreeDal>().SingleInstance();
            builderItem.RegisterType<EfRegionDal>().As<IRegionDal>().SingleInstance();
            builderItem.RegisterType<EfTaxOfficeDal>().As<ITaxOfficeDal>().SingleInstance();
            builderItem.RegisterType<EfUniversityDepartmentDal>().As<IUniversityDepartmentDal>().SingleInstance();
            builderItem.RegisterType<EfUniverstyDal>().As<IUniversityDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserAddressDal>().As<IPersonelUserAddressDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCoverLetterDal>().As<IPersonelUserCoverLetterDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserFileDal>().As<IPersonelUserFileDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserImageDal>().As<IPersonelUserImageDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvDal>().As<IPersonelUserCvDal>().SingleInstance();
            builderItem.RegisterType<EfWorkingMethodDal>().As<IWorkingMethodDal>().SingleInstance();
            builderItem.RegisterType<EfUserDal>().As<IUserDal>();
            builderItem.RegisterType<EfPersonelUserDal>().As<IPersonelUserDal>();
            builderItem.RegisterType<EfCompanyUserDal>().As<ICompanyUserDal>();
            builderItem.RegisterType<EfOperationClaim>().As<IOperationClaimDal>();
            builderItem.RegisterType<EfUserOperationClaim>().As<IUserOperationClaimDal>();
            builderItem.RegisterType<EfModelMenu>().As<IModelMenuDal>();

            builderItem.RegisterType<AuthManager>().As<IAuthService>();
            builderItem.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builderItem.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                { 
                    Selector = new AspectInterceptorSelector() 
                }).SingleInstance();

        }
    }
}
