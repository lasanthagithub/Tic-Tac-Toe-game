﻿using System;
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
        // Define initial variables
        bool playerTurn = true; // If this = true, 'X''s turn else 'O''s turn
        int playCount = 0; // To determine how many turns that both players get max
        bool isWinner = false; // To determine a winner
        string winner = "";

        // Initializing the form components
        public TicTacToe()
        {
            InitializeComponent();
        }

        // 'Info' menu item 'About'
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Lasantha Rathnayake; Date: 10/20/2017");
        }

        // 'Info' menu item 'How to Play?'
        private void HowToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To play this Tic Tac Toe game, you need two to have players. " +
                "Player 1 and 2 select symbols 'X' and 'O', respectively. " +
                "You need to place three of your marks" +
                " in a horizontal, vertical or diagonal row to win the game. " +
                "The player 'X' goes first.");
        }

        // 'File' menu item 'Quit?'
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        // A common method to handle click events for buttons
        private void ButtonClick(object sender, EventArgs e)
        {
            
            if (!isWinner)
            {
                // creating a button object from the sender parameter
                Button button = (Button)sender;

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
                button.Enabled = false; // Disabling the button
                button.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    28F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                // Calling the method to determine a winner
                DetermineWinner(button);
            }

            else if (isWinner)
                MessageBox.Show("The game is over! The winner is: "+ winner + 
                    ". Please restart for a new game.");

        }


        // To determine whether there is a winner or not
        private void DetermineWinner(Button b)      
            {

                // These are the potential winning combinations
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
                    GetWinner(b.Text);
                    winner = b.Text;
                }
                       
                else if (playCount == 9 && !isWinner)
                {
                    MessageBox.Show("No winner. The game is a draw.");
                }
            }

        // Printing the winner in a message box
        private void GetWinner(string winner_)
        {
            MessageBox.Show("congratulations!!! The winner is: " + winner_);
        }

        // Resetting the game to restart a new round of the game
        private void StartNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Creating a button list to reset each button
            List<Button> buttons = new List<Button>
                    { C1R1, C1R2, C1R3, C2R1, C2R2, C2R3, C3R1, C3R2, C3R3 };
            int num = 0;

            // Resetting common variables
            isWinner = false;
            winner = "";
            playCount = 0;

            // Looping through each button and reset them
            foreach (Button btn in buttons)
            {
                string i = num.ToString();
              
                btn.Text = i;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif",
                    2F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Enabled = true;
                num++;
                
            }
        }

        
    }
}
