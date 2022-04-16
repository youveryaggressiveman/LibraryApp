﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryApp.Core
{
    public static class FrameMangaer
    {
        public static Frame MainFrame { get; set; }

        public static void SetSource<T>(T target) where T : Page
        {
            var content = MainFrame.Content?.GetType();

            if (content != typeof(T))
            {
                MainFrame.Navigate(target);
                MainFrame.NavigationService.RemoveBackEntry();
                GC.Collect();
            }
        }
    }
}
