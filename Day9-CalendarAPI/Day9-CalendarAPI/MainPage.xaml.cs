using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Microsoft.Phone.Tasks;


namespace Day9_CalendarAPI
{
	public partial class MainPage : PhoneApplicationPage
	{
		Appointments appointments = new Appointments();
        public App app = (App)Application.Current;

		public MainPage()
		{
			InitializeComponent();

			appointments.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(appointments_SearchCompleted);
			SearchCalendar();
		}
           
		private void SearchCalendar()
		{
			appointments.SearchAsync(DateBox.Value.Value, DateBox.Value.Value.AddDays(7), null);
		}

		private void DateBox_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
		{
			SearchCalendar();
		}
        

         protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {

            base.OnNavigatedFrom(e);

        }
         public void Refresh()
         {

         }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);

        }

        
		void appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
		{
           

			    if (e.Results.Count() == 0)
			    {
				    MessageText.Text = "no events for the selected day";
			    }
			    else
			    {
				    MessageText.Text = e.Results.Count() + " events found";
				    DateList.ItemsSource = e.Results;
			    }

		}

        private void New(object sender, EventArgs e)
        {
           
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
            saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;
            saveAppointmentTask.Show();
        }

        /* Mode */
        private void Param(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mode.xaml", UriKind.Relative));
        }

        
        /*
         * 
         * 
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
            saveAppointmentTask.StartTime = DateTime.Now.AddHours(2);
            saveAppointmentTask.EndTime = DateTime.Now.AddHours(3);
            saveAppointmentTask.Subject = "Appointment subject";
            saveAppointmentTask.Location = "Appointment location";
            saveAppointmentTask.Details = "Appointment details";
            saveAppointmentTask.IsAllDayEvent = false;
            saveAppointmentTask.Reminder = Reminder.FifteenMinutes;
            saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;

            saveAppointmentTask.Show();
         * 
         */

    }
}