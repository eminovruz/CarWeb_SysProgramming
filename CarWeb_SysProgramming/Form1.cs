using CarWeb_SysProgramming.Models;
using CarWeb_SysProgramming.User_Controls;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System.Text.Json;

namespace CarWeb_SysProgramming
{
    public partial class Form1 : Form
    {
        List<Car>? cars = null;
        object sync = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cars = new();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                for (int i = 1; i < 6; i++)
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        var c = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText($"Cars/cars" + i.ToString() + ".json"));

                        foreach (var item in c)
                        {
                            cars.Add(item);
                        }
                    });
                    await Task.Delay(1000);

                    foreach (var item in cars)
                    {
                        CarUC? c = new(item);
                        flowLayoutPanel1.Controls.Add(c);
                    }
                }
                MessageBox.Show(flowLayoutPanel1.Controls.Count.ToString());
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
            {
                for (int i = 1; i < 6; i++)
                {
                    var c = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText($"Cars/cars" + i.ToString() + ".json"));

                    foreach (var item in c)
                    {
                        cars.Add(item);
                    }
                }
            });

            await Task.Delay(1000);

            foreach (var item in cars)
            {
                CarUC? c = new(item);
                flowLayoutPanel1.Controls.Add(c);
            }

            MessageBox.Show(flowLayoutPanel1.Controls.Count.ToString());
        }
    }
}