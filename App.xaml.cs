﻿using Android.Content.Res;

namespace AndroidGunFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //MainPage = new NavigationPage(new Login());
        }
    }
}
