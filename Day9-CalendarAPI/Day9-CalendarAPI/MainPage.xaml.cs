using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Microsoft.Phone.Tasks;
using System.Collections.Generic;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Recognition;   // For vocal recognition.
using Windows.Phone.Speech.Synthesis;   // For vocal synthesis.

namespace Day9_CalendarAPI
{
	public partial class MainPage : PhoneApplicationPage
	{
		Appointments appointments = new Appointments();
        public App app = (App)Application.Current;

        SpeechRecognizerUI recoWithUI;

       

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


        async void appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
		{
            SpeechSynthesizer synth = new SpeechSynthesizer();
            

			    if (e.Results.Count() == 0)
			    {
                    MessageText.Text = "Pas d'événements pour aujourd'hui ";
			    }
			    else
			    {
                    MessageText.Text = e.Results.Count() + " événements ";
				    DateList.ItemsSource = e.Results;

                    //await synth.SpeakTextAsync();
                    await synth.SpeakTextAsync(MessageText.Text);
                    
                    foreach (Appointment ap in e.Results)
                    {
                        
                        if (ap.StartTime.ToString() != null)
                            await synth.SpeakTextAsync(ap.StartTime.ToString());

                        if (ap.EndTime.ToString() != null)
                            await synth.SpeakTextAsync(ap.EndTime.ToString());

                        if(ap.Subject != null)
                        await synth.SpeakTextAsync(ap.Subject);

                        if (ap.Location != null)
                        await synth.SpeakTextAsync(ap.Location);

                        if (ap.Details != null)
                            await synth.SpeakTextAsync(ap.Details);
                       
                    }
			    }

		}

        private void AddEvent(object sender, EventArgs e)
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


        /* Voice Synthesizer Test */

        private void Test_voice(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Voice.xaml", UriKind.Relative));
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