using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixMultipliyer_2
{
    public partial class Form1 : Form
    {

        int count = 0;
        const int SIZE = 3;
        int[,,] Matrix = new int[100, SIZE, SIZE];
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_plus(object sender, EventArgs e)
        {
            int n = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    string val = (tbl_2.Controls[n] as TextBox).Text;
                    int.TryParse(val,out Matrix[count,i,j]);
                    (tbl_2.Controls[n++] as TextBox).Clear();
                }
            }
            count++;
            textBox1.Focus();
        }

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            if(count!=0)
            {
                btn_plus(null, null);
                int[,] temp = new int[SIZE, SIZE];
                for (int i = 0; i < count; i++)
                {
                    temp = Multipliyer(0, i);
                }
                int n = 0;
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        (tbl_2.Controls[n++] as TextBox).Text = temp[i, j].ToString();
                    }
                }
            }
            else
            {
                if(MessageBox.Show("Plese Enter Matrix ..", "Error", MessageBoxButtons.OK)==DialogResult.OK)
                {
                    textBox1.Focus();
                }
            }

           
        }

        private int[,] Multipliyer(int a,int b)
        {
            int[,] tempmatrix = new int[SIZE, SIZE]; //create tempary matrix 
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    for (int n = 0; n < SIZE; n++)
                    {
                        tempmatrix[i, j] += Matrix[a, i, n] * Matrix[b, n, j];
                    }
                }
            }
            return tempmatrix;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            count = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                (tbl_2.Controls[n++] as TextBox).Clear();
            }
            textBox1.Focus();
        }
    }
}
