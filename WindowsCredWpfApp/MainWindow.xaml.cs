using CredentialManagement;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WindowsCredWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly ListCollectionView _credentialCollectionView;
        public MainWindow()
        {
            InitializeComponent();
            _credentialCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(LstItems.ItemsSource);
            _credentialCollectionView.IsLiveFiltering = true;
            _credentialCollectionView.LiveFilteringProperties.Add("Target");
            _credentialCollectionView.Filter = CredentialListFilter;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LstItems.SelectAll();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LstItems.UnselectAll();
        }

        private bool CredentialListFilter(object item)
        {
            if (string.IsNullOrEmpty(FilterText.Text))
                return true;
            return ((Credential)item).Target.IndexOf(FilterText.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void TxtSearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _credentialCollectionView.Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            if (LstItems.SelectedItems.Count == 0)
            {
                this.ShowMessageAsync("Update Error", "You must make at least one selection to update.");
                return;
            }

            if (TxtNewPassword.Password.Length < 8)
            {
                this.ShowMessageAsync("Update Password Error", "Password length must be at least 8 characters.");
                return;
            }

            foreach (var credentialModelItem in LstItems.SelectedItems)
            {
                ((Credential)credentialModelItem).Load();
                ((Credential)credentialModelItem).SecurePassword = TxtNewPassword.SecurePassword;
                ((Credential)credentialModelItem).Save();
                builder.Append(((Credential)credentialModelItem).Target);
            }

            this.ShowMessageAsync("Success!",
                $"The following selected credential password(s) updated:  {builder}");
            LstItems.SelectedItems.Clear();
            TxtNewPassword.Password = string.Empty;
            FilterText.Text = string.Empty;
            CheckAllBox.IsChecked = false;
            RefreshList();

        }
        private void RefreshList()
        {
            CollectionViewSource.GetDefaultView(LstItems.ItemsSource).Refresh();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            if (LstItems.SelectedItems.Count == 0)
            {
                this.ShowMessageAsync("Delete Error", "You must make at least one selection to delete.");
                return;
            }

            foreach (var credentialModelItem in LstItems.SelectedItems)
            {
                ((Credential)credentialModelItem).Load();
                builder.Append(((Credential)credentialModelItem).Target);
                ((Credential)credentialModelItem).Delete();
                
            }
            LstItems.SelectedItems.Clear();
            this.ShowMessageAsync("Success!",
                $"The following selected credential password(s) deleted:  {builder}");
            FilterText.Text = string.Empty;
            RefreshList();
        }
    }
}