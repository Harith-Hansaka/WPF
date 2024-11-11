using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.STORES;

namespace UNDAI.VIEWMODELS.BASE
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;


        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }  
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged ;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}