﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ForgroundService
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static MainActivity activityCurrent { get; set; }

        public MainActivity()
        {
            activityCurrent = this;
        }
    }
}
