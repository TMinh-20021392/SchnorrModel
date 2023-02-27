using System.Numerics;

namespace SchnorrModel
{
    public partial class Form1
    {
        private void TextBox25_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var k = BigInteger.Parse(textBox28.Text);
                var b = BigInteger.Parse(textBox29.Text);
                var n = BigInteger.Parse(textBox30.Text);
                var g = BigInteger.ModPow(k, b, n);
                textBox25.Text = g.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox24_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var k = BigInteger.Parse(textBox28.Text);
                var u = BigInteger.Parse(textBox23.Text);
                var n = BigInteger.Parse(textBox30.Text);
                var r = BigInteger.Parse(textBox27.Text);
                var y = k * BigInteger.ModPow(u, r, n) % n;
                textBox24.Text = y.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBox26_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var b = BigInteger.Parse(textBox29.Text);
                var n = BigInteger.Parse(textBox30.Text);
                var g = BigInteger.Parse(textBox25.Text);
                var r = BigInteger.Parse(textBox27.Text);
                var v = BigInteger.Parse(textBox22.Text);
                var y = BigInteger.Parse(textBox24.Text);
                textBox26.Text = (g == BigInteger.ModPow(v, r, n) * BigInteger.ModPow(y, b, n) % n).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
