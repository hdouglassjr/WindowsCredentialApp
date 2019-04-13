using CredentialManagement;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WindowsCredentialLib;
using WindowsCredWpfApp.Model;

namespace WindowsCredWpfApp.ViewModels
{
    public class WinCredViewModel : INotifyPropertyChanged
    {
        private readonly WinCredImpl _credentials = new WinCredImpl();
        private ObservableCollection<Credential> _windowsCredentials;

        public WinCredViewModel()
        {
            List<Credential> credentials = _credentials.CurrentCredentials.ToList();
            _windowsCredentials = new ObservableCollection<Credential>(credentials);
        }
        //TODO:Add delete call and wire into UI with a delete button/click event.
      
        public ObservableCollection<Credential> Credentials
        {
            get => _windowsCredentials;
            set
            {
                _windowsCredentials = value;
                OnPropertyChanged("Credentials");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}