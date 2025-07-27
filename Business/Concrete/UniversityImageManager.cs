using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UniversityImageManager: IUniversityImageService
    {
        IUniversityImageDal _universityImageDal;
        private readonly IWebHostEnvironment _environment;
        public UniversityImageManager(IUniversityImageDal universityImageDal, IWebHostEnvironment environment)
        {
            _universityImageDal = universityImageDal;
            _environment = environment;
        }

        [SecuredOperation("admin")]
        public IResult Add(UniversityImage universityImage)
        {
            _universityImageDal.AddAsync(universityImage);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public IResult Update(UniversityImage universityImage)
        {
            if (universityImage.isMainImage == true)
            {
                _universityImageDal.UpdateMainImage(universityImage.UniversityId);
            }

            if (universityImage.isLogo == true)
            {
                _universityImageDal.UpdateLogoImage(universityImage.UniversityId);
            }

            _universityImageDal.UpdateAsync(universityImage);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public IResult Delete(UniversityImage universityImage)
        {
            _universityImageDal.Delete(universityImage);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public IResult Terminate(UniversityImage universityImage)
        {
            DeleteImage(universityImage);
            _universityImageDal.Terminate(universityImage);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityImage>> GetAll()
        {
            return new SuccessDataResult<List<UniversityImage>>(_universityImageDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UniversityImage>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UniversityImage>>(_universityImageDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<UniversityImage> GetById(string id)
        {
            return new SuccessDataResult<UniversityImage>(_universityImageDal.Get(r => r.Id == id));
        }
        public IDataResult<List<UniversityImage>> GetAllById(string id)
        {
            return new SuccessDataResult<List<UniversityImage>>(_universityImageDal.GetAll(i=>i.UniversityId==id));
        }

        public IResult DeleteImage(UniversityImage universityImage)
        {
            if(universityImage == null)
            {
                return new ErrorDataResult<UniversityImage>(Messages.ImageNotFound);
            }
            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + universityImage.Id + "\\" + universityImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + universityImage.Id + "\\thumbs\\" + universityImage.ImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            universityImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            universityImage.ImageName = "noImage.jpg";

            Update(universityImage);

            return new SuccessResult();
        }

    }
}
