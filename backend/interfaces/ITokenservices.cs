using backend.Entities;

namespace backend.interfaces
{
    public interface ITokenservices
    {
        string CreateToken(UserClass user);
        // string CreateAdminToken(AdminClass admin);
    }
}