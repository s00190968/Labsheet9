using System;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace MovieListing
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Movie> movieList = new ObservableCollection<Movie>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //when window is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //timer
            //create dispatcher timer object
            DispatcherTimer dt = new DispatcherTimer();

            //link this to  a method 
            dt.Tick += Dt_Tick;

            //set the interval
            dt.Interval = new TimeSpan(0, 0, 1);

            //start the thing
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            timeLbl.Content = DateTime.Now.ToLongTimeString();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            //add movie to list
            movieList.Add(new Movie(titleTxbx.Text, genreTxbx.Text, 1+(ratingCbx.SelectedIndex)));
            titleTxbx.Clear();
            genreTxbx.Clear();
            ratingCbx.SelectedIndex = 0;
            moviesLbx.ItemsSource = movieList;
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(moviesLbx.SelectedItem as Movie != null)
            {
                // remove selected item in movies listbox
                movieList.RemoveAt(moviesLbx.SelectedIndex);
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)//save list of movies to a file
        {
            //list of movies to string
            string json = JsonConvert.SerializeObject(movieList, Formatting.Indented);

            //write to file
            using (StreamWriter sw = new StreamWriter(@"Movies.json"))//file should go to the bin folder of the solution
            {
                sw.Write(json);
            }
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)//load movies from file
        {
            //connect to a file
            using (StreamReader sr = new StreamReader(@"Movies.json"))
            {
                //read from file
                string json = sr.ReadToEnd();

                //deserialize json/convert from
                movieList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);
            }
            moviesLbx.ItemsSource = movieList;
        }

        private void searchTbx_KeyUp(object sender, KeyEventArgs e)//search for item with same name as written in textbox
        {
            // read search term
            string search = searchTbx.Text;

            moviesLbx.ItemsSource = movieList.Where(m => m.Name.ToLower().Contains(search));
        }
    }
}
