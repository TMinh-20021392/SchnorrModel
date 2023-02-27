using System.Numerics;

namespace SchnorrModel
{
    public partial class Form1 : Form
    {
        private void TextBox17_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var p = BigInteger.Parse(textBox1.Text);
                var k1 = BigInteger.Parse(textBox15.Text);
                var k2 = BigInteger.Parse(textBox16.Text);
                var alpha1 = BigInteger.Parse(tb1.Text);
                var alpha2 = BigInteger.Parse(tb2.Text);
                var g = BigInteger.ModPow(alpha1, k1, p) * BigInteger.ModPow(alpha2, k2, p) % p;
                textBox17.Text = g.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox18_MouseClick(object sender, MouseEventArgs e)
        {
            Authenticate();
        }
        private void Authenticate()
        {
            try
            {
                var p = BigInteger.Parse(textBox1.Text);
                var q = BigInteger.Parse(textBox2.Text);
                var k1 = BigInteger.Parse(textBox15.Text);
                var k2 = BigInteger.Parse(textBox16.Text);
                var alpha1 = BigInteger.Parse(tb1.Text);
                var alpha2 = BigInteger.Parse(tb2.Text);
                var a1 = BigInteger.Parse(textBox12.Text);
                var a2 = BigInteger.Parse(textBox13.Text);
                var r = BigInteger.Parse(textBox20.Text);
                var y1 = (k1 + a1 * r) % q;
                var y2 = (k2 + a2 * r) % q;
                textBox18.Text = y1.ToString();
                textBox19.Text = y2.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox19_MouseClick(object sender, MouseEventArgs e)
        {
            Authenticate();
        }
        private void TextBox21_MouseClick(object sender, MouseEventArgs e)
        {
            var p = BigInteger.Parse(textBox1.Text);
            var alpha1 = BigInteger.Parse(tb1.Text);
            var alpha2 = BigInteger.Parse(tb2.Text);
            var y1 = BigInteger.Parse(textBox18.Text);
            var y2 = BigInteger.Parse(textBox19.Text);
            var v = BigInteger.Parse(textBox14.Text);
            var r = BigInteger.Parse(textBox20.Text);
            var g = BigInteger.Parse(textBox17.Text);
            textBox21.Text = (g == BigInteger.ModPow(alpha1, y1, p) * BigInteger.ModPow(alpha2, y2, p)
                * BigInteger.ModPow(v, r, p) % p).ToString();
        }
    }
}
