using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserOperationClaimDTO : BaseDTOUser, IDto
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
