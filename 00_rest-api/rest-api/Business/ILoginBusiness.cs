using rest_api.Data.VO;

namespace rest_api.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);
    }
}
