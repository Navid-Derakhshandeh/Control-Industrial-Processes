//Navid-Derakhshandeh
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace Control_Industrial_Processes
{
    public partial class Temp : Form
    {
        ModbusClient modbusClient;
        
        public Temp()
        {
            InitializeComponent();
            //ModbusClient modbusclient = new ModbusClient("COM3");
            //modbusClient.Connect();
            //modbusClient.WriteSingleCoil(6, true);
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            DateTime DT = DateTime.Now;
            txtDT.Text = (DT.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        private void aGauge1_ValueInRangeChanged(object sender, AGaugeApp.AGauge.ValueInRangeChangedEventArgs e)
        {
            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            modbusClient.Disconnect();
            LbO.Text = "Offline";
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            modbusClient.WriteMultipleCoils(4, new bool[] { true, true, true, true, true, true, true, true, true, true });
            bool[] readCoils = modbusClient.ReadCoils(9, 10);
            int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);
            

            aGauge1.Value = readHoldingRegisters[0];

            int a = readHoldingRegisters[3];

            txtTemp.Text = a.ToString();

            int b = readHoldingRegisters[2];
            LbVoltage.Text = b.ToString();

            cbPower.Checked = readCoils[0];
            cbGas.Checked = readCoils[1];
            cbWater.Checked = readCoils[4];

            string m = "High";
            string m1 = "Low";
            if(a >= 30)
            {
                Lb10.Text = m.ToString();
                //modbusClient.WriteSingleCoil(6, true);
            }
            else
            {
                Lb10.Text = m1.ToString();
            }

            string p = "On";
            string p1 = "Off";
            if(cbPower.Checked == readCoils[0])
            {
                Lb5.Text = p.ToString();
            }
            else
            {
                Lb5.Text = p1.ToString();
            }
            string g = "In Flow";
            string g1 = "";
            if(cbGas.Checked == readCoils[1])
            {
                Lb6.Text = g.ToString();
            }
            else
            {
                Lb6.Text = g1.ToString();
            }
            string w = "In Flow";
            string w1 = "";
            if(cbWater.Checked == readCoils[4])
            {
                Lb7.Text = w.ToString();
            }
            else
            {
                Lb7.Text = w1.ToString();
            }
            timer1.Enabled = true;
            string er = "Your Temperature is Very High Please Control Process";
            string N = "No Error Found";
            if (aGauge1.Value >= 400)
            {

                LbError.Text = er;
            }
            else
            {
                LbError.Text = N;
            }
            /*if(aGauge1.Value == 420)
            {
                MessageBox.Show("Everything Gonna be change");
            }*/
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                modbusClient = new ModbusClient(ServerIp.Text, 502);
                modbusClient.Connect();
                LbO.Text = "Connected";
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                LbO.Text = ex.ToString();
                throw;
            }
        }
    }
}
