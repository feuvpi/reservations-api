using api_reservas.Core.Models;
using Infrastructure.Repository;
using MongoDB.Driver;

namespace api_reservas.Services
{
    public class UserService : BaseService<Usuario>
    {
        public UserService(MyMongoRepository repository) : base(repository)
        {
        }

        public async Task<Usuario> FindByEmail(string email)
        {
            return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario> FindByCpf(string cpf)
        {
            return await _collection.Find(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task<Usuario> CreateCondominoAsync(Usuario usuario)
        {
           await _collection.InsertOneAsync(usuario);
           var condoCreated = await FindByCpf(usuario.Cpf);
           return condoCreated;
        }

    }
}
