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
        private List<CredentialModel> _credentialModels;

        public WinCredViewModel()
        {
            List<Credential> credentials = _credentials.CurrentCredentials.ToList();
            _windowsCredentials = new ObservableCollection<Credential>(credentials);
        }

        private List<CredentialModel> MapCredentialModels()
        {
            List<Credential> credentials = _credentials.CurrentCredentials.ToList();
            _credentialModels = new List<CredentialModel>();

            foreach (var credential in credentials)
            {
                var credModel = new CredentialModel
                {
                    Target = credential.Target,
                    Username = credential.Username,
                    Password = credential.Password,
                    LastWriteTime = credential.LastWriteTime
                };
                _credentialModels.Add(credModel);
            }

            return _credentialModels;
        }
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