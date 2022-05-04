using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        Task SignInAsync(params (object, object)[] cookies);
    }
}
