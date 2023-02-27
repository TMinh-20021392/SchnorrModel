using System.Numerics;

namespace SchnorrModel
{
    public partial class Form1
    {
        readonly static int max = 1000;
        private static readonly Random random = new();
        private static readonly List<BigInteger> list = new();
        public Form1()
        {
            InitializeComponent();
            schnorrToolStripMenuItem.Checked = true;
            guillouQuisquaterToolStripMenuItem.Checked = false;
            okamotoToolStripMenuItem.Checked = false;
            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel1.Size = new Size(779, 360);
            panel1.Location = new Point(12, 128);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var SoBitp = 50;
                var SoBitq = 16;
                var tp = P(@"C:\Users\Tuanminh1910\source\repos\SchnorrModel\SchnorrModel\py.py {0} {1}", SoBitq.ToString(), (SoBitp - SoBitq).ToString());
                var p = tp.Item1;
                var q = tp.Item2;
                textBox1.Text = p.ToString();
                textBox2.Text = q.ToString();
                FindPrimitive(p);
                if (schnorrToolStripMenuItem.Checked)
                {
                    var alpha = list.ElementAt(random.Next(list.Count));
                    alpha = BigInteger.ModPow(alpha, (p - 1) / q, p);
                    textBox4.Text = alpha.ToString();
                    var a = BigInteger.Parse(textBox10.Text);
                    var v = BigInteger.ModPow(TryModInverse(alpha, p), a, p);
                    textBox11.Text = v.ToString();
                }
                else if (okamotoToolStripMenuItem.Checked)
                {
                    var alpha1 = list.ElementAt(random.Next(list.Count));
                    var alpha2 = list.ElementAt(random.Next(list.Count));
                    alpha1 = BigInteger.ModPow(alpha1, (p - 1) / q, p);
                    alpha2 = BigInteger.ModPow(alpha2, (p - 1) / q, p);
                    //var c = BigInteger.Log(alpha2, (double)alpha1);
                    tb1.Text = alpha1.ToString();
                    tb2.Text = alpha2.ToString();
                    var a1 = BigInteger.Parse(textBox12.Text);
                    var a2 = BigInteger.Parse(textBox13.Text);
                    var v = BigInteger.ModPow(TryModInverse(alpha1, p), a1, p) *
                        BigInteger.ModPow(TryModInverse(alpha2, p), a2, p) % p;
                    textBox14.Text = v.ToString();
                }
                else if (guillouQuisquaterToolStripMenuItem.Checked)
                {
                    var n = p * q;
                    textBox30.Text = n.ToString();
                    var u = BigInteger.Parse(textBox23.Text);
                    var b = BigInteger.Parse(textBox29.Text);
                    var v = BigInteger.ModPow(TryModInverse(u, n), b, n);
                    textBox22.Text = v.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox8_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var p = BigInteger.Parse(textBox1.Text);
                var alpha = BigInteger.Parse(textBox4.Text);
                var k = BigInteger.Parse(textBox5.Text);
                var g = BigInteger.ModPow(alpha, k, p);
                textBox8.Text = g.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox9_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var q = BigInteger.Parse(textBox2.Text);
                var k = BigInteger.Parse(textBox5.Text);
                var r = BigInteger.Parse(textBox6.Text);
                var a = BigInteger.Parse(textBox10.Text);
                var y = (k + a * r) % q;
                textBox9.Text = y.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox7_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var p = BigInteger.Parse(textBox1.Text);
                var alpha = BigInteger.Parse(textBox4.Text);
                var g = BigInteger.Parse(textBox8.Text);
                var r = BigInteger.Parse(textBox6.Text);
                var v = BigInteger.Parse(textBox11.Text);
                var y = BigInteger.Parse(textBox9.Text);
                textBox7.Text = (g == BigInteger.ModPow(alpha, y, p) * BigInteger.ModPow(v, r, p) % p).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SchnorrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schnorrToolStripMenuItem.Checked = true;
            guillouQuisquaterToolStripMenuItem.Checked = false;
            okamotoToolStripMenuItem.Checked = false;
            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel1.Size = new Size(779, 360);
            panel1.Location = new Point(12, 128);
        }
        private void OkamotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            okamotoToolStripMenuItem.Checked = true;
            schnorrToolStripMenuItem.Checked = false;
            guillouQuisquaterToolStripMenuItem.Checked = false;
            panel2.Visible = true;
            panel2.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel2.Size = new Size(779, 360);
            panel2.Location = new Point(12, 128);
        }
        private void GuillouQuisquaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            okamotoToolStripMenuItem.Checked = false;
            schnorrToolStripMenuItem.Checked = false;
            guillouQuisquaterToolStripMenuItem.Checked = true;
            panel3.Visible = true;
            panel3.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Size = new Size(779, 360);
            panel3.Location = new Point(12, 128);
        }
    }
}