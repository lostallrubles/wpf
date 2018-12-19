using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfUserControlLibrary.Model;
using WpfUserControlLibrary.ViewModel;

namespace with_wpf
{
	public partial class Form1 : Form
	{



        CancellationTokenSource ct;

        AgregationModel aModel;

        WpfUserControlLibrary.UserControl1 uc;
        WpfUserControlLibrary.UserControl2 uc2;

        public Form1()
		{
			InitializeComponent();

            aModel = new AgregationModel();
            //uc = elementHost1.Child as WpfUserControlLibrary.UserControl1;

            uc2 = elementHost2.Child as WpfUserControlLibrary.UserControl2;
            uc2.DataContext = aModel;

            //uc2.InitContext(aModel);
            aModel.Init();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uc.ddd.AgregationSensorName = "сенсор агрегации";

            Task.Run(async () => {

                for (int i = 1; i <= 10; ++i)
                {
                    uc.ddd.AgregationSensorName = "сенсор агрегации";
                    await Task.Delay(300);
                    
                    uc.ddd.AgregationSensorName = "агрегации сенсор";
                    await Task.Delay(300);
                }
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aModel.AI.Required += 1;
            aModel.AI.Recognized += 1;
            aModel.AI.Serialized += 1;
            aModel.AI.LastCrateCode = DateTime.Now.ToLongTimeString();

            aModel.AI.AlarmMessage = (aModel.AI.AlarmMessage == "") ? "Тревога, тревога! волк украл зайчат!!!" : "";

            aModel.AI.TotalCrates += 1;
            aModel.RotateSensor();
            aModel.AI.LastCrateCode = DateTime.Now.ToLongTimeString();

        }


        }

}
