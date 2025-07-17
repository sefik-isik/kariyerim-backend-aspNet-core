using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builderItem)
        {
            builderItem.RegisterType<AuthManager>().As<IAuthService>();
            builderItem.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builderItem.RegisterType<CompanyUserAddressManager>().As<ICompanyUserAddressService>().SingleInstance();
            builderItem.RegisterType<CompanyUserDepartmentManager>().As<ICompanyUserDepartmentService>().SingleInstance();
            builderItem.RegisterType<CompanyUserFileManager>().As<ICompanyUserFileService>().SingleInstance();
            builderItem.RegisterType<CompanyUserImageManager>().As<ICompanyUserImageService>().SingleInstance();
            builderItem.RegisterType<SectorManager>().As<ISectorService>().SingleInstance();
            builderItem.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvEducationManager>().As<IPersonelUserCvEducationService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvSummaryManager>().As<IPersonelUserCvSummaryService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvWorkExperienceManager>().As<IPersonelUserCvWorkExperienceService>().SingleInstance();
            builderItem.RegisterType<DriverLicenceManager>().As<IDriverLicenceService>().SingleInstance();
            builderItem.RegisterType<LanguageLevelManager>().As<ILanguageLevelService>().SingleInstance();
            builderItem.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builderItem.RegisterType<LicenseDegreeManager>().As<ILicenseDegreeService>().SingleInstance();
            builderItem.RegisterType<RegionManager>().As<IRegionService>().SingleInstance();
            builderItem.RegisterType<TaxOfficeManager>().As<ITaxOfficeService>().SingleInstance();
            builderItem.RegisterType<UniversityManager>().As<IUniversityService>().SingleInstance();
            builderItem.RegisterType<FacultyManager>().As<IFacultyService>().SingleInstance();
            builderItem.RegisterType<UniversityDepartmentManager>().As<IUniversityDepartmentService>().SingleInstance();
            builderItem.RegisterType<UniversityImageManager>().As<IUniversityImageService>().SingleInstance();
            builderItem.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builderItem.RegisterType<DepartmentDescriptionManager>().As<IDepartmentDescriptionService>().SingleInstance();
            builderItem.RegisterType<PersonelUserAddressManager>().As<IPersonelUserAddressService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCoverLetterManager>().As<IPersonelUserCoverLetterService>().SingleInstance();
            builderItem.RegisterType<PersonelUserFileManager>().As<IPersonelUserFileService>().SingleInstance();
            builderItem.RegisterType<PersonelUserImageManager>().As<IPersonelUserImageService>().SingleInstance();
            builderItem.RegisterType<PersonelUserCvManager>().As<IPersonelUserCvService>().SingleInstance();
            builderItem.RegisterType<WorkingMethodManager>().As<IWorkingMethodService>().SingleInstance();
            builderItem.RegisterType<WorkAreaManager>().As<IWorkAreaService>().SingleInstance();
            builderItem.RegisterType<ExperienceManager>().As<IExperienceService>().SingleInstance();
            builderItem.RegisterType<UserManager>().As<IUserService>().SingleInstance(); ;
            builderItem.RegisterType<PersonelUserManager>().As<IPersonelUserService>().SingleInstance(); ;
            builderItem.RegisterType<CompanyUserManager>().As<ICompanyUserService>().SingleInstance(); ;
            builderItem.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance(); ;
            builderItem.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance(); ;
            builderItem.RegisterType<ModelMenuManager>().As<IModelMenuService>().SingleInstance(); ;
            builderItem.RegisterType<PersonelUserAdvertApplicationManager>().As<IPersonelUserAdvertApplicationService>().SingleInstance(); ;
            builderItem.RegisterType<PersonelUserAdvertFollowManager>().As<IPersonelUserAdvertFollowService>().SingleInstance(); ;
            builderItem.RegisterType<PersonelUserFollowCompanyUserManager>().As<IPersonelUserFollowCompanyUserService>().SingleInstance(); ;
            builderItem.RegisterType<CompanyUserAdvertCityManager>().As<ICompanyUserAdvertCityService>().SingleInstance(); ;
            builderItem.RegisterType<CompanyUserAdvertJobDescriptionManager>().As<ICompanyUserAdvertJobDescriptionService>().SingleInstance(); ;
            builderItem.RegisterType<CompanyUserAdvertManager>().As<ICompanyUserAdvertService>().SingleInstance();
            builderItem.RegisterType<CountManager>().As<ICountService>().SingleInstance();
            builderItem.RegisterType<PositionManager>().As<IPositionService>().SingleInstance();
            builderItem.RegisterType<PositionLevelManager>().As<IPositionLevelService>().SingleInstance();


            builderItem.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserAddressDal>().As<ICompanyUserAddressDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserDepartmentDal>().As<ICompanyUserDepartmentDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserFileDal>().As<ICompanyUserFileDal>().SingleInstance();
            builderItem.RegisterType<EfCompanyUserImageDal>().As<ICompanyUserImageDal>().SingleInstance();
            builderItem.RegisterType<EfSectorDal>().As<ISectorDal>().SingleInstance();
            builderItem.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvEducationDal>().As<IPersonelUserCvEducationDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvSummaryDal>().As<IPersonelUserCvSummaryDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvWorkExperienceDal>().As<IPersonelUserCvWorkExperienceDal>().SingleInstance();
            builderItem.RegisterType<EfDriverLicenceDal>().As<IDriverLicenceDal>().SingleInstance();
            builderItem.RegisterType<EfLanguageLevelDal>().As<ILanguageLevelDal>().SingleInstance();
            builderItem.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();
            builderItem.RegisterType<EfLicenseDegreeDal>().As<ILicenseDegreeDal>().SingleInstance();
            builderItem.RegisterType<EfRegionDal>().As<IRegionDal>().SingleInstance();
            builderItem.RegisterType<EfTaxOfficeDal>().As<ITaxOfficeDal>().SingleInstance();
            builderItem.RegisterType<EfUniverstyDal>().As<IUniversityDal>().SingleInstance();
            builderItem.RegisterType<EfFacultyDal>().As<IFacultyDal>().SingleInstance();
            builderItem.RegisterType<EfUniversityDepartmentDal>().As<IUniversityDepartmentDal>().SingleInstance();
            builderItem.RegisterType<EfUniversityImageDal>().As<IUniversityImageDal>().SingleInstance();
            builderItem.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();
            builderItem.RegisterType<EfDepartmentDescriptionDal>().As<IDepartmentDescriptionDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserAddressDal>().As<IPersonelUserAddressDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCoverLetterDal>().As<IPersonelUserCoverLetterDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserFileDal>().As<IPersonelUserFileDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserImageDal>().As<IPersonelUserImageDal>().SingleInstance();
            builderItem.RegisterType<EfPersonelUserCvDal>().As<IPersonelUserCvDal>().SingleInstance();
            builderItem.RegisterType<EfWorkingMethodDal>().As<IWorkingMethodDal>().SingleInstance();
            builderItem.RegisterType<EfWorkAreaDal>().As<IWorkAreaDal>().SingleInstance();
            builderItem.RegisterType<EfExperienceDal>().As<IExperienceDal>().SingleInstance();
            builderItem.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance(); ;
            builderItem.RegisterType<EfPersonelUserDal>().As<IPersonelUserDal>().SingleInstance(); ;
            builderItem.RegisterType<EfCompanyUserDal>().As<ICompanyUserDal>().SingleInstance(); ;
            builderItem.RegisterType<EfOperationClaim>().As<IOperationClaimDal>().SingleInstance(); ;
            builderItem.RegisterType<EfUserOperationClaim>().As<IUserOperationClaimDal>().SingleInstance(); ;
            builderItem.RegisterType<EfModelMenu>().As<IModelMenuDal>().SingleInstance(); ;
            builderItem.RegisterType<EfPersonelUserAdvertApplicationDal>().As<IPersonelUserAdvertApplicationDal>().SingleInstance(); ;
            builderItem.RegisterType<EfPersonelUserAdvertFollowDal>().As<IPersonelUserAdvertFollowDal>().SingleInstance(); ;
            builderItem.RegisterType<EfPersonelUserFollowCompanyUserDal>().As<IPersonelUserFollowCompanyUserDal>().SingleInstance(); ;
            builderItem.RegisterType<EfCompanyUserAdvertCityDal>().As<ICompanyUserAdvertCityDal>().SingleInstance(); ;
            builderItem.RegisterType<EfCompanyUserAdvertJobDescriptionDal>().As<ICompanyUserAdvertJobDescriptionDal>().SingleInstance(); ;
            builderItem.RegisterType<EfCompanyUserAdvertDal>().As<ICompanyUserAdvertDal>().SingleInstance(); ;
            builderItem.RegisterType<EfExperienceDal>().As<IExperienceDal>().SingleInstance();
            builderItem.RegisterType<EfCountDal>().As<ICountDal>().SingleInstance();
            builderItem.RegisterType<EfPositionDal>().As<IPositionDal>().SingleInstance();
            builderItem.RegisterType<EfPositionLevelDal>().As<IPositionLevelDal>().SingleInstance();

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
