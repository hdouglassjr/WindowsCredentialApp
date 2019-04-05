using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsCredWpfApp.Annotations;
using CredentialManagement;

namespace WindowsCredWpfApp.Model
{
    public class CredentialModel : INotifyPropertyChanged
    {
        private string _target;
        private string _username;
        private string _password;
        private DateTime _lastWriteTime;
        private CredentialType _type;

        public CredentialType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => _username;
            set { _username = value;
                OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastWriteTime
        {
            get => _lastWriteTime;
            set
            {
                _lastWriteTime = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}