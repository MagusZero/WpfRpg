namespace BlackOmen.WpfRpg;

using System.Composition.Hosting;
using System.Windows;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
	/// <inheritdoc/>
	protected override void OnStartup(StartupEventArgs e)
	{
		var configuration = new ContainerConfiguration();
		configuration.WithAssembly(typeof(App).Assembly);
		var container = configuration.CreateContainer();
		var window = container.GetExport<MainWindow>();
		window.Show();
	}
}
