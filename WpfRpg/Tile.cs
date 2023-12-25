namespace BlackOmen.WpfRpg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Represents a tile of a map.
/// </summary>
public record class Tile
{
	/// <summary>
	/// The name of the tag element used in serialization.
	/// </summary>
	public const string TagElementName = "Tag";

	/// <summary>
	/// Initializes a new instance of the <see cref="Tile"/> class.
	/// </summary>
	/// <param name="appearance">
	/// The key of the tile appearance in the tileset to use.
	/// </param>
	/// <param name="tags">
	/// A list of tags the tile may contain.
	/// </param>
	public Tile(string appearance, IEnumerable<string> tags)
	{
		this.Appearance = appearance;
		this.Tags = tags;
	}

	/// <summary>
	/// Gets the key of the tile appearance in the tileset to use.
	/// </summary>
	public string Appearance { get; }

	/// <summary>
	/// Gets a list of tags the tile may contain.
	/// </summary>
	public IEnumerable<string> Tags { get; }

	/// <summary>
	/// Constructs a <see cref="Tile"/> instance from an XML node.
	/// </summary>
	/// <param name="element">
	/// The element containing a <see cref="Tile"/> as XML.
	/// </param>
	/// <returns>
	/// A <see cref="Tile"/>, if one can be constructed.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// If a tile cannot be constructed, an exception explaining why will be thrown.
	/// </exception>
	public static Tile FromXml(XElement element)
	{
		if (!element.Name.LocalName.Equals(nameof(Tile)))
		{
			throw new ArgumentException($"Element name must be {nameof(Tile)}.", nameof(element));
		}

		var appearance = element.Attribute(nameof(Appearance))?.Value;
		if (string.IsNullOrWhiteSpace(appearance))
		{
			throw new ArgumentException($"{nameof(Tile)} must contain a valid {nameof(Appearance)} attribute.", nameof(element));
		}

		var tags = element
			.Elements(TagElementName)
			.Select(tag => tag.Value);

		return new Tile(appearance, tags);
	}

	/// <summary>
	/// Converts this <see cref="Tile"/> into an XML element.
	/// </summary>
	/// <returns>
	/// An <see cref="XElement"/> representing this tile.
	/// </returns>
	public XElement ToXml() =>
		new(
			nameof(Tile),
			new XAttribute(nameof(this.Appearance), this.Appearance),
			this.Tags.Select(tag => new XElement(TagElementName, tag)));
}
