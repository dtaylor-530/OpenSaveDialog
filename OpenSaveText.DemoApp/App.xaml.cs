


namespace OpenSaveText.DemoApp
{
    using System.ComponentModel;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        public string Path
        {
            get => System.IO.Path.GetFullPath((string)OpenSaveText.DemoApp.Settings.Default["Path"]);
            set
            {
                OpenSaveText.DemoApp.Settings.Default["Path"] = value;
                this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Path)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnStartup(StartupEventArgs e)
        {
            if (!DoesSettingExist("Path"))
            {
                MessageBox.Show("Close application and create 'Path' Setting in Properties.Settings to save the location of saved files.");
             }
            else if((string)OpenSaveText.DemoApp.Settings.Default["Path"] == string.Empty)
            {
                var di = new DirectoryInfo("Files");
                di.Create();
                OpenSaveText.DemoApp.Settings.Default["Path"] = di.FullName;
                OpenSaveText.DemoApp.Settings.Default.Save();

            }
            base.OnStartup(e);

            this.PropertyChanged += App_PropertyChanged;
        }

        private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        private bool DoesSettingExist(string settingName)
        {
            return OpenSaveText.DemoApp.Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }
    }



}
