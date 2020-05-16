using System.Windows;

namespace OpenSaveText.DemoApp
{
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
