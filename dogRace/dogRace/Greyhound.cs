using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dogRace
{
    public class Greyhound
    {
        public int StartingPosition { get; set; } // Where my pictuebox starts
        public int RacetrackLength { get; set; } // how long the racetrack is

        public PictureBox MyPictureBox = null; // my PictureBox object

        public int Location = 0; // my location on the racetrack
        public Random Randomizer = new Random(); // an instance of random

        public bool Run() 
        {
            // move forward either 1, 2, 3 or 4 spaces at random
            int distance = Randomizer.Next(1, 4);

            // update the postion of my PictureBox on the form
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
            DateTime then = DateTime.Now;
            // return true if i won the race
            do
            {
                Application.DoEvents();
            } while (then.AddSeconds(0.040) > DateTime.Now);
            if (p.X >= RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStrartingPosition()
        {
            // reset my location to the start line
            MyPictureBox.Left = StartingPosition;
        }
    }
}
