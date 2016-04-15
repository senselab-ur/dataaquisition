using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


// version 0.1 
// 4/14/2016
// error on interfacing with Ports API.

namespace bluetest
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            
               
            InitializeComponent();
            //sport = new System.IO.Ports.SerialPort;
            //SerialPort portConnect = new SerialPort();
            string senselabdir = "D:\\senselab\\";
            Directory.CreateDirectory(senselabdir);
            
           
        }   

        

        private void button1_Click_1(object sender, EventArgs e)
        {

            
            try
            {
                serialPort1.BaudRate = 9600;
                serialPort1.PortName = portnameTb.Text;
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
                serialPort1.Open();
                //btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;
                //serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    lblConnected.Text = "Connected";
                }
                btnFetch.Enabled = true;
                btnSave.Enabled = true;
                button1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("unable to connect, does the portname really exists?");
                btnConnect.Enabled = true;
            }
            

        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string hour = DateTime.Now.ToString("HH-mm-ss");

            try
            {
                SerialPort sp1 = (SerialPort)sender;
                serialDatatb.AppendText(sp1.ReadLine() + hour + "\n");


            }
            catch (Exception error){
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            btnFetch.Enabled = false;
            btnSave.Enabled = false;
            button1.Enabled = false;
        }

       /* private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            
            {

                serialPort1.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        } 
        */

        private void exitBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
           /* try
            {

                string ReceivedData = serialPort1.ReadExisting();
                if (!(ReceivedData == ""))
                {
                    serialDatatb.AppendText(ReceivedData);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            * */

            //string received = portConnect.ReadLine();
            //serialDatatb.AppendText(received);
            //DataReceived();
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string hour = DateTime.Now.ToString("HH-mm-ss");
           //ystem.DateTime Now  = new System.DateTime.Now;

            string filename = "D:\\senselab\\"+date+hour+"-"+txtFilePath.Text;

            if(!File.Exists(filename))
            {

                File.Create(filename).Dispose();
                using(TextWriter tw = new StreamWriter (filename))
                {
                    tw.WriteLine(serialDatatb.Text);
                    tw.Close();
                    MessageBox.Show("file saved! " + filename, "info");
                }
            }
             
            else if(File.Exists(filename)){

                using (TextWriter tw = new StreamWriter(filename))
                {
                    tw.WriteLine(serialDatatb.Text);
                    tw.Close();
                    MessageBox.Show("file saved! " + filename, "info");
                }
        }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            lblConnected.Text = "Disconnected";
            btnConnect.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //private void displayText(object sender, EventArgs e) 
        //{
          //  serialDatatb.AppendText(RxString);
        //}
        
       // private void DataHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
       // {
         //   var serialport = (serialPort1)sender;
           // var data 
        //}


    }
}
