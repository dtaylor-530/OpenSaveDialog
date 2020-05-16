

namespace OpenSave.Wpf
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;


    public class OpenSaveEditorControl : Control, Contracts.IPath
    {
        private OpenSaveControl OpenSaveControl;

        public override void OnApplyTemplate()
        {
            //  < buttonsControl:EventCommandExecuter Command = "{Binding ElementName=OpenSaveControl, Path=SetFileObjectCommand}" />
            OpenSaveControl = (this.GetTemplateChild("OpenSaveControl") as OpenSaveControl);

            this.OpenSaveControl.ObjectChange += OpenSaveControl_FileObjectChanged;
         
        }

        private void OpenSaveControl_FileObjectChanged(object sender, ObjectChangeEventArgs e)
        {
            var xx = ObjectConverter == null
                         ? (e as ObjectChangeEventArgs).Object
                         : ObjectConverter.ConvertBack(e.Object, null, null, null);
            Content.Command.Execute(e);
        }

        static OpenSaveEditorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OpenSaveEditorControl), new FrameworkPropertyMetadata(typeof(OpenSaveEditorControl)));
        }


        public object TextObjectConverter
        {
            get { return (object)GetValue(TextObjectConverterProperty); }
            set { SetValue(TextObjectConverterProperty, value); }
        }


        public static readonly DependencyProperty TextObjectConverterProperty = DependencyProperty.Register("TextObjectConverter", typeof(object), typeof(OpenSaveEditorControl), new PropertyMetadata(null));


        public object FileService
        {
            get { return (object)GetValue(FileServiceProperty); }
            set { SetValue(FileServiceProperty, value); }
        }


        public static readonly DependencyProperty FileServiceProperty = DependencyProperty.Register("FileService", typeof(object), typeof(OpenSaveEditorControl), new PropertyMetadata(null));




        public object DirectoryService
        {
            get { return (object)GetValue(DirectoryServiceProperty); }
            set { SetValue(DirectoryServiceProperty, value); }
        }


        public static readonly DependencyProperty DirectoryServiceProperty = DependencyProperty.Register("DirectoryService", typeof(object), typeof(OpenSaveEditorControl), new PropertyMetadata(null));




        public IValueConverter FileObjectToKeyConverter
        {
            get { return (IValueConverter)GetValue(FileObjectToKeyConverterProperty); }
            set { SetValue(FileObjectToKeyConverterProperty, value); }
        }


        public static readonly DependencyProperty FileObjectToKeyConverterProperty = DependencyProperty.Register("FileObjectToKeyConverter", typeof(IValueConverter), typeof(OpenSaveEditorControl), new PropertyMetadata(null));





        public IValueConverter ObjectConverter
        {
            get { return (IValueConverter)GetValue(ObjectConverterProperty); }
            set { SetValue(ObjectConverterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ObjectConverter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectConverterProperty =
            DependencyProperty.Register("ObjectConverter", typeof(IValueConverter), typeof(OpenSaveEditorControl), new PropertyMetadata(null));




        public ICommand PathChangeCommand
        {
            get { return (ICommand)GetValue(PathChangeCommandProperty); }
            set { SetValue(PathChangeCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathChangeCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathChangeCommandProperty =
            DependencyProperty.Register("PathChangeCommand", typeof(ICommand), typeof(OpenSaveEditorControl), new PropertyMetadata(null));


        public OpenSaveEditorControl()
        {
            this.PathChangeCommand = new PathChangeCommand(this);
        }



        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(OpenSaveEditorControl), new PropertyMetadata(null));



        public Contracts.IObjectChangeEventCommand Content
        {
            get { return (Contracts.IObjectChangeEventCommand)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(Contracts.IObjectChangeEventCommand), typeof(OpenSaveEditorControl), new PropertyMetadata(null, Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Contracts.IObjectChangeEvent objectEvent = e.NewValue as Contracts.IObjectChangeEvent;

            objectEvent.ObjectChange += (t, s) =>
                {
                    var xx = (d as OpenSaveEditorControl).ObjectConverter == null
                                 ? (s as ObjectChangeEventArgs).Object
                                 : (d as OpenSaveEditorControl).ObjectConverter.Convert((s as ObjectChangeEventArgs).Object, null, null, null);

                    (d as OpenSaveEditorControl)?.OpenSaveControl.SetFileObjectCommand.Execute(xx);
                };

        }
    }
}
