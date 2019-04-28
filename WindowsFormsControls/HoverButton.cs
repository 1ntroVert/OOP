using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    class HoverButton : Button
    {
        private Color color = Color.Teal;
        private Color defaultColor = Color.Teal;
        private Color hoverColor = Color.FromArgb(0, 0, 140);
        private Color clickColor = Color.FromArgb(160, 180, 200);

        public Color Color
        {
            get { return color; }
            set { color = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; Invalidate(); }
        }

        public Color ClickColor
        {
            get { return clickColor; }
            set { clickColor = value; Invalidate(); }
        }

        public HoverButton() : base()
        {
            Size = new Size(31, 24);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Microsoft YaHei UI",
                20.25F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                0);
            Text = "dcdscdscds";
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            color = hoverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            color = defaultColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            color = clickColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            color = defaultColor;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
            Bitmap bitmap = new Bitmap("texture.jpg");
            pe.Graphics.DrawImage(bitmap, 0, 0);
            //pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
        }
    }
}