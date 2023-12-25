namespace BlackOmen.WpfRpg;

using System;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// A 2d layer of a map.
/// </summary>
/// <param name="Tiles">
/// The tiles in the map, organized by column and then by row.
/// </param>
/// <param name="ExternalAppearance">
/// The tile to display outside of the defined tiles.
/// </param>
public record class MapLayer(Tile?[][] Tiles, string? ExternalAppearance)
{
	/// <summary>
	/// The name of the layer element used in serialization.
	/// </summary>
	public const string LayerElementName = "Layer";

	/// <summary>
	/// The name of the column element used in serialization.
	/// </summary>
	public const string ColumnElementName = "Column";

	/// <summary>
	/// The name of the null element used in serialization.
	/// </summary>
	public const string NullElementName = "Null";

	/// <summary>
	/// Constructs a <see cref="MapLayer"/> instance from an XML node.
	/// </summary>
	/// <param name="element">
	/// The element containing a <see cref="MapLayer"/> as XML.
	/// </param>
	/// <returns>
	/// A <see cref="MapLayer"/>, if one can be constructed.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// If a map layer cannot be constructed, an exception explaining why will be thrown.
	/// </exception>
	public static MapLayer FromXml(XElement element)
	{
		if (!element.Name.LocalName.Equals(LayerElementName))
		{
			throw new ArgumentException($"Element name must be {LayerElementName}.", nameof(element));
		}

		var externalAppearance = element.Attribute(nameof(ExternalAppearance))?.Value;

		var columns = element
			.Elements()
			.Select(ColumnFromXml)
			.ToArray();

		return new MapLayer(columns, externalAppearance);
	}

	/// <summary>
	/// Converts this <see cref="MapLayer"/> into an XML element.
	/// </summary>
	/// <returns>
	/// An <see cref="XElement"/> representing this layer.
	/// </returns>
	public XElement ToXml()
	{
		var element = new XElement(LayerElementName);

		if (this.ExternalAppearance != null)
		{
			element.Add(new XAttribute(nameof(this.ExternalAppearance), this.ExternalAppearance));
		}

		element.Add(this.Tiles.Select(column => new XElement(
			ColumnElementName,
			column.Select(tile => tile is null ? new XElement(NullElementName) : tile.ToXml()))));

		return element;
	}

	private static Tile?[] ColumnFromXml(XElement element)
	{
		if (!element.Name.LocalName.Equals(ColumnElementName))
		{
			throw new ArgumentException($"Element name must be {ColumnElementName}.", nameof(element));
		}

		return element
			.Elements()
			.Select(item => item switch
			{
				var tile when tile.Name.LocalName == nameof(Tile) => Tile.FromXml(tile),
				var nothing when nothing.Name.LocalName == NullElementName => null,
				_ => throw new ArgumentException($"Invalid element '{item.Name}' detected. Valid elements are '{nameof(Tile)}' or '{NullElementName}'.", nameof(element))
			})
			.ToArray();
	}
}
