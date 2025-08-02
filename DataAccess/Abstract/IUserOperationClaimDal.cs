﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        Task<List<UserOperationClaimDTO>> GetAllDTO();
        Task<List<UserOperationClaimDTO>> GetDeletedAllDTO();
    }
}