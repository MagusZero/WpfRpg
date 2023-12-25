namespace BlackOmen.WpfRpg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// A class used to manage data about a tile-based map.
/// </summary>
/// <param name="Layers">
/// The layers of the map in descending order.
/// </param>
/// <param name="Tileset">
/// The name of the tileset, which should be defined elsewhere.
/// </param>
/// <param name="Style">
/// The style of the map. The initial value is Orthogonal, but Isometric will be supported eventually.
/// </param>
/// <param name="Name">
/// The name of the map.
/// </param>
/// <param name="TileWidth">
/// The width of an individual tile in pixels. Tiles are all the same width.
/// </param>
/// <param name="TileHeight">
/// The height of an individual tile in pixels. Tiles are all the same height.
/// </param>
public record class Map(IEnumerable<MapLayer> Layers, string Tileset, string Style, string Name, uint TileWidth, uint TileHeight)
{
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
	public static Map FromXml(XElement element)
	{
		if (!element.Name.LocalName.Equals(nameof(Map)))
		{
			throw new ArgumentException($"Element name must be {nameof(Map)}.", nameof(element));
		}

		var tileset = element.Attribute(nameof(Tileset))?.Value;
		if (string.IsNullOrWhiteSpace(tileset))
		{
			throw new ArgumentException($"{nameof(Tileset)} must be specified.", nameof(element));
		}

		var style = element.Attribute(nameof(Style))?.Value;
		if(string.IsNullOrWhiteSpace(style))
		{
			throw new ArgumentException($"{nameof(Style)} must be specified.", nameof(element));
		}

		var name = element.Attribute(nameof(Name))?.Value;
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException($"{nameof(Name)} must be specified.", nameof(element));
		}

		var textualTileWidth = element.Attribute(nameof(TileWidth))?.Value;
		if (!uint.TryParse(textualTileWidth, out var tileWidth))
		{
			throw new ArgumentException($"{nameof(TileWidth)} must be specified.", nameof(element));
		}

		var textualTileHeight = element.Attribute(nameof(TileHeight))?.Value;
		if (!uint.TryParse(textualTileHeight, out var tileHeight))
		{
			throw new ArgumentException($"{nameof(TileHeight)} must be specified.", nameof(element));
		}

		var layers = element
			.Elements()
			.Select(MapLayer.FromXml)
			.ToList();

		return new Map(layers, tileset, style, name, tileWidth, tileHeight);
	}

	/// <summary>
	/// Converts this <see cref="Map"/> into an XML element.
	/// </summary>
	/// <returns>
	/// An <see cref="XElement"/> representing this map.
	/// </returns>
	public XElement ToXml() =>
		new(
			nameof(Map),
			new XAttribute(nameof(this.Tileset), this.Tileset),
			new XAttribute(nameof(this.Style), this.Style),
			new XAttribute(nameof(this.Name), this.Name),
			new XAttribute(nameof(this.TileWidth), this.TileWidth),
			new XAttribute(nameof(this.TileHeight), this.TileHeight),
			this.Layers.Select(layer => layer.ToXml()));
}
