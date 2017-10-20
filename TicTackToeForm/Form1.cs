using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTackToeForm
{
    public partial class TicTacToe : Form
    {
        // Deside the player
        bool playerTurn = true; // If this = true, 'X''s turn else 'O''s turn
        int playCount = 0; // To determine how many turns that both palyers get max

        public TicTacToe()
        {
            InitializeComponent();
        }

        // 'Info' menu item 'About'
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Lasantha Rathnayake");
        }

        // 'Info' menu item 'How to Play?'
        private void HowToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To play this game you need two players. " +
                "Player 1 and 2 slect simbols 'X' and 'O', respectively. "+
                "You need to place three of your marks" +
                " in a horizontal, vertical or diagonal row to win the game");
        }

        // 'File' menu item 'Quit?'
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // A common method to handle click events for buttons
        private void ButtonClick(object sender, EventArgs e)
        {
            // create a button object from the sender parameter
            Button button = (Button)sender;

            // Assign a value for the button text
            button.Text = "*";
            if (playerTurn)
            {
                button.Text = "X";
                playerTurn = false;
            }

            else
            {
                button.Text = "O";
                playerTurn = true;
            }

            playCount++;
            button.Enabled = false;

            // Calling method to determine a winner
            if (DetermineWinner(button.Text))
                button.Enabled = true;
        }


        // To determine whether their is a winner or not
        private bool DetermineWinner(string bText)      
            {

                bool isWinner = false;

                if ((C1R1.Text == C2R1.Text && C2R1.Text == C3R1.Text) ||
                    (C1R2.Text == C2R2.Text && C2R2.Text == C3R2.Text) ||
                    (C1R3.Text == C2R3.Text && C2R3.Text == C3R3.Text) ||
                    (C1R1.Text == C1R2.Text && C1R2.Text == C1R3.Text) ||
                    (C2R1.Text == C2R2.Text && C2R2.Text == C2R3.Text) ||
                    (C3R1.Text == C3R2.Text && C3R2.Text == C3R3.Text) ||
                    (C1R1.Text == C2R2.Text && C2R2.Text == C3R3.Text) ||
                    (C3R1.Text == C2R2.Text && C2R2.Text == C1R3.Text))
                {
                    isWinner = true;
                }
                    

            if (isWinner)
                {           

                    MessageBox.Show("Congradualations!!! The winnwe is: "+ bText);
                }
                       
            else if (playCount == 9 && !isWinner)
                {
                    MessageBox.Show("No winner. The game is draw.");
                }
            return isWinner;
        }

        
    }
}
