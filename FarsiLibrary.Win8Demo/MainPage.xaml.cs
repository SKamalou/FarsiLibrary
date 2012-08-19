using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FarsiLibrary.Win8Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ShowDate(object sender, RoutedEventArgs e)
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine("Current application context language: " + ApplicationLanguages.Languages[0]);
            results.AppendLine();

            // Create template-based date/time formatters. 
            DateTimeFormatter[] templateFormatters = new[] 
            { 
                // Formatters for dates. 
                new DateTimeFormatter("day month"), 
                new DateTimeFormatter("month year"), 
                new DateTimeFormatter("day month year"), 
                new DateTimeFormatter("dayofweek day month year"), 
                new DateTimeFormatter("dayofweek.abbreviated"), 
                new DateTimeFormatter("month.abbreviated"), 
                new DateTimeFormatter("year.abbreviated"), 
 
                // Formatters for time. 
                new DateTimeFormatter("hour"), 
                new DateTimeFormatter("hour minute"), 
                new DateTimeFormatter("hour minute second"), 
             };

            // Create date/time to format and display. 
            DateTime dateTime = DateTime.Now;

            // Try to format and display date/time if calendar supports it. 
            foreach (DateTimeFormatter formatter in templateFormatters)
            {
                try
                {
                    // Format and display date/time. 
                    results.AppendLine(formatter.Template + ": " + formatter.Format(dateTime));
                }
                catch (ArgumentException)
                {
                    // Retrieve and display formatter properties.  
                    results.AppendLine(String.Format(
                        "Unable to format Gregorian DateTime {0} using formatter with template {1} for languages [{2}], region {3}, calendar {4} and clock {5}",
                        dateTime,
                        formatter.Template,
                        string.Join(",", formatter.Languages),
                        formatter.GeographicRegion,
                        formatter.Calendar,
                        formatter.Clock));
                }
            }

            currentdate.Text = results.ToString();
            // Display the results 
            /// NotifyUser(results.ToString(), NotifyType.StatusMessage); 
        }
    }
}
