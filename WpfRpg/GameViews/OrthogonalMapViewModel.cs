namespace BlackOmen.WpfRpg.GameViews;

using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Logic for managing a map.
/// </summary>
[Export]
public class OrthogonalMapViewModel : INotifyPropertyChanged
{
	private Map? map;
	private Tile?[][][]? current;
	private Tile?[][][]? north;
	private Tile?[][][]? south;
	private Tile?[][][]? east;
	private Tile?[][][]? west;
	private Position? position;
	private int radius = 10;

	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Gets or sets the basis of the map currently being displayed.
	/// </summary>
	public Map? Map
	{
		get => this.map;
		set
		{
			if (this.map != value)
			{
				this.map = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Map)));
				this.Regenerate();
			}
		}
	}

	/// <summary>
	/// Gets or sets the current position in the map.
	/// </summary>
	public Position? Position
	{
		get => this.position;
		set
		{
			if (value != this.position)
			{
				this.position = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Position)));
				this.Regenerate();
			}
		}
	}

	/// <summary>
	/// Gets or sets the radius of the map.
	/// </summary>
	public int Radius
	{
		get => this.radius;
		set
		{
			if (this.radius != value)
			{
				this.radius = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Radius)));
			}
		}
	}

	/// <summary>
	/// Gets the map currently being displayed.
	/// </summary>
	public Tile?[][][]? Current
	{
		get => this.current;
		private set
		{
			if (this.current != value)
			{
				this.current = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Current)));
			}
		}
	}

	/// <summary>
	/// Gets the map that would be displayed if the origin was one space to the North.
	/// </summary>
	public Tile?[][][]? North
	{
		get => this.north;
		private set
		{
			if (this.north != value)
			{
				this.north = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.North)));
			}
		}
	}

	/// <summary>
	/// Gets the map that would be displayed if the origin was one space to the South.
	/// </summary>
	public Tile?[][][]? South
	{
		get => this.south;
		private set
		{
			if (this.south != value)
			{
				this.south = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.South)));
			}
		}
	}

	/// <summary>
	/// Gets the map that would be displayed if the origin was one space to the East.
	/// </summary>
	public Tile?[][][]? East
	{
		get => this.east;
		private set
		{
			if (this.east != value)
			{
				this.east = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.East)));
			}
		}
	}

	/// <summary>
	/// Gets the map that would be displayed if the origin was one space to the West.
	/// </summary>
	public Tile?[][][]? West
	{
		get => this.west;
		private set
		{
			if (this.west != value)
			{
				this.west = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.West)));
			}
		}
	}

	/// <summary>
	/// Goes one space to the North.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Stylecop incorrectly flags with members as local")]
	public void GoNorth() =>
		this.Position = (this.Position ?? new Position(0, 0)) with { South = (this.Position?.South ?? 1) - 1 };

	/// <summary>
	/// Goes one space to the South.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Stylecop incorrectly flags with members as local")]
	public void GoSouth() =>
		this.Position = (this.Position ?? new Position(0, 0)) with { South = (this.Position?.South ?? 0) + 1 };

	/// <summary>
	/// Goes one space to the West.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Stylecop incorrectly flags with members as local")]
	public void GoWest() =>
		this.Position = (this.Position ?? new Position(0, 0)) with { East = (this.Position?.East ?? 1) - 1 };

	/// <summary>
	/// Goes one space to the East.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Stylecop incorrectly flags with members as local")]
	public void GoEast() =>
		this.Position = (this.Position ?? new Position(0, 0)) with { East = (this.Position?.East ?? 0) + 1 };

	private void Regenerate()
	{
		if (this.Map is null || this.Position is null)
		{
			return;
		}

		var layers = this.Map.Layers;

		Parallel.Invoke(
			() => this.Current = this.GenerateAtPosition(layers, this.Position),
			() => this.North = this.GenerateAtPosition(layers, new Position(this.Position.South - 1, this.Position.East)),
			() => this.South = this.GenerateAtPosition(layers, new Position(this.Position.South + 1, this.Position.East)),
			() => this.East = this.GenerateAtPosition(layers, new Position(this.Position.South, this.Position.East + 1)),
			() => this.West = this.GenerateAtPosition(layers, new Position(this.Position.South, this.Position.East - 1)));
	}

	private Tile?[][][] GenerateAtPosition(IEnumerable<MapLayer> layers, Position position) => layers
		.Select(layer => layer.Tiles.GenerateView(
			position,
			string.IsNullOrWhiteSpace(layer.ExternalAppearance) ? null : new Tile(layer.ExternalAppearance, new[] { Constants.Tags.Unpathable }),
			this.Radius))
		.ToArray();
}
