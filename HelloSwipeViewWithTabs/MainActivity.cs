﻿using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;
using Android.Content;
using static Android.Support.V4.View.ViewPager;

namespace HelloSwipeViewWithTabs
{
    [Activity(Label = "Tylko Mu Wierz", MainLauncher = true, Icon = "@mipmap/ic_launcher", RoundIcon = "@mipmap/ic_launcher_round")]
    public class MainActivity : AppCompatActivity
    {
        public static Context MyContext;
        public static Activity MyActivity;
        public static ViewPager MyPager;
        public static ListView MyListView;
        public static MyAdapter<Song> MyAdapter;
        public static FloatingActionButton MyFab;
        public static Android.Widget.SearchView MySearchView;
        public static ScrollView MyScrollView;
        public static TabLayout MyTabLayout;

        public override void OnBackPressed()
        {
            switch (MainActivity.MyPager.CurrentItem)
            {
                //case 3:
                //    MainActivity.MyPager.SetCurrentItem(2, true);
                //    break;
                case 2:
                    MainActivity.MyPager.SetCurrentItem(1, true);
                    break;
                case 1:
                    MainActivity.MyPager.SetCurrentItem(0, true);
                    break;
                default:
                    base.OnBackPressed();
                    break;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MyContext = this.ApplicationContext;

            MyActivity = this;

            Nastaveni.ChorusMany = Nastaveni.GetSetting("ChorusMany");
            Nastaveni.Center = Nastaveni.GetSetting("Center");
            Nastaveni.BigFont = Nastaveni.GetSetting("BigFont");
            Nastaveni.NoLineBreaks = Nastaveni.GetSetting("NoLineBreaks");

            DataManager.LoadSongs();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

            // Find views
            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            var adapter = new CustomPagerAdapter(this, SupportFragmentManager);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.my_toolbar);

            MyPager = pager;
            //IOnPageChangeListener l = new 
            pager.AddOnPageChangeListener(new MyOnPageChangeListener());

            // Setup Toolbar
            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "Test";

            // Set adapter to view pager
            pager.Adapter = adapter;
            //pager.SetCurrentItem(0, false);

            // Setup tablayout with view pager
            tabLayout.SetupWithViewPager(pager, true);
            MyTabLayout = tabLayout;

            Nastaveni.HideHeader = Nastaveni.GetSetting("HideHeader");
            Nastaveni.HideStatusBar = Nastaveni.GetSetting("HideStatusBar");
            Nastaveni.LockPortrait = Nastaveni.GetSetting("LockPortrait");

            // Iterate over all tabs and set the custom view
            for (int i = 0; i < tabLayout.TabCount; i++)
            {
                TabLayout.Tab tab = tabLayout.GetTabAt(i);
                tab.SetCustomView(adapter.GetTabView(i));
            }
        }
    }
}

