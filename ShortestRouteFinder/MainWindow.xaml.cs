using System.Windows;
using ShortestRouteFinder.ViewModel;


namespace ShortestRouteFinder.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; }
        //public RouteViewModel RouteViewModel { get; }
        //public GraphViewModel GraphViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();

            // Sätt ViewModel som DataContext för fönstret
            DataContext = new MainViewModel();
            //RouteViewModel = new RouteViewModel(DataContext);
            //GraphViewModel = new GraphViewModel(DataContext);
        }
    }
}
