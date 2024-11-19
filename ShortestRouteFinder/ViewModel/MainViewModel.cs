using ShortestRouteFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShortestRouteFinder.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Route> Routes { get; set; }

        private Route _selectedRoute;
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
            }
        }

        public MainViewModel()
        {
            Routes = new ObservableCollection<Route>(LoadRoutes());
        }

        private List<Route> LoadRoutes()
        {
            var json = File.ReadAllText("routes.json");
            return JsonConvert.DeserializeObject<List<Route>>(json);
        }

        private List<Route> SortRoutes(List<Route> UnsortedRoutes)
        {
       
            for (int i = 0; i < UnsortedRoutes.Count - 1; i++)
            {
                for (int j = 0; j < UnsortedRoutes.Count - i - 1; j++)
                {
                    if (UnsortedRoutes[j].Distance > UnsortedRoutes[j + 1].Distance)
                    {
                        // Swap the elements
                        Route tempRoute = UnsortedRoutes[j];
                        UnsortedRoutes[j] = UnsortedRoutes[j + 1];
                        UnsortedRoutes[j + 1] = tempRoute;
                    }
                }
            }
            return UnsortedRoutes;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
