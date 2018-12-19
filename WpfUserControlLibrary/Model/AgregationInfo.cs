using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfUserControlLibrary.Model
{
    public class AgregationInfo : INotifyPropertyChanged
    {
        private int _totalCrates;
        private int _required;
        private int _recognized;
        private int _serialized;
        private string _lastCrateCode;
        private string _alarmMessage;
        private SolidColorBrush _sensorAgrColor;
        private SolidColorBrush _sensorCrateColor;
        private SolidColorBrush _sensorCrateCodeColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TotalCrates
        {
            get => _totalCrates;
            set
            {
                _totalCrates = value;
                OnChange(nameof(TotalCrates));
            }
        }

        public int Required
        {
            get => _required;

            set
            {
                _required = value;
                OnChange(nameof(Required));
            }
        }

        public int Recognized
        {
            get => _recognized;
            set
            {
                _recognized = value;
                OnChange(nameof(Recognized));
            }
        }

        public int Serialized
        {
            get => _serialized;
            set
            {
                _serialized = value;
                OnChange(nameof(Serialized));
            }
        }

        public string LastCrateCode
        {
            get => _lastCrateCode;
            set
            {
                _lastCrateCode = value;
                OnChange(nameof(LastCrateCode));
            }
        }

        public string AlarmMessage
        {
            get => _alarmMessage;
            set
            {
                _alarmMessage = value;
                OnChange(nameof(AlarmMessage));
            }
        }

        public SolidColorBrush SensorAgrColor
        {
            get => _sensorAgrColor;
            set
            {
                _sensorAgrColor = value;
                OnChange(nameof(SensorAgrColor));
            }
        }

        public SolidColorBrush SensorCrateColor
        {
            get => _sensorCrateColor;
            set
            {
                _sensorCrateColor = value;
                OnChange(nameof(SensorCrateColor));
            }
        }

        public SolidColorBrush SensorCrateCodeColor
        {
            get => _sensorCrateCodeColor;
            set
            {
                _sensorCrateCodeColor = value;
                OnChange(nameof(SensorCrateCodeColor));
            }
        }

        protected void OnChange(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
