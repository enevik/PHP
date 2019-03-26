using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dogRace
{
    public class Bet
    {
        public int Amount { get; set; } // the amount of cash that was bet
        public int Dog { get; set; } // the number of the dog the bet is on
        public Guy Betton { get; set; } // The guy who placed the bet

        public string GetDescription()
        {
            // return a string that says who placed the bet, how much cash was bet, and whish dog he bet on("joe bets 8 on dog #4"). 
            //if the amount is zero, no bet was placed (" joe hasn't placed a bet").
            if (Amount == 0)
            {
                return Betton.Name + "Er is geen bet geplaats op de hond.";
            }
            else
            {
                return Betton.Name + " heeft €" + Amount + " geplaatst op " + Dog;
            }

        }

        public int PayOut(int Winner)
        {
          // the parameter is the winner of the race. If the dog won, return the amount bet. otherwise, return the negative of the amount bet.
            if(Dog == Winner)
            {
                int amount = Amount;
                MessageBox.Show(Betton.Name + " heeft gewonnen");
                Clearbet();
                return Betton.Cash += amount * 2;
            }
            else
            {
                Clearbet();
                return 0;
            }
        }

        public void Clearbet()
        {
            Amount = 0;
        }
    }
}
