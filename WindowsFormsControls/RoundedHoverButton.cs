using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    class RoundedHoverButton : HoverButton
    {
        private Color color = Color.Teal;

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            //pe.Graphics.FillEllipse(new SolidBrush(color), ClientRectangle);
            //pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);

            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(grPath);
            base.OnPaint(pe);
        }
    }
}
