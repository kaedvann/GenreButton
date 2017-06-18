using System.IO;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Microsoft.Win32;

namespace GenreButton
{
	public class MainViewModel : PropertyChangedBase
	{
		private string _filename;

		public MainViewModel()
		{
			BrowseCommand = new DelegateCommand(Browse);
			AnalyzeCommand = new DelegateCommand(Analyze, o => CanAnalyze());
		}

		public DelegateCommand BrowseCommand { get; }
		public DelegateCommand AnalyzeCommand { get; }

		public BindableCollection<string> Genres { get; } = new BindableCollection<string>() {"TestRock", "TestMeal"};

		public bool CanAnalyze() => !string.IsNullOrEmpty(Filename) && File.Exists(Filename);

		public string Filename
		{
			get { return _filename; }
			set
			{
				_filename = value;
				NotifyOfPropertyChange();
				AnalyzeCommand.RaiseCanExecuteChanged();
			}
		}

		public void Analyze()
		{
			
		}

		public void Browse()
		{
			var openFileDialog = new OpenFileDialog
			{
				CheckFileExists = true,
				
			};
			
			// Show open file dialog box
			var result = openFileDialog.ShowDialog();

			// Process open file dialog box results
			if (result != null && result.Value)
			{
				// Open document
				Filename = openFileDialog.FileName;
			}
		}
	}
}