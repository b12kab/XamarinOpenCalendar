using System;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OpenCalendar.iOS.CalSupport))]
namespace OpenCalendar.iOS
{
    public class CalSupport : IOpenCal
    {
        public void OpenCalendarApp()
        {
            //Xamarin info
            // https://stackoverflow.com/questions/39491275/xamarin-ios-launching-external-apps
            // https://stackoverflow.com/questions/43944283/launch-another-ios-app-from-xamarin-forms-app

            //iOS schemes
            // https://ios.gadgethacks.com/news/always-updated-list-ios-app-url-scheme-names-0184033/
            // http://iosdevelopertips.com/cocoa/launching-your-own-application-via-a-custom-url-scheme.html

            //iOS Swift example
            // https://developer.apple.com/library/archive/samplecode/LaunchMe/Introduction/Intro.html#//apple_ref/doc/uid/DTS40007417-Intro-DontLinkElementID_2

            string calendarUrl = "calshow://";
            NSUrl appUrl = new NSUrl(calendarUrl);

            if (UIApplication.SharedApplication.CanOpenUrl(appUrl))
            {
                UIApplication.SharedApplication.OpenUrl(appUrl);
            }
            else
            {
                MessagingCenter.Send<IOpenCal>(this, "CalendarAppMissing");
            }
        }
    }
}
