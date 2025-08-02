using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        readonly IPaginationUriService _uriService;
        public UserManager(IUserDal userDal, IPaginationUriService uriService)
        {
            _userDal = userDal;
            _uriService = uriService;

        }
        public async Task<IDataResult<List<OperationClaim>>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(await _userDal.GetClaims(user));
        }
        public async Task<IResult> Add(User user)
        {
            IResult result = await BusinessRules.Run(IsNameExist(user.Email), await IsTelephoneExist(user.PhoneNumber));

            if (result != null)
            {
                return result;
            }
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(User user)
        {
            User currentUser = await GetById(user.Id);

            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = currentUser.Status,
                Code = currentUser.Code,
                PasswordHash = currentUser.PasswordHash,
                PasswordSalt = currentUser.PasswordSalt,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = currentUser.UpdatedDate,
                DeletedDate = currentUser.DeletedDate,

            };

            await _userDal.UpdateAsync(newUser);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(User user)
        {
            User currentUser = await GetById(user.Id);

            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = currentUser.Status,
                Code = currentUser.Code,
                PasswordHash = currentUser.PasswordHash,
                PasswordSalt = currentUser.PasswordSalt,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = currentUser.UpdatedDate,
                DeletedDate = currentUser.DeletedDate,

            };

            await _userDal.Delete(newUser);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(User user)
        {
            await _userDal.TerminateSubDatas(user.Id);
            await _userDal.Terminate(user);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        public async Task<IDataResult<User?>> GetByMail(string email)
        {
            return new SuccessDataResult<User?>(await _userDal.Get(u => u.Email == email));
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<UserDTO>> GetByIdDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<UserDTO>(await _userDal.GetByIdDTO(userAdminDTO.UserId, userAdminDTO.Id));
            }
            else
            {
                return new SuccessDataResult<UserDTO>(await _userDal.GetByIdForAdminDTO(userAdminDTO.Id));
            }
        }


        public async Task<User?> GetById(string id)
        {
                return await _userDal.Get(u => u.Id == id);
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<User?>> IsAdmin(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<User?>(await _userDal.Get(u => u.Status == UserStatus.Admin && userAdminDTO.Status == UserStatus.Admin && u.Id == userAdminDTO.UserId && u.Email == userAdminDTO.Email));
        }

        //[SecuredOperation("admin,user")]
        public async Task<IDataResult<UserPageModel>> GetAllByPage(UserPageModel pageModel)
        {
            var datas = await _userDal.GetAll();
            var query = datas.AsQueryable();

            switch (pageModel.SortColumn)
            {
                case "FirstName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.FirstName) : query.OrderBy(c => c.FirstName);
                    break;
                case "LastName":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.LastName) : query.OrderBy(c => c.LastName);
                    break;
                case "Email":
                    query = pageModel.SortOrder == "desc" ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                    break;
                default:
                    query = query.OrderBy(c => c.Email);
                    break;
            }

            var onePageContactQuery = query.Skip(pageModel.PageSize * pageModel.PageIndex).Take(pageModel.PageSize).ToList();
            var pageContactResult = onePageContactQuery.ToList();
            var totalCount = query.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / pageModel.PageSize));

            Uri? nextPage = pageModel.PageIndex + 1 >= 1 && pageModel.PageIndex < totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex + 1, PageSize = pageModel.PageSize })
                : null;
            Uri? previousPage = pageModel.PageIndex - 1 >= 1 && pageModel.PageIndex <= totalPages
                ? _uriService.GetPageUri(new PageModel { PageIndex = pageModel.PageIndex - 1, PageSize = pageModel.PageSize })
                : null;
            Uri? firstPage = _uriService.GetPageUri(new PageModel { PageIndex = 1, PageSize = pageModel.PageSize });
            Uri? lastPage = _uriService.GetPageUri(new PageModel { PageIndex = totalPages, PageSize = pageModel.PageSize });
            Uri? currentPage = _uriService.GetPageUri(pageModel);

            var positionPageModel = new UserPageModel
            {
                PageContacts = pageContactResult,
                ContactTotalCount = totalCount,
                PageIndex = pageModel.PageIndex,
                PageSize = pageModel.PageSize,
                SortColumn = pageModel.SortColumn ?? string.Empty,
                SortOrder = pageModel.SortOrder ?? string.Empty,
                NextPage = nextPage,
                PreviousPage = previousPage,
                FirstPage = firstPage,
                LastPage = lastPage,
                TotalPages = totalPages,
                CurrentPage = currentPage
            };

            return new SuccessDataResult<UserPageModel>(positionPageModel, Messages.SuccessListed);
        }


        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await IsAdmin(userAdminDTO);
            var allDtos = await _userDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.Id == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await IsAdmin(userAdminDTO);
            var allDtos = await _userDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.Id == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserDTO>>> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await IsAdmin(userAdminDTO);
            var allDtos = await _userDal.GetAllCompanyUserDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.Id == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserDTO>>> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await IsAdmin(userAdminDTO);
            var allDtos = await _userDal.GetAllPersonelUserDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.Id == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserDTO>>(allDtos.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _userDal.GetAll(c => c.Email.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsTelephoneExist(string entityName)
        {
            var result = await _userDal.GetAll(c => c.PhoneNumber == entityName);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
