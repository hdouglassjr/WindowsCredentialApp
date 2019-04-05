using CredentialManagement;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WindowsCredWpfApp.Model;

namespace WindowsCredWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        protected ListCollectionView collectionView;
        public MainWindow()
        {
            InitializeComponent();
            collectionView = (ListCollectionView) CollectionViewSource.GetDefaultView(LstItems.ItemsSource);
            collectionView.IsLiveFiltering = true;
            collectionView.LiveFilteringProperties.Add("Target");
            collectionView.Filter = CredentialListFilter;
            //var palette = new PaletteHelper().QueryPalette();
            //var hue = palette.AccentSwatch.AccentHues.ToArray()[palette.AccentHueIndex];
            //CredToolBar.Background = new SolidColorBrush(hue.Color);
            //LstItems.Background = new SolidColorBrush(hue.Color);
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
            if (string.IsNullOrEmpty(TxtFilter.Text))
            {
                return true;
            }
            else
            {
                return ((item as Credential).Target.IndexOf(TxtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void TxtSearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //RefreshList();
            collectionView.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: create trigger and message if 0 selected items
            foreach (var credentialModelItem in LstItems.SelectedItems)
            {
                ((Credential)credentialModelItem).Load();
                ((Credential)credentialModelItem).Password = TxtNewPassword.Text;
                var result = ((Credential)credentialModelItem).Save();
            }
            RefreshList();
        }
        private void RefreshList()
        {
            CollectionViewSource.GetDefaultView(LstItems.ItemsSource).Refresh();
        }
    }
}