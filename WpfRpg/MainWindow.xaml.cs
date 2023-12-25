namespace BlackOmen.WpfRpg;

using System.Composition;
using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
[Export]
[Shared]
public partial class MainWindow : Window
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	/// <param name="viewModel">
	/// The viewmodel used by the main window.
	/// </param>
	[ImportingConstructor]
	public MainWindow([Import] MainWindowViewModel viewModel)
	{
		this.DataContext = viewModel;
		this.InitializeComponent();
	}
}
