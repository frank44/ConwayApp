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
        int N = 6, M = 10;
        SolidColorBrush alive = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        SolidColorBrush dead = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Button[,] button = new Button[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Width = 100;
                    button[i, j].Height = 100;
                    button[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    button[i, j].VerticalAlignment = VerticalAlignment.Top;
                    button[i, j].Click += new RoutedEventHandler(toggle);
                    button[i, j].Margin = new Thickness(75*i, 75*j, 0, 0);
                    
                    this.LayoutRoot.Children.Add(button[i, j]);
                }
            
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