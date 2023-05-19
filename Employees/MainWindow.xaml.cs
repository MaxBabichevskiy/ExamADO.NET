using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentRepository studentRepository;

        public ObservableCollection<Student> Students { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
            Students = new ObservableCollection<Student>(studentRepository.GetStudents());
            DataContext = this;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;
            Students = new ObservableCollection<Student>(studentRepository.SearchStudents(searchText));
            RefreshDataGrid();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Students = new ObservableCollection<Student>(studentRepository.GetStudents());
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = Students;

        }

    }
}
