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
        //Instantiate Variables
        int timeCs, timeSec, timeMin;
        bool isActive;

        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
        //On Click the Start Button Initiates the Timer
            isActive = true;
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
        //On Click the Stop Button Brings the Timer to a Halt
            isActive = false;
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
        //On click Of the Restart Button the Timer is Stopped and Numbers in Each Place Reset to 0
        
        //Timer Stops
            isActive = false;
        //Time is reset
            ResetTime();
        }
        
         private void ResetTime()
        {
        
        //Easier to Call This Method than Reset Each Variable Manually
            timeCs = 0;
            timeSec = 0;
            timeMin = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        //If Clock is Ticking
            if (isActive)
            {
            
            //Increment CentiSeconds upon Activation
                timeCs++;
                
              //Is Centiseconds greater than 100? Increment Seconds Once, reset CentiSeconds
                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 0;
                  //Seconds greater than 60? Increment minutes once and reset Seconds.
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
            //Takes numbers in each place (min,sec,Centisec) and displays it properly formatted
            lblMilSec.Text = String.Format("{0:00}", timeCs);
            lblSec.Text = String.Format("{0:00}", timeSec);
            lblMin.Text = String.Format("{0:00}", timeMin);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Created ResetTime Method instead of reseting manually/ no duplicate code
            ResetTime();
            
            //Upon load the timer does no start automatically 
            isActive = false;
        }
    }
}
