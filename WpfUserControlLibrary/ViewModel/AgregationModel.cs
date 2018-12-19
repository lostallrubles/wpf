using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfUserControlLibrary.Model;

namespace WpfUserControlLibrary.ViewModel
{
    public class AgregationModel 
    {
        private static SolidColorBrush _brGray = new SolidColorBrush(System.Windows.Media.Color.FromRgb(100, 100, 100));
        private static SolidColorBrush _brGreen = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 20));
        private static SolidColorBrush _brRed = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));


        private AgregationInfo _ai;
        private int _state = State.Idle;

        public AgregationModel()
        {
            _ai = new AgregationInfo();
        }

        public AgregationInfo AI { get => _ai; }

        public void Init()
        {
            this.AI.Required = 14;
        }

        public void RotateSensor()
        {
            var state = Interlocked.CompareExchange(ref _state, State.Working, State.Idle);
            if (state != State.Idle) return;

            Task.Run(async () =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    AI.SensorAgrColor = _brGray;
                    AI.SensorCrateColor = _brGray;
                    AI.SensorCrateCodeColor = _brGray;
                    await Task.Delay(200);

                    AI.SensorAgrColor = _brGreen;
                    await Task.Delay(200);

                    AI.SensorAgrColor = _brRed;
                    AI.SensorCrateColor = _brGreen;
                    AI.SensorCrateCodeColor = _brRed;
                    await Task.Delay(200);
                }
                state = Interlocked.CompareExchange(ref _state, State.Idle, State.Working);
            });
        }



    }

    static class State
    {
        public const int Idle = 0;
        public const int Working = 1;
    }

}
