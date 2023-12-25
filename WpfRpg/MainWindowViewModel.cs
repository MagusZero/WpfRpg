namespace BlackOmen.WpfRpg;

using System;
using System.ComponentModel;
using System.Composition;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using BlackOmen.WpfRpg.GameViews;

/// <summary>
/// The core of the application's logic.
/// </summary>
[Export]
[Shared]
public class MainWindowViewModel : INotifyPropertyChanged
{
	private readonly OrthogonalMap mapView;
	private Control? mainContent;

	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
	/// </summary>
	/// <param name="mapView">
	/// A map view used to display map data.
	/// </param>
	[ImportingConstructor]
	public MainWindowViewModel([Import] OrthogonalMap mapView)
	{
		this.MainContent = this.mapView = mapView;

		this.PressedUpCommand = new DelegateCommand(this.mapView.ViewModel.GoNorth);
		this.PressedDownCommand = new DelegateCommand(this.mapView.ViewModel.GoSouth);
		this.PressedLeftCommand = new DelegateCommand(this.mapView.ViewModel.GoWest);
		this.PressedRightCommand = new DelegateCommand(this.mapView.ViewModel.GoEast);

		var directory = AppDomain.CurrentDomain.BaseDirectory;
		var mapPath = Path.Join(directory, "Content", "Island.xml");
		var document = XDocument.Load(mapPath);

		var root = document.Root;
		if(root is not null)
		{
			var map = Map.FromXml(root);
			this.mapView.ViewModel.Map = map;
			this.mapView.ViewModel.Position = new Position(5, 5);
		}
	}

	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Gets or sets the content of the main window.
	/// </summary>
	public Control? MainContent
	{
		get => this.mainContent;
		set
		{
			if (this.mainContent != value)
			{
				this.mainContent = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.MainContent)));
			}
		}
	}

	/// <summary>
	/// Gets a command that should be executed when the up button is pressed.
	/// </summary>
	public ICommand PressedUpCommand { get; }

	/// <summary>
	/// Gets a command that should be executed when the down button is pressed.
	/// </summary>
	public ICommand PressedDownCommand { get; }

	/// <summary>
	/// Gets a command that should be executed when the left button is pressed.
	/// </summary>
	public ICommand PressedLeftCommand { get; }

	/// <summary>
	/// Gets a command that should be executed when the right button is pressed.
	/// </summary>
	public ICommand PressedRightCommand { get; }
}
