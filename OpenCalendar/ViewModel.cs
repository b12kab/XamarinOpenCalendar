using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OpenCalendar
{
    public class ViewModel : INotifyPropertyChanged
    {
        public INavigation _navigation;
        public ICommand ShowCalCommand { get; private set; }

        public ViewModel(INavigation navigation)
        {
            _navigation = navigation;

            ShowCalCommand = new Command(async () => await ShowCalendar());
        }

        async Task ShowCalendar()
        {
            DependencyService.Get<IOpenCal>().OpenCalendarApp();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
