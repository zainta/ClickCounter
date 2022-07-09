using Counter.Data;
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

namespace Counter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ValueTracker _counter;

        public MainWindow()
        {
            InitializeComponent();

            _counter = new ValueTracker();
            DataContext = _counter;
        }

        private void btnAnother_Click(object sender, RoutedEventArgs e)
        {
            _counter.Value++;
        }
    }
}
