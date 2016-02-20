using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeApplication
{
    public partial class MainForm : Form
    {
        bool turnX;
        int drawCounter = 0;

        public MainForm()
        {
            InitializeComponent();
            disableButtons();
            lbInform.Text = "";
            MessageBox.Show("Please Choose <X> or <O> In Order To Start The Game...!", "Make Your Choice");
            btnX.Enabled = true;
            btnO.Enabled = true;
        }

        private void disableButtons()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }

        private void enableButtons()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            enableButtons();
            this.turnX = true;
            btnX.Visible = false;
            btnO.Visible = false;
            tbTurn.Text = "PLAYER <X> IS MAKING A MOVE...!";
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            enableButtons();
            this.turnX = false;
            btnO.Visible = false;
            btnX.Visible = false;
            tbTurn.Text = "PLAYER <O> IS MAKING A MOVE...!";
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turnX)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void checkForWinner()
        {
            bool isThereAWinner = false;

            if ((btnA1.Text.Equals(btnA2.Text)) && (btnA2.Text.Equals(btnA3.Text)) && (!(btnA1.Enabled)))
            {
                isThereAWinner = true;
            }
            else if ((btnB1.Text.Equals(btnB2.Text)) && (btnB2.Text.Equals(btnB3.Text)) && (!(btnB1.Enabled)))
            {
                isThereAWinner = true;
            }
            else if ((btnC1.Text.Equals(btnC2.Text)) && (btnC2.Text.Equals(btnC3.Text)) && (!(btnC1.Enabled)))
            {
                isThereAWinner = true;
            }

            if ((btnA1.Text.Equals(btnB1.Text)) && (btnB1.Text.Equals(btnC1.Text)) && (!(btnA1.Enabled)))
            {
                isThereAWinner = true;
            }
            else if ((btnA2.Text.Equals(btnB2.Text)) && (btnB2.Text.Equals(btnC2.Text)) && (!(btnA2.Enabled)))
            {
                isThereAWinner = true;
            }
            else if ((btnA3.Text.Equals(btnB3.Text)) && (btnB3.Text.Equals(btnC3.Text)) && (!(btnA3.Enabled)))
            {
                isThereAWinner = true;
            }

            if ((btnA1.Text.Equals(btnB2.Text)) && (btnB2.Text.Equals(btnC3.Text)) && (!(btnA1.Enabled)))
            {
                isThereAWinner = true;
            }
            else if ((btnA3.Text.Equals(btnB2.Text)) && (btnB2.Text.Equals(btnC1.Text)) && (!(btnA3.Enabled)))
            {
                isThereAWinner = true;
            }

            if (isThereAWinner)
            {
                lbInform.Text = "Click On The Logo To Start A New Game...!";
                tbTurn.Text = "";
                disableButtons();

                string gameWinner = "";
                if (turnX)
                {
                    gameWinner = "O";
                }
                else
                {
                    gameWinner = "X";
                }
                MessageBox.Show(gameWinner + " Wins...!", "Congratulations, You Won...!");
            }
            else
            {
                if (drawCounter == 9)
                {
                    tbTurn.Text = "";
                    MessageBox.Show("Draw...!", "No One Won...!");
                }
            }

        }

        private void button_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            if (turnX)
            {
                b.Text = "X";
                tbTurn.Text = "PLAYER <O> IS MAKING A MOVE...!";
            }
            else
            {
                b.Text = "O";
                tbTurn.Text = "PLAYER <X> IS MAKING A MOVE...!";
            }

            turnX = !turnX;
            b.Enabled = false;

            drawCounter++;

            checkForWinner();
        }

        private void startNewGame()
        {
            disableButtons();
            btnX.Enabled = true;
            btnO.Enabled = true;
            btnX.Visible = true;
            btnO.Visible = true;
            this.drawCounter = 0;
            lbInform.Text = "";
            btnA1.Text = "";
            btnA2.Text = "";
            btnA3.Text = "";
            btnB1.Text = "";
            btnB2.Text = "";
            btnB3.Text = "";
            btnC1.Text = "";
            btnC2.Text = "";
            btnC3.Text = "";
            tbTurn.Text = "";
            MessageBox.Show("Please Choose <X> or <O> In Order To Start The Game...!", "Make Your Choice");
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Valery Maznev...!", "PS Course");
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic-tac-toe (or Noughts and crosses, Xs and Os) is a game for two players, X and O, who take turns marking the spaces in a 3×3 grid. The player who succeeds in placing three respective marks in a horizontal, vertical, or diagonal row wins the game.", "How To Play The Game");
        }

    }
}
