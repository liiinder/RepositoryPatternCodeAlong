using Application.Interfaces;
using Application.Models;
using Infrastructure.SQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repository
{

    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;

        public PeopleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
        {
            var entity = model.ToEntity();

            await _context.People.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.ToModel();
        }

        public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
        {
            var people = await _context.People.ToListAsync();
            List<ReadPersonModel> peopleModels = new();

            people.ForEach(x => peopleModels.Add(x.ToModel()));

            return peopleModels;
        }
    }
}
