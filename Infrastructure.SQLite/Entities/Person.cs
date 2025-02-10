using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQLite.Entities;

public class Person
{
    [Key]
    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }

}

public static class PersonExtensions
{
    public static ReadPersonModel ToModel(this Person person)
    {
        return new ReadPersonModel
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName
        };
    }

    public static Person ToEntity(this AddPersonModel model)
    {
        return new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }
}