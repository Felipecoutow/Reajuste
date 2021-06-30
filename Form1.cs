using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reajuste
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
               int left,
               int top,
               int right,
               int bottom,
               int width,
               int height
           );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            float Salario, Reajuste, Total;

            Salario = Convert.ToInt32(txtSalarioAtual.Text);

            Reajuste = (Salario * 15) / 100;

            Total = Reajuste + Salario;

            txtlblReajusteInicial.Text = Convert.ToString(Reajuste);
            txtSalarioReajustado.Text = Convert.ToString(Total);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioAtual.Clear();
            txtlblReajusteInicial.Clear();
            txtSalarioReajustado.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
