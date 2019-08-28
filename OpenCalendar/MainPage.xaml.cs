﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<IOpenCal>(this, "CalendarAppMissing", (senderViewModel) =>
            {
                    DisplayAlert("Info", "No calendar app found on device", "OK");
            });
        }

        void OpenCalendar(object sender, EventArgs e)
        {
            DependencyService.Get<IOpenCal>().OpenCalendarApp();
        }
    }
}
