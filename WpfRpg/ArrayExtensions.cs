namespace BlackOmen.WpfRpg;

using System;
using System.Linq;

/// <summary>
/// Extension methods for arrays of things.
/// </summary>
public static class ArrayExtensions
{
	/// <summary>
	/// Extrapolates a map to fill the entire screen.
	/// </summary>
	/// <param name="source">
	/// The source map layer tiles to expand.
	/// </param>
	/// <param name="position">
	/// The position of the tile that should be in the center of the screen.
	/// </param>
	/// <param name="filler">
	/// The tile that should be used to fill any empty spaces.
	/// </param>
	/// <param name="radius">
	/// The radius of the map in tiles.
	/// </param>
	/// <returns>
	/// The map, expanded to the specified radius.
	/// </returns>
	public static Tile?[][] GenerateView(this Tile?[][] source, Position position, Tile? filler, int radius = 10)
	{
		var diameter = (radius * 2) + 1;

		var deltaWest = radius - (int)position.East;
		var deltaEast = diameter - deltaWest - source.Length;
		var westExpansion = Math.Max(deltaWest, 0);
		var eastExpansion = Math.Max(deltaEast, 0);
		var sourceHorizontalStart = Math.Max((int)position.East - radius, 0);
		var sourceHorizontalViewLength = diameter - westExpansion - eastExpansion;

		var deltaNorth = radius - (int)position.South;
		var deltaSouth = diameter - deltaNorth - source[0].Length;
		var northExpansion = Math.Max(deltaNorth, 0);
		var southExpansion = Math.Max(deltaSouth, 0);
		var sourceVerticalStart = Math.Max((int)position.South - radius, 0);
		var sourceVerticalViewLength = diameter - northExpansion - southExpansion;

		var start = Enumerable.Repeat(Enumerable.Repeat(filler, diameter).ToArray(), westExpansion);
		var end = Enumerable.Repeat(Enumerable.Repeat(filler, diameter).ToArray(), eastExpansion);
		var north = Enumerable.Repeat(filler, northExpansion);
		var south = Enumerable.Repeat(filler, southExpansion);

		var middle = source
			.Skip(sourceHorizontalStart)
			.Take(sourceHorizontalViewLength)
			.Select(column => north
				.Concat(column
					.Skip(sourceVerticalStart)
					.Take(sourceVerticalViewLength))
				.Concat(south)
				.ToArray());

		return start
			.Concat(middle)
			.Concat(end)
			.ToArray();
	}
}
