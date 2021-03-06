﻿using getFood.Mobile.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace getFood.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{Id = MenuItemType.Profil, Title="Profil", ImageSource="user.png"},
                new HomeMenuItem {Id = MenuItemType.Restorani, Title="Restorani", ImageSource="restoran.png" },
                new HomeMenuItem {Id = MenuItemType.Korpa, Title="Korpa", ImageSource="cart.png" }
              
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

        

        }
    }
}