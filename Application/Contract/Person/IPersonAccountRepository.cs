using Dtos.Users;
using DTOS.Account;

namespace Application.Contracts.User
{
    public interface IPersonAccountRepository
    {
        Task<AuthModel> Registration(RegistrationModel registrationModel);
        Task<AuthModel> Login(LoginModel loginModel);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
