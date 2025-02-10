using Application.Interfaces;
using Application.Models;
using Infrastructure.Json.Entities;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Infrastructure.MongoDbDriver.Repository
{

    public class PeopleRepository : IPeopleRepository
    {
        public string file { get; set; }
        public PeopleRepository()
        {
            file = "people.json";
        }

        public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
        {
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            if (!File.Exists(file)) File.WriteAllText(file, "[]");

            string json = await File.ReadAllTextAsync(file);
            List<ReadPersonModel> peopleModel = new();

            var loadedPersons = JsonSerializer.Deserialize<List<Person>>(json);
            foreach (Person p in loadedPersons) peopleModel.Add(p.ToModel());

            return peopleModel;
        }

        public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
        {            
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            if (!File.Exists(file)) File.WriteAllText(file, "[]");

            string json = await File.ReadAllTextAsync(file);
            List<ReadPersonModel> peopleModel = new();

            var loadedPersons = JsonSerializer.Deserialize<List<Person>>(json);
            foreach (Person p in loadedPersons) peopleModel.Add(p.ToModel());

            return peopleModel;
        }
    }
}
