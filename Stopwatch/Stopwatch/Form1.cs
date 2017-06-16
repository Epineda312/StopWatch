using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        int timeCs, timeSec, timeMin;
        bool isActive;

        public Form1()
        {
            InitializeComponent();
        }
        private void lblSec_Click(object sender, EventArgs e)
        {

        }
        private void lblMilSec_Click(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            isActive = true;
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            isActive = false;

            ResetTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                timeCs++;

                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 0;

                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }
            DrawTime();
        }

        private void DrawTime()
        {
            lblMilSec.Text = String.Format("{0:00}", timeCs);
            lblSec.Text = String.Format("{0:00}", timeSec);
            lblMin.Text = String.Format("{0:00}", timeMin);
        }

        

        private void ResetTime()
        {
            timeCs = 0;
            timeSec = 0;
            timeMin = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTime();

            isActive = false;
        }
    }
}
