namespace BlackOmen.WpfRpg.GameViews;

using System.Composition;
using System.Windows.Controls;

/// <summary>
/// Interaction logic for OrthogonalMap.xaml.
/// </summary>
[Export]
public partial class OrthogonalMap : UserControl
{
	/// <summary>
	/// Initializes a new instance of the <see cref="OrthogonalMap"/> class.
	/// </summary>
	/// <param name="viewModel">
	/// The viewmodel to back this view.
	/// </param>
	[ImportingConstructor]
	public OrthogonalMap([Import] OrthogonalMapViewModel viewModel)
	{
		this.DataContext = viewModel;
		this.InitializeComponent();
	}

	/// <summary>
	/// Gets the viewmodel for this view.
	/// </summary>
	public OrthogonalMapViewModel ViewModel => (OrthogonalMapViewModel)this.DataContext;
}
