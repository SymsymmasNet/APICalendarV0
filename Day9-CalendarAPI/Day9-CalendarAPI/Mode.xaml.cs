using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Day9_CalendarAPI
{
    public partial class Paramtre : PhoneApplicationPage
    {
        public Paramtre()
        {
            InitializeComponent();
        }

        /* Privé */
        private void inPrivateActivated_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPrivateActivated.IsChecked == true)
            {
                Console.Write("Mode privé !");
            }
        }

        private void inPrivateAutomatic_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPrivateAutomatic.IsChecked == true)
            {
                Console.Write("Mode Automatic privé !");
            }
        }

        private void inPrivateAsk_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPrivateAsk.IsChecked == true)
            {
                Console.Write("Mode Demande privé !");
            }
        }

        private void inPrivateWarn_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPrivateWarn.IsChecked == true)
            {
                Console.Write("Mode Warn privé !");
            }
        }
        
        /* Public */ 
        private void inPublicActivated_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPublicActivated.IsChecked == true)
            {
                Console.Write("Mode public !");
            }
        }
       
        private void inPublicAutomatic_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPublicAutomatic.IsChecked == true)
            {
                // Do something  
                Console.Write("Mode Automatic public !");
            } 
            
        }

        private void inPublicAsk_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPublicAsk.IsChecked == true)
            {
                Console.Write("Mode Demande public !");
            }  
      }

        private void inPublicWarn_Checked(object sender, RoutedEventArgs e)
        {
            if (this.inPublicWarn.IsChecked == true)
            {
                Console.Write("Mode Warn public !");
            }
        }

        /*
        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {
            Console.Write("Mode ");
        }
        */
       


    }
}