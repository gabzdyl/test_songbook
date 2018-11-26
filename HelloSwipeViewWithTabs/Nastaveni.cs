﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloSwipeViewWithTabs
{
    static class Nastaveni
    {
        //na zrušení
        public static bool SnackBar { get; set; }
        public static bool Red { get; set; }

        //view2

        public static bool Alphabetically { get; set; }

        //view3

        public static Song SelectedSong { get; set; }
        public static bool Center { get; set; }
        public static bool BigFont { get; set; }//small=17dp, big=21dp
        public static bool ChorusMany { get; set; }
        public static bool NoLineBreaks { get; set; }
        private static string _folder = "Tylko Mu Wierz";

        public static string SelectedFolder
        {
            get { return _folder; }
            set { _folder = value; }
        }











        static string last_songbook;

        public static void SetView2()
        {
            if (PageFragment.view2 == null)
                return;

            if (SelectedFolder != last_songbook)
            {
                PageCreator.RefreshListView();
                last_songbook = SelectedFolder;
            }
        }


        public static void SetView3()
        {
            if (PageFragment.view3 == null)
                return;

            if (Nastaveni.SelectedSong == null)
            {
                Toast.MakeText(MainActivity.MyContext, "Błąd!", ToastLength.Short).Show();
                return;
            }

            TextView tvTytul = PageFragment.view3.FindViewById<TextView>(Resource.Id.tvTytul);
            tvTytul.Text = Nastaveni.SelectedSong.Tytul;

            TextView tvNumer = PageFragment.view3.FindViewById<TextView>(Resource.Id.tvNumer);
            tvNumer.Text = Nastaveni.SelectedSong.Numer.ToString();

            TextView tvTonacja = PageFragment.view3.FindViewById<TextView>(Resource.Id.tvTonacja);
            tvTonacja.Text = Nastaveni.SelectedSong.Tonacja;

            TextView tvSlowa = PageFragment.view3.FindViewById<TextView>(Resource.Id.tvSlowa);
            tvSlowa.Text = Nastaveni.SelectedSong.SlowaToDisplay;

            if (Nastaveni.Center)
                tvSlowa.Gravity = GravityFlags.CenterHorizontal;
            else
                tvSlowa.Gravity = GravityFlags.NoGravity;

            if (Nastaveni.BigFont)
                tvSlowa.SetTextSize(Android.Util.ComplexUnitType.Dip, 21);
            else
                tvSlowa.SetTextSize(Android.Util.ComplexUnitType.Dip, 17);
        }
    }
}