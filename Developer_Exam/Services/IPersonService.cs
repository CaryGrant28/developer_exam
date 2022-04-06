using Developer_Exam.ModelExtensions;
using Developer_Exam.Models;

namespace Developer_Exam.Services
{
    public interface IPersonService
    {
        Task<List<Person>> All();
        Task<int> Save(Person model);
        Task<int> Delete(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public PersonService(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("Exam");
        }

        public async Task<List<Person>> All()
        {
            return await Task.FromResult(PersonExtension.All(connectionString));
        }

        public async Task<int> Save(Person model)
        {
            return await Task.FromResult(PersonExtension.Save(model, connectionString));
        }

        public async Task<int> Delete(int id)
        {
            return await Task.FromResult(PersonExtension.Delete(id, connectionString));
        }

    }
}
