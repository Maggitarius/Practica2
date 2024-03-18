using System;
using System.Collections.Generic;
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
using FirstPractice2;

namespace FirstPractice1
{
    public partial class Page1 : Page
    {
        private LibraryDatabaseEntities library = new LibraryDatabaseEntities();
        public Page1()
        {
            InitializeComponent();
            bebra.ItemsSource = library.Authors.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAddA winAdd = new WindowAddA();
            winAdd.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (bebra.SelectedItem != null)
            {
                var selected = bebra.SelectedItem as Authors;

                NewSurname.Text = selected.AuthorSurname;
                NewName.Text = selected.AuthorName;
                NewMiddlename.Text = selected.AuthorMiddlename;
                selected.DateOfBirth = Convert.ToInt32(NewBirth.Text);
                selected.DeathDates = Convert.ToInt32(NewDeath.Text);

                library.SaveChanges();
                bebra.ItemsSource = library.Authors.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (bebra.SelectedItem != null)
            {
                library.Authors.Remove(bebra.SelectedItem as Authors);

                library.SaveChanges();
                bebra.ItemsSource = library.Authors.ToList();
            }
        }
    }
}

