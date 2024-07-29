using api_reservas.Core.Models;
using Infrastructure.Repository;

namespace api_reservas.Services
{
    public class LocalService : BaseService<Local>
    {
        public LocalService(MyMongoRepository repository) : base(repository)
        {

        }

    }
}
