using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var buttonZ = new HoverButton();
            buttonZ.Size = new Size(130, 70);

            var roundedButtonZ = new RoundedHoverButton();
            roundedButtonZ.Size = new Size(130, 130);
            roundedButtonZ.Location = new Point(200, 200);

            Controls.Add(buttonZ);
            Controls.Add(roundedButtonZ);
        }
    }
}
