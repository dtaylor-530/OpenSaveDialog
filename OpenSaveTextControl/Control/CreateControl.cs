

namespace OpenSave.Wpf
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using Contracts;


    public class CreateControl : Control
    {
        public object CreationService
        {
            get { return (object)GetValue(CreationServiceProperty); }
            set { SetValue(CreationServiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreationService.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreationServiceProperty =
            DependencyProperty.Register("CreationService", typeof(object), typeof(CreateControl), new PropertyMetadata(null));


        public object Object
        {
            get { return (int)GetValue(ObjectProperty); }
            set { SetValue(ObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Object.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectProperty =
            DependencyProperty.Register("Object", typeof(int), typeof(CreateControl), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            (this.GetTemplateChild("button") as Button).Click += CreateControl_Click;
        }

        private void CreateControl_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.InvokeAsync(() =>
                {
                    this.Object = (this.CreationService as ICreate).Create();
                    this.RaiseCreationEvent(this.Object);
                    return this.Object;
                });
        }

        public static readonly RoutedEvent CreationEvent = EventManager.RegisterRoutedEvent("Creation", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CreateControl));

        public event RoutedEventHandler Creation
        {
            add => this.AddHandler(CreationEvent, value);
            remove => this.RemoveHandler(CreationEvent, value);
        }

        void RaiseCreationEvent(object textObject)
        {
            RoutedEventArgs newEventArgs = new CreationEventArgs(CreateControl.CreationEvent, textObject);
            this.RaiseEvent(newEventArgs);
        }


        public class CreationEventArgs : RoutedEventArgs
        {
            public object Object;


            public CreationEventArgs(RoutedEvent routedEvent, Object @object) : base(routedEvent)
            {
                this.Object = @object;
            }
        }
    }
}
