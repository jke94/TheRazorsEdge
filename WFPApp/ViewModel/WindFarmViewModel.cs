using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFPApp.Model;

namespace WFPApp.ViewModel
{
    public class WindFarmViewModel : INotifyPropertyChanged
    {
        private WindFarm windfarm;
        private IList<WindTurbine> listWindTurbines;
        private ObservableCollection<WindTurbineViewModel> tabItems;
        private WindTurbineViewModel selectedTab;

        public WindFarmViewModel()
        {
            WindFarm = new WindFarm("The Wind Farm Park");

            ListWindTurbines = new List<WindTurbine>()
            { 
                new WindTurbine(0, "Wind Turbine"),
                new WindTurbine(1, "Wind Turbine"),
                new WindTurbine(2, "Wind Turbine")
            };

            TabItems = new ObservableCollection<WindTurbineViewModel>();
            TabItems.Add(new WindTurbineViewModel(ListWindTurbines[0]));
            TabItems.Add(new WindTurbineViewModel(ListWindTurbines[1]));
            TabItems.Add(new WindTurbineViewModel(ListWindTurbines[2]));
            SelectedTab = TabItems[0];
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public WindFarm WindFarm
        {
            get
            {
                return Windfarm;
            }

            private set
            {
                Windfarm = value;
                OnPropertyChanged(nameof(WindFarm));
            }
        }

        public ObservableCollection<WindTurbineViewModel> TabItems 
        {
            get
            {
                return tabItems;
            }
            
            private set
            {
                tabItems = value;
                OnPropertyChanged(nameof(TabItems));
            }
        }

        public WindTurbineViewModel SelectedTab
        {
            get
            {
                return selectedTab;
            }

            set
            {
                selectedTab = value;
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        public IList<WindTurbine> ListWindTurbines
        {
            get
            {
                return listWindTurbines;
            }

            set
            {
                listWindTurbines = value;
                OnPropertyChanged(nameof(ListWindTurbines));
            }
        }

        public WindFarm Windfarm
        {
            get
            {
                return windfarm;
            }

            set
            {
                windfarm = value;
                OnPropertyChanged(nameof(Windfarm));
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}