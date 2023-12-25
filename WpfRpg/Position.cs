namespace BlackOmen.WpfRpg;

using System;
using System.ComponentModel;
using System.Xml.Linq;

/// <summary>
/// Defines coordinates on a map.
/// </summary>
public record class Position : INotifyPropertyChanged
{
	private uint south;
	private uint east;

	/// <summary>
	/// Initializes a new instance of the <see cref="Position"/> class.
	/// </summary>
	/// <param name="south">
	/// The Southward coordinate of this position.
	/// </param>
	/// <param name="east">
	/// The Eastward coordinate of this position.
	/// </param>
	public Position(uint south, uint east)
	{
		this.South = south;
		this.East = east;
	}

	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Gets or sets the Southward coordinate of this position.
	/// </summary>
	public uint South
	{
		get => this.south;
		set
		{
			if (this.south != value)
			{
				this.south = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.South)));
			}
		}
	}

	/// <summary>
	/// Gets or sets the Eastward coordinate of this position.
	/// </summary>
	public uint East
	{
		get => this.east;
		set
		{
			if (this.east != value)
			{
				this.east = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.East)));
			}
		}
	}

	/// <summary>
	/// Constructs a <see cref="Position"/> instance from an XML node.
	/// </summary>
	/// <param name="element">
	/// The element containing a <see cref="Position"/> as XML.
	/// </param>
	/// <returns>
	/// A <see cref="Position"/>, if one can be constructed.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// If a position cannot be constructed, an exception explaining why will be thrown.
	/// </exception>
	public static Position FromXml(XElement element)
	{
		if (element.Name.LocalName.Equals(nameof(Position)))
		{
			throw new ArgumentException($"Element name must be {nameof(Position)}.", nameof(element));
		}

		var textualSouth = element.Attribute(nameof(South))?.Value;
		if (!uint.TryParse(textualSouth, out var south))
		{
			throw new ArgumentException($"{nameof(South)} must be specified.", nameof(element));
		}

		var textualEast = element.Attribute(nameof(East))?.Value;
		if (!uint.TryParse(textualEast, out var east))
		{
			throw new ArgumentException($"{nameof(East)} must be specified.", nameof(element));
		}

		return new Position(south, east);
	}

	/// <summary>
	/// Converts this <see cref="Position"/> into an XML element.
	/// </summary>
	/// <returns>
	/// An <see cref="XElement"/> representing this position.
	/// </returns>
	public XElement ToXml() =>
		new(
			nameof(Position),
			new XAttribute(nameof(this.South), this.South),
			new XAttribute(nameof(this.East), this.East));
}
