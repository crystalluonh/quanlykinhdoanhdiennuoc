using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundButton : Button
{
    public int BorderRadius { get; set; } = 30;
    public int BorderThickness { get; set; } = 2;
    public Color BorderColor { get; set; } = Color.White;

    private Color _defaultBackColor;
    private Color _hoverBackColor = Color.DodgerBlue;

    public Color HoverBackColor
    {
        get => _hoverBackColor;
        set => _hoverBackColor = value;
    }

    public RoundButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.DeepSkyBlue;
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _defaultBackColor = this.BackColor;

        this.MouseEnter += RoundButton_MouseEnter;
        this.MouseLeave += RoundButton_MouseLeave;
        this.Resize += (s, e) => this.Invalidate();
    }

    private void RoundButton_MouseEnter(object sender, EventArgs e)
    {
        if (this.Enabled)
        {
            _defaultBackColor = this.BackColor;
            this.BackColor = _hoverBackColor;
        }
    }

    private void RoundButton_MouseLeave(object sender, EventArgs e)
    {
        if (this.Enabled)
        {
            this.BackColor = _defaultBackColor;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Graphics graphics = pevent.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

        int radius = BorderRadius;

        Color fillColor = this.Enabled ? this.BackColor : Color.LightGray;
        Color textColor = this.Enabled ? this.ForeColor : Color.DarkGray;
        Color borderColor = this.Enabled ? BorderColor : Color.Gray;

        using (GraphicsPath path = GetRoundPath(rectSurface, radius))
        using (SolidBrush brush = new SolidBrush(fillColor))
        using (Pen borderPen = new Pen(borderColor, BorderThickness))
        {
            this.Region = new Region(path);
            graphics.FillPath(brush, path);
            graphics.DrawPath(borderPen, path);
        }

        TextRenderer.DrawText(graphics, this.Text, this.Font, rectSurface, textColor,
                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private GraphicsPath GetRoundPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        float r = radius;

        path.StartFigure();
        path.AddArc(rect.Left, rect.Top, r, r, 180, 90);
        path.AddArc(rect.Right - r, rect.Top, r, r, 270, 90);
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
        path.AddArc(rect.Left, rect.Bottom - r, r, r, 90, 90);
        path.CloseFigure();

        return path;
    }
}
