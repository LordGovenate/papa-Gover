namespace PokedexApi.Exceptions;

public class PokemonConflictController : Exception {
    public PokemonConflictController(string message) : base(message) { }
}
