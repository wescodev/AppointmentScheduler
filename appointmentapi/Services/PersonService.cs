using appointmentapi.Models;
using appointmentapi.Repositories.Interface;

namespace appointmentapi.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> CreatePersonAsync(string fullName, string email, string phoneNumber, DateTime birthdate)
        {
            var existing = await _personRepository.GetByEmailAsync(email);
            if(existing != null)
                throw new Exception("Email already in use");

            var newPerson = new Person
            {
                Name = fullName,
                Email = email,
                Number = phoneNumber,
                BirthDate = birthdate
            };

            await _personRepository.AddPersonAsync(newPerson);
            return newPerson;
        }

        public Task<Person?> GetByEmailAsync(string email)
        {
            return _personRepository.GetByEmailAsync(email);
        }
    }
}
