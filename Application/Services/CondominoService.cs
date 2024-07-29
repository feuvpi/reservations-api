using api_reservas.Core.Models;
using Infrastructure.Repository;
using MongoDB.Driver;

namespace api_reservas.Services
{
    public class CondominoService : BaseService<Condomino>
    {
        public CondominoService(MyMongoRepository repository) : base(repository)
        {
        }

        //public async Task<Condomino> FindByEmail(string email)
        //{
        //    return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        //}

        public async Task<Condomino> FindByCpf(string cpf)
        {
            return await _collection.Find(x => x.CPF == cpf).FirstOrDefaultAsync();
        }

        public async Task<Condomino> CreateCondominoAsync(Condomino condomino)
        {
           await _collection.InsertOneAsync(condomino);
           var condoCreated = await FindByCpf(condomino.CPF);
           return condoCreated;
        }

    }
}
