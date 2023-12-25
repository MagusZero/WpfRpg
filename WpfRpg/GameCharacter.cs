namespace BlackOmen.WpfRpg;

/// <summary>
/// Defines a character in the game and how they should appear.
/// </summary>
/// <param name="Name">
/// The name of the character.
/// </param>
/// <param name="Appearance">
/// The key of the resource used to display this character.
/// </param>
public record class GameCharacter(string Name, string Appearance)
{
}
