using appointmentapi.Models;

namespace appointmentapi.Repositories.Interface;

public interface IPersonRepository
{
    Task<Person> AddPersonAsync(Person person);
    Task<Person?> GetByEmailAsync(string email);
}
