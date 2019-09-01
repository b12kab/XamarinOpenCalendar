using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.PM;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OpenCalendar.Droid.CalSupport))]
namespace OpenCalendar.Droid
{
    public class CalSupport : IOpenCal
    {
        // https://stackoverflow.com/questions/42360376/set-reminder-on-device-calendar-using-xamarin-forms-cross-platform-c-sharp 
        // https://forums.xamarin.com/discussion/17001/how-do-i-open-the-android-calender-app-using-an-intent
        public void OpenCalendarApp()
        {
            var context = Android.App.Application.Context;
            // https://forums.xamarin.com/discussion/19857/how-to-access-packagemanager-and-start-activity-from-a-non-activity-based-class
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("content://com.android.calendar/time/"));

            // Get list of calendars
            IList<ResolveInfo> activityList = context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            // If there are not any calendar installed, show error message
            if (activityList.Count == 0)
            {
                MessagingCenter.Send<IOpenCal>(this, "CalendarAppMissing");
                return;
            }

            Android.App.Activity act = CrossCurrentActivity.Current.Activity;
            act.StartActivity(intent);
        }
    }
}
