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
using System.Windows.Shapes;

namespace FirstPractice2
{
    public partial class WindowAddA : Window
    {
        private LibraryDatabaseEntities library = new LibraryDatabaseEntities();
        public WindowAddA()
        {
            InitializeComponent();
            Authors.ItemsSource = library.Authors.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Authors a = new Authors();
            a.AuthorSurname = AuthorSurName.Text;
            a.AuthorName = AuthorName.Text;
            a.AuthorMiddlename = AuthorMiddleName.Text;
            a.DateOfBirth = Convert.ToInt32(AuthorBirth.Text);
            a.DeathDates = Convert.ToInt32(AuthorDeath.Text);

            library.Authors.Add(a);

            library.SaveChanges();
            Authors.ItemsSource = library.Authors.ToList();
        }
    }
}
