using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Interfaces;
using DotNet.ApplicationCore.Interfaces;
using DotNet.Infrastructure.Persistence.Repositories.User;
using static DotNet.ApplicationCore.Utils.Enum.GlobalEnum;

namespace DotNet.Services.Common
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        ResponseMessage rm = new ResponseMessage();
        public UserService(

              UserRepository userRepository
            )
        {
           
            _userRepository = userRepository;
        }

        public ResponseMessage UserAuthentication(AuthUser user)
        {
            try
            {
                AuthUser authUser = _userRepository.UserAuthentication(user);
                if(authUser.UserAutoID > 0)
                {
                    rm.StatusCode = ReturnStatus.Success;
                    rm.ResponseObj= authUser;
                }
                else
                {
                    rm.Message = "Invalid UserID or Password";
                    rm.StatusCode = ReturnStatus.Failed;
                }
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
                rm.ResponseObj = _userRepository.GetAll();
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
                rm.ResponseObj = _userRepository.GetByID(id);
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
