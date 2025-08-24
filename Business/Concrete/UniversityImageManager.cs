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
        public async Task<IResult> Add(UniversityImage universityImage)
        {
            await _universityImageDal.AddAsync(universityImage);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(UniversityImage universityImage)
        {
            if (universityImage.isMainImage == true)
            {
                await _universityImageDal.UpdateMainImage(universityImage.UniversityId);
            }

            if (universityImage.isLogo == true)
            {
                await _universityImageDal.UpdateLogoImage(universityImage.UniversityId);
            }

            await _universityImageDal.UpdateAsync(universityImage);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UniversityImage universityImage)
        {
            await _universityImageDal.Delete(universityImage);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(UniversityImage universityImage)
        {
            await DeleteImage(universityImage);
            await _universityImageDal.Terminate(universityImage);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityImage>>> GetAll()
        {
            var result = await _universityImageDal.GetAll();
            result = result.OrderBy(x => x.ImageOwnName).ToList();
            return new SuccessDataResult<List<UniversityImage>>(result);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UniversityImage>>> GetDeletedAll()
        {
            var result = await _universityImageDal.GetDeletedAll();
            result = result.OrderBy(x => x.ImageOwnName).ToList();
            return new SuccessDataResult<List<UniversityImage>>(result);
        }
        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UniversityImage?>> GetById(string id)
        {
            return new SuccessDataResult<UniversityImage?>(await _universityImageDal.Get(r => r.Id == id));
        }
        public async Task<IDataResult<List<UniversityImage>>> GetUniversityMainImage(string id)
        {
            return new SuccessDataResult<List<UniversityImage>> (await _universityImageDal.GetUniversityMainImage(id));
        }
        public async Task<IDataResult<List<UniversityImage>>> GetUniversityLogoImage(string id)
        {
            return new SuccessDataResult<List<UniversityImage>>(await _universityImageDal.GetUniversityLogoImage(id));
        }
        public async Task<IDataResult<List<UniversityImage>>> GetAllById(string id)
        {
            return new SuccessDataResult<List<UniversityImage>>(await _universityImageDal.GetAll(i=>i.UniversityId==id));
        }

        [SecuredOperation("admin,user")]
        public async Task<List<UniversityImage>> GetAllByUniversityId(string id)
        {
            return await _universityImageDal.GetAll(data => data.UniversityId == id);

        }

        public async Task<IResult> DeleteImage(UniversityImage universityImage)
        {
            if(universityImage == null)
            {
                return new ErrorDataResult<UniversityImage>(Messages.ImageNotFound);
            }

            string ImagePath = _environment.WebRootPath + "\\uploads\\images\\" + universityImage.Id;
            string FullImagePath = ImagePath + "\\" + universityImage.ImageName;

            string ThumbImagePath = ImagePath + "\\thumbs\\";
            string FullThumbImagePath = ThumbImagePath + universityImage.ImageName;

            if (System.IO.File.Exists(FullImagePath))
            {
                System.IO.File.Delete(FullImagePath);
            }

            if (System.IO.File.Exists(FullThumbImagePath))
            {
                System.IO.File.Delete(FullThumbImagePath);
            }

            DirectoryInfo source = new DirectoryInfo(ImagePath);
            FileInfo[] sourceFiles = source.GetFiles();

            if (sourceFiles.Length == 0)
            {
                System.IO.Directory.Delete(ImagePath, true);
            }

            universityImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            universityImage.ImageName = "noImage.jpg";

            await Update(universityImage);

            return new SuccessResult();
        }

    }
}
