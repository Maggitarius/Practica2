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
using FirstPractice1.LibraryDatabaseDataSetTableAdapters;

namespace FirstPractice1
{
    public partial class WindowAddA : Window
    {
        AuthorsTableAdapter authorsTable = new AuthorsTableAdapter();
        public WindowAddA()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int AuthorBirthYear = 0;
            int AuthorDeathYear = 0;

            if (int.TryParse(AuthorBirth.Text, out AuthorBirthYear) && int.TryParse(AuthorDeath.Text, out AuthorDeathYear))
            {
                authorsTable.InsertQuery(AuthorSurName.Text, AuthorName.Text, AuthorMiddleName.Text, AuthorBirthYear, AuthorDeathYear);
                Authors.ItemsSource = authorsTable.GetData();
            }
        }
    }
}