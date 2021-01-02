using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFPApp.Model;
using WFPApp.Model.Assistants;

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
            WindFarm = new WindFarm(WindFarmAssistant.windFarmName);

            ListWindTurbines = new List<WindTurbine>();

            for (int i = 0; i< WindFarmAssistant.numberOfWindTurbines; i++)
            {
                ListWindTurbines.Add(new WindTurbine(i, "Wind Turbine"));
            }

            TabItems = new ObservableCollection<WindTurbineViewModel>();

            for (int i = 0; i < WindFarmAssistant.numberOfWindTurbines; i++)
            {
                TabItems.Add(new WindTurbineViewModel(ListWindTurbines[i]));
            }

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