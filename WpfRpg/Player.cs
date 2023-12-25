namespace BlackOmen.WpfRpg;

/// <summary>
/// Represents player-level data.
/// </summary>
/// <param name="Protagonist">
/// The character acting as the protagonist.
/// </param>
/// <param name="Position">
/// The position of the character on the current map.
/// </param>
public record class Player(GameCharacter Protagonist, Position Position)
{
}
