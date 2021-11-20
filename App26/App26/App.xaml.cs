using App26.Models;
using App26.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Distribute;

namespace App26
{
    public partial class App : Application
    {
        public static IEnumerable<Photo> Photos;
        public static int initalCall = 0;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<PhotosListDataStore>();
            DependencyService.Register<ParDetailsDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            AppCenter.Start("cf15e5bf-de2d-40a9-9334-cbcf36c8bae1",
                   typeof(Distribute));
         
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
