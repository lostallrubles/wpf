using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfUserControlLibrary
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
		public Ellipse sensorAggregation;
        public Ellipse sensorSerialization;
        public Ellipse sensorCrate;

        public Dummy ddd;

        private int _i = 247812943;

        public delegate void UpdateTextCallback(TextBlock tb, string message, bool isRed);


        public class Dummy : INotifyPropertyChanged
        {
            private string sens_name;

            protected void OnChange(string info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            public string AgregationSensorName
            {
                get { return sens_name; }
                set
                {
                    sens_name = value;
                    OnChange("AgregationSensorName");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }


        public void SetImage(Ellipse img, bool state, int required, int recognized, int serialized)
		{
			img.Fill = state ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.LightGray);

            Required.Text = required.ToString();
            Recognized.Text = recognized.ToString();
            Serialized.Text = serialized.ToString();

            //TextBlock tb = new TextBlock();
            //tb.Visibility = Visibility.Hidden;

		}


        private void SetMsg(TextBlock tb, string txt, bool isRed)
        {
            tb.Text = txt;
            tb.Background = isRed ? new SolidColorBrush(Colors.Red) : crateCode.Background;
            tb.Foreground = isRed ? new SolidColorBrush(Colors.Yellow) : new SolidColorBrush(Colors.Red);
        }

        private void SetMsgSafe(string txt, bool isRed)
        {
            this.Dispatcher.Invoke(new UpdateTextCallback(this.SetMsg), new object[] { AlarmMsg, txt , isRed});
        }

        public void SetAlarmMessage(string textValue, CancellationTokenSource ct, int count)
        {
            Task.Run(async ()=>{

                if (ct != null)
                {
                    while (!ct.IsCancellationRequested)
                    {
                        SetMsgSafe(textValue, true);
                        await Task.Delay(300);
                        SetMsgSafe(textValue, false);
                        await Task.Delay(300);
                    }
                }
                else
                {
                    for (int i = 1; i <= count; ++i)
                    {
                        SetMsgSafe(textValue, true);
                        await Task.Delay(300);
                        SetMsgSafe(textValue, false);
                        await Task.Delay(300);
                    }
                }

                SetMsgSafe("", false);
            });

            

            crateCode.Text = _i.ToString();
            ++_i;
        }

		public UserControl1()
        {
            InitializeComponent();

            ddd = new Dummy();
            ddd.AgregationSensorName = "Agreg Sensor State";
            this.DataContext = ddd;

            sensorAggregation = sensorA;
			sensorSerialization = sensorB;
			sensorCrate = sensorC;
		}
    }
}
