namespace WpfRpg.Test;

[TestClass]
public class ArrayExtensionsTests
{
	[TestMethod]
	public void Test_2x2To5x5_1_1()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground
			},
			new[]
			{
				ground,
				ground
			},
		};

		var origin = new Position(1, 1);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_2x2To3x3_1_1()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground
			},
			new[]
			{
				ground,
				ground
			},
		};

		var origin = new Position(1, 1);

		var actual = input.GenerateView(origin, null, 1);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_2x2To5x5_0_0()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				null,
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground
			},
			new[]
			{
				ground,
				ground
			},
		};

		var origin = new Position(0, 0);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To5x5_2_2()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(2, 2);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To7x7_2_2()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null,
				null,
				null
			}
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(2, 2);

		var actual = input.GenerateView(origin, null, 3);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To5x5_2_0()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			},
			new Tile?[]
			{
				ground,
				ground,
				ground,
				null,
				null
			}
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(2, 0);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To5x5_0_2()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				ground,
				ground,
				ground
			},
			new Tile?[]
			{
				null,
				null,
				ground,
				ground,
				ground
			},
			new Tile?[]
			{
				null,
				null,
				ground,
				ground,
				ground
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			}
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(0, 2);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To5x5_1_1()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				ground,
				ground,
				ground,
				null
			},
			new Tile?[]
			{
				null,
				null,
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(1, 1);

		var actual = input.GenerateView(origin, null, 2);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}

	[TestMethod]
	public void Test_3x3To3x3_0_2()
	{
		var ground = new Tile("Grass", Enumerable.Empty<string>());

		var expected = new[]
		{
			new Tile?[]
			{
				null,
				ground,
				ground
			},
			new Tile?[]
			{
				null,
				ground,
				ground
			},
			new Tile?[]
			{
				null,
				null,
				null
			},
		};

		var input = new[]
		{
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
			new[]
			{
				ground,
				ground,
				ground
			},
		};

		var origin = new Position(0, 2);

		var actual = input.GenerateView(origin, null, 1);

		for (var i = 0; i < expected.Length; i++)
		{
			CollectionAssert.AreEqual(expected[i], actual[i]);
		}
	}
}
