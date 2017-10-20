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
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Lasantha Rathnayake");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To play this game you need two players. " +
                "Player 1 and 2 slect simbols 'X' and 'O', respectively. "+
                "You need to place three of your marks" +
                " in a horizontal, vertical or diagonal row to win the game");
        }
    }
}
