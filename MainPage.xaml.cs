using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ConwayApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        //int n, m;
        SolidColorBrush alive = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        SolidColorBrush dead = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));


        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void toggle(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            
            if (b.Background == alive)
                b.Background = dead;
            else b.Background = alive;
        }

    }
}