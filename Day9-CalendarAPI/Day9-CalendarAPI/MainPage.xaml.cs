using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;

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

	}
}