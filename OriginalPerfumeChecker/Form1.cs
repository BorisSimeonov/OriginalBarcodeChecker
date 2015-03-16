using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriginalPerfumeChecker
{
    public partial class Form1 : Form
    {
        string userInput = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            userInput = tbInput.Text;
            bool check = checkInput();
            if(check)
            {
                checkOriginality();
            }
        }

        
        private bool checkInput()
        {
            if (userInput.Length < 2)
            {
                return false;
            }
            else
            {
                char ch = ' ';
                for (int cnt = 0; cnt < userInput.Length; cnt++)
                {
                    ch = userInput[cnt];
                    if (!Char.IsDigit(ch))
                    {
                        tbInput.Text = "Invalid Input.";
                        break;
                    }
                }
                return true;
            }
        }

        private void checkOriginality()
        {
            int controlNumber = (int)Char.GetNumericValue(userInput[0]);
            int evenNumbers = 0;
            int oddNumbers = 0;
            int result = 0;
            string finalConclusion = "";

            for (int cnt = 1; cnt < userInput.Length; cnt++ )
            {
                if (cnt % 2 == 0)
                {
                    oddNumbers += (int)Char.GetNumericValue(userInput[cnt]);
                }
                else
                {
                    evenNumbers += (int)Char.GetNumericValue(userInput[cnt]);
                }
            }
            evenNumbers *= 3;
            result = 10 - ((oddNumbers + evenNumbers) % 10);
            if(result == controlNumber)
            {
                finalConclusion = " Original!";
            }
            else
            {
                finalConclusion = " Fake!";
            }

            tbResult.Text = finalConclusion;
        }
    }
}
