using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dogRace
{
    public class Guy
    {
        public string Name { get; set;} // the guys name
        public Bet MyBet = new Bet();// an instance of Bet() that has his bet
        public int Cash { get; set; } // how much cash he has

        // the last two fields are the guys GUI controls on the form
        
        public RadioButton MyRadioButton { get; set; } // My RadioButton

        public Label MyLabel { get; set; } // My Label
        
        public void UpdateLabels()
        {
            // set my label to my bets description, and the label on my
            MyBet.Betton = this;
            MyLabel.Text = MyBet.GetDescription();
            // radio button to show my cash (" joe has 43 bucks")
            MyRadioButton.Text = Name + " has €" + Cash;
        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            // place a new bet and store it in my bet field
            // return ture if the guy had enough money to bet
            if (Cash >= Amount)
            {
                MyBet.Amount += Amount;
                Cash -= Amount;
                MyBet.Dog = Dog;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(int Winner)
        {
            MyBet.PayOut(Winner);
        }

    }
}
