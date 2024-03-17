using System;
using System.Collections.Generic;
using System.Data;
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
using FirstPractice1.LibraryDatabaseDataSetTableAdapters;

namespace FirstPractice1
{
    public partial class Page1 : Page
    {
        AuthorsTableAdapter authors = new AuthorsTableAdapter();
        public Page1()
        {
            InitializeComponent();
            Authors.ItemsSource = authors.GetData();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAddA winAdd = new WindowAddA();
            winAdd.Show();
            Authors.ItemsSource = authors.GetData();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Authors.SelectedItem as DataRowView).Row[0];
            authors.UpdateQuery(NewSurname.Text, NewName.Text, NewMiddlename.Text, Convert.ToInt32(NewBirth.Text), Convert.ToInt32(NewDeath.Text), Convert.ToInt32(id));
            Authors.ItemsSource = authors.GetData();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Authors.SelectedItem as DataRowView).Row[0];
            authors.DeleteQuery(Convert.ToInt32(id));
            Authors.ItemsSource = authors.GetData();
        }
    }
} 