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

namespace OpenSaveText.DemoWpf
{
    using System.Collections.ObjectModel;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ICollection<object> Collection { get; } = new ObservableCollection<object>();

        public MainWindow()
        {
            InitializeComponent();
            //OpenSaveControl.Change += OpenSaveControl_FileObjectChanged;
        }

        //private void OpenSaveControl_FileObjectChanged(object sender, RoutedEventArgs e)
        //{
        //    Collection.Add((e as OpenSaveControl.FileObjectChangedEventArgs).FileObject);
        //}
    }
}
