using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTextBox
{
    public partial class TimeTextBox : TextBox
    {
        ErrorProvider error = new ErrorProvider();


        public TimeTextBox()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Tarkistaa että syöte on validi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TimeSpan time = TimeSpan.Parse(this.Text);
                if (time.CompareTo(new TimeSpan(24, 0 ,0)) >= 0)
                {
                    e.Cancel = true;
                    error.SetError(this, "Täytyy olla pienimpi kuin 24:00:00");
                    this.BackColor = Color.Red;
                    return;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                error.SetError(this, "Väärä muoto.");
                this.BackColor = Color.Red;
            }
        }

        private void TimeTextBox_Validated(object sender, EventArgs e)
        {
            error.SetError(this, null);
            this.BackColor = Color.White;
        }
    }
}
