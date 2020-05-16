


namespace OpenSaveText.DemoWpf
{
    using System.ComponentModel;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using OpenSaveText.DemoWpf.Properties;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        public string Path
        {
            get => System.IO.Path.GetFullPath((string)Settings.Default["Path"]);
            set
            {
                Settings.Default["Path"] = value;
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
            else if((string)Settings.Default["Path"] == string.Empty)
            {
                var di = new DirectoryInfo("Files");
                di.Create();
                Settings.Default["Path"] = di.FullName;
                Settings.Default.Save();

            }
            base.OnStartup(e);

            this.PropertyChanged += App_PropertyChanged;
        }

        private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        private bool DoesSettingExist(string settingName)
        {
            return Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }
    }



}
