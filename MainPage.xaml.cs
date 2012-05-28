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
        int N = 6, M = 9;
        SolidColorBrush alive = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        SolidColorBrush dead = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        bool active = false;
        Button[,] button;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            button = new Button[N, M];
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

        private void AppBarStart(object sender, EventArgs e)
        {
            active = true; 
        }

        private void AppBarPause(object sender, EventArgs e)
        {
            active = false;
        }

        private void AppBarClear(object sender, EventArgs e)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    button[i, j].Background = dead;
        }

        private void AppBarRandomize(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (r.NextDouble() < 0.5)
                        button[i, j].Background = dead;
                    else
                        button[i, j].Background = alive;
        }
    }
}