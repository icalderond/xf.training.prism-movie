﻿using System;
using PrismMovie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismMovie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SearchPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
