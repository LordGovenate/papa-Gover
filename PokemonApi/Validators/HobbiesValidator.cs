using System.ServiceModel;
using PokemonApi.Models;

namespace PokemonApi.Validators;

public static class HobbiesValidator
{
    public static Hobbies ValidateId(this Hobbies hobbies) =>
        hobbies.Id <= 0 ?
        throw new FaultException("Hobbies Id is required and must be greater than 0") : hobbies;

    public static Hobbies ValidateName(this Hobbies hobbies) =>
        string.IsNullOrEmpty(hobbies.Name) ? 
        throw new FaultException("Hobbies name is required") : hobbies;

    public static Hobbies ValidateTop(this Hobbies hobbies) =>
        hobbies.Top <= 0 ? 
        throw new FaultException("Hobbies top value must be greater than 0") : hobbies;
}
