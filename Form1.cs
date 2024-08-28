using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cronometro
{
    public partial class Form1 : Form
    {
        int tempo = 0;
        int minuto = 0;
        int segundo = 0;
        private Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopWatch.Restart();
            stopWatch.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = String.Format("{0:hh\\:mm\\:ss\\:fff}", stopWatch.Elapsed);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            tempo = Convert.ToInt16(textBox1.Text);
            if (tempo >= 60)
            {
                minuto = tempo / 60;
                segundo = tempo % 60;
            }
            else
            {
                minuto = 0;
                segundo = tempo;

            }
            label3.Text = "0" + minuto + ":" + segundo;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            segundo = segundo - 1;
            if (minuto > 0)
            {
                if (segundo < 0)
                {
                    segundo = 59;
                    minuto--;
                }
            }
            label3.Text = "0" + minuto + ":" + segundo;
            if (minuto == 0 && segundo == 0)
            {
                timer2.Enabled = false;
                pictureBox1.Visible = true;
            }
        }
    }
}