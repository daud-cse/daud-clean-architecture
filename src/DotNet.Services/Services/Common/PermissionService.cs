using DotNet.ApplicationCore.DTOs;
using static DotNet.ApplicationCore.Utils.Enum.GlobalEnum;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;

namespace DotNet.Services.Services.Common
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepository;
        ResponseMessage rm = new ResponseMessage();
        public PermissionService(

              IPermissionRepository PermissionRepository
            )
        {

            _PermissionRepository = PermissionRepository;
        }


        public ResponseMessage GetAllByOrganizationUser()
        {
            try
            {
                rm.ResponseObj = _PermissionRepository.GetAllByOrganizationUser().Result;
                rm.StatusCode = ReturnStatus.Success;
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }
            return rm;
        }
        

        public ResponseMessage GetAll()
        {
            try
            {
                rm.ResponseObj = _PermissionRepository.GetAll();
                rm.StatusCode = ReturnStatus.Success;
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }
            return rm;
        }
        public ResponseMessage GetByID(int id)
        {
            rm = new ResponseMessage();
            try
            {
                rm.ResponseObj = _PermissionRepository.GetByID(id);
                rm.StatusCode = ReturnStatus.Success;
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message.ToString();
                rm.StatusCode = ReturnStatus.Failed;
            }
            return rm;
        }
    }
}
