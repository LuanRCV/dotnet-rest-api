using rest_api.Data.VO;
using rest_api.Model;

namespace rest_api.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
