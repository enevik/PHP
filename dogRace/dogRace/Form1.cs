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

namespace dogRace
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        Greyhound[] DogRacer = new Greyhound[4];
        Guy[] guys = new Guy[3];
        public int GuyThatBets { get; set; }
        Random random = new Random();

        public void Form1_Load(object sender, EventArgs e)
        {
            guys[0] = new Guy();
            guys[0].Name = "joe";
            guys[0].Cash = 50;
            guys[0].MyLabel = JoeBetLabel;
            guys[0].MyRadioButton = JoeRadioButton;

            guys[1] = new Guy();
            guys[1].Name = "Bob";
            guys[1].Cash = 75;
            guys[1].MyLabel = BobBetlabel;
            guys[1].MyRadioButton = BobRadioButton;

            guys[2] = new Guy();
            guys[2].Name = "Al";
            guys[2].Cash = 45;
            guys[2].MyLabel = AlBetLabel;
            guys[2].MyRadioButton = AlRadioButton;

            int Start = raceDogPIcture1.Left;
            int Racetrack = raceTrackPictureBox.Width - raceDogPIcture1.Right;
            
            DogRacer[0] = new Greyhound() { MyPictureBox = raceDogPIcture1, RacetrackLength = Racetrack, StartingPosition = Start };
            DogRacer[1] = new Greyhound() { MyPictureBox = raceDogPIcture2, RacetrackLength = Racetrack, StartingPosition = Start };
            DogRacer[2] = new Greyhound() { MyPictureBox = raceDogPIcture3, RacetrackLength = Racetrack, StartingPosition = Start };
            DogRacer[3] = new Greyhound() { MyPictureBox = raceDogPIcture4, RacetrackLength = Racetrack, StartingPosition = Start };

            amountOfBet.Minimum = 5;
            amountOfBet.Maximum = 15;

            dogNumberNumbericUpDown.Minimum = 1;
            dogNumberNumbericUpDown.Maximum = 4;
        }

        public void DeclareWinner(int Winner)
        {
            MessageBox.Show("hond " + Winner + " is de winnaar van de wedstrijd");
            for (int i = 0; i < 3; i++)
            {
                guys[i].Collect(Winner);
                guys[i].UpdateLabels();
                resetDogsPosition();
                ResetBets();
            }
        }

        public void resetDogsPosition()
        {
            for(int i = 0; i < 4; i++)
            {
                DogRacer[i].TakeStrartingPosition();
            }
        }
        
        public void ResetBets()
        {
            for (int i = 0; i < 3; i++)
            {
                JoeBetLabel.Text = "Joe heeft geen geld ingezet";
                BobBetlabel.Text = "Bob heeft geen geld ingezet";
                AlBetLabel.Text = "Al heeft geen geld ingezet";
            }
        }

        public void LetDogsRun()
        {
            while (true)
            {
                for(int i = 0; i < DogRacer.Length; i++)
                {
                    Thread.Sleep(6);
                    DogRacer[random.Next(0, 4)].Run();
                    if (DogRacer[i].Run())
                    {
                        DeclareWinner(i + 1);
                        return;
                    }
                }
                betButton.Enabled = false;
            }
        }

        private void JoeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Joe";
            GuyThatBets = 0;
        }

        private void BobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Bob";
            GuyThatBets = 1;
        }

        private void AlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Al";
            GuyThatBets = 2;
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            LetDogsRun();
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if(guys[GuyThatBets].MyBet.Amount >= 15)
            {
                MessageBox.Show("mag niet meer dan 15 euro inzetten");
            }
            else if (guys[GuyThatBets].Cash < amountOfBet.Value)
            {
                MessageBox.Show("deze persoon heeft niet genoeg geld");
            }
            else
            {
                int amount = (int)amountOfBet.Value;
                int dog = (int)dogNumberNumbericUpDown.Value;
                guys[GuyThatBets].PlaceBet(amount, dog);
                guys[GuyThatBets].UpdateLabels();
            }
        }
    }
}
