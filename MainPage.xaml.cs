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
using System.Windows.Threading;

namespace ConwayApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        int N = 18; //width
        int M = 22; //length
        DispatcherTimer timer = new DispatcherTimer();

        //For the randomization feature
        double spawnRate = 0.14;

        //Possible background states
        SolidColorBrush alive = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
        SolidColorBrush dead = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        
        //Grid of buttons
        Button[,] button;

        //Directional arrays
        int[] di = {-1, -1, -1, 0, 1, 1, 1, 0};
        int[] dj = {-1, 0, 1, 1, 1, 0, -1, -1};

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            button = new Button[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Width = 50;
                    button[i, j].Height = 50;
                    button[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    button[i, j].VerticalAlignment = VerticalAlignment.Top;
                    button[i, j].Click += new RoutedEventHandler(toggle);
                    button[i, j].Margin = new Thickness(25*i, 25*j, 0, 0);
                    
                    this.LayoutRoot.Children.Add(button[i, j]);
                }

            slider1.Value = 5; //set to initial value
            timer.Tick += new EventHandler(simulateStep);
            timer.Interval = TimeSpan.FromSeconds(1-slider1.Value/10);
        }

        private void toggle(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            
            if (isAlive(b)) b.Background = dead;
            else b.Background = alive;
        }

        private bool isValid(int i, int j)
        { return i >= 0 && i < N && j >= 0 && j < M; }

        private bool isAlive(int i, int j)
        { return button[i, j].Background == alive; }

        private bool isAlive(Button b)
        { return b.Background == alive; }

        private void simulateStep(object sender, EventArgs e)
        {
            for (int i=0; i<N; i++)
                for (int j = 0; j < M; j++)
                {
                    int count = 0;
                    bool isLiving = isAlive(i, j);
                    for (int k = 0; k < di.Length; k++)
                    {
                        int ni = (i + di[k]);
                        int nj = (j + dj[k]);
                        if (isValid(ni, nj) && isAlive(ni, nj))
                            count++;
                    }
                        
                    if (isLiving && count < 2) //under-population
                        button[i, j].Background = dead;
                    else if (isLiving && count > 3) //overcrowding
                        button[i, j].Background = dead;
                    else if (!isLiving && count == 3) //reproduction
                        button[i, j].Background = alive;
                }
        }

        private void AppBarStart(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void AppBarPause(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void AppBarClear(object sender, EventArgs e)
        {
            timer.Stop();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    button[i, j].Background = dead;
        }

        private void AppBarRandomize(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (r.NextDouble() < spawnRate)
                        button[i, j].Background = alive;
                    else
                        button[i, j].Background = dead;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = (Slider)sender;
            timer.Interval = TimeSpan.FromSeconds(1-s.Value / 10);
        }
    }
}