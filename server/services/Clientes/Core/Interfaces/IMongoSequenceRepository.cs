using Core.Models;

namespace Core.Interfaces
{
    public interface IMongoSequenceRepository
    {
        void Inserir(MongoSequence mongoSequence);
        long ObterProximoValor(string nomeSequence);
    }
}
