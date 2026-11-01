using System.Drawing.Drawing2D;

namespace PracticaU1Act2;

public static class ArrayDrawing
{
    private const int Margin = 16;
    private const int CellHeight = 42;
    private const int MinCellWidth = 44;
    private const int MaxCellWidth = 80;
    private const int ArrowZone = 38;

    private static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);
    private static readonly Color CopiedColor = Color.FromArgb(144, 202, 249);
    private static readonly Color NewColor = Color.FromArgb(255, 241, 118);
    private static readonly Color OldColor = Color.FromArgb(224, 224, 224);
    private static readonly Color LostColor = Color.FromArgb(239, 154, 154);

    // Draws the current block and, after a resize, the block it replaced with arrows for the copied cells.
    public static void Draw(Graphics g, Rectangle area, int[]? current, int currentId, int[]? previous, int previousId)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackgroundColor);

        using var titleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        using var textFont = new Font("Segoe UI", 9F);
        using var valueFont = new Font("Consolas", 9F, FontStyle.Bold);
        using var indexFont = new Font("Segoe UI", 7.5F);
        using var centered = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        if (current is null)
        {
            g.DrawString("Crea un arreglo para ver cómo se reserva su bloque en memoria.", textFont, Brushes.Gray, area, centered);
            return;
        }

        int count = Math.Max(current.Length, previous?.Length ?? 0);
        int available = area.Width - 2 * Margin;
        int slots = Math.Max(2, Math.Min(count, available / MinCellWidth));
        bool truncated = count > slots;
        int shown = truncated ? slots - 1 : count;
        int cellWidth = Math.Min(MaxCellWidth, available / slots);
        int left = area.Left + Margin;

        if (previous is null)
        {
            DrawText(g, $"Bloque en el Heap (id #{currentId}): {current.Length} elementos contiguos", titleFont, left, 6, available);
            DrawRow(g, left, 28, current, shown, cellWidth, valueFont, indexFont, centered, _ => CopiedColor);
            DrawText(g, "Cada celda muestra su valor y, debajo, su índice.", textFont, left, 28 + CellHeight + 10, available);
            return;
        }

        int oldTop = 28;
        int oldBottom = oldTop + CellHeight;
        int newTop = oldBottom + ArrowZone;
        int newBottom = newTop + CellHeight;

        DrawText(g, $"Bloque anterior (id #{previousId}): ya nadie lo referencia, el GC puede liberarlo", titleFont, left, 6, available);
        DrawRow(g, left, oldTop, previous, shown, cellWidth, valueFont, indexFont, centered,
            i => i >= current.Length ? LostColor : OldColor);

        using var arrowPen = new Pen(Color.FromArgb(90, 100, 115), 1.5F);
        using var cap = new AdjustableArrowCap(3, 4);
        arrowPen.CustomEndCap = cap;
        int copied = Math.Min(Math.Min(previous.Length, current.Length), shown);
        for (int i = 0; i < copied; i++)
        {
            int x = left + i * cellWidth + (cellWidth - 4) / 2;
            g.DrawLine(arrowPen, x, oldBottom + 2, x, newTop - 3);
        }

        DrawRow(g, left, newTop, current, shown, cellWidth, valueFont, indexFont, centered,
            i => i < previous.Length ? CopiedColor : NewColor);
        DrawText(g, $"Bloque nuevo (id #{currentId}): {current.Length} elementos", titleFont, left, newBottom + 4, available);

        int legendY = newBottom + 28;
        int legendX = DrawLegend(g, left, legendY, CopiedColor, "datos copiados", textFont);
        legendX = DrawLegend(g, legendX, legendY, NewColor, "posiciones nuevas (valor 0)", textFont);
        if (previous.Length > current.Length)
        {
            DrawLegend(g, legendX, legendY, LostColor, "elementos perdidos al reducir", textFont);
        }
    }

    private static void DrawRow(Graphics g, int left, int top, int[] values, int shown, int cellWidth,
        Font valueFont, Font indexFont, StringFormat centered, Func<int, Color> colorOf)
    {
        using var border = new Pen(Color.FromArgb(70, 80, 95), 1.5F);
        int visible = Math.Min(shown, values.Length);

        for (int i = 0; i < visible; i++)
        {
            var cell = new Rectangle(left + i * cellWidth, top, cellWidth - 4, CellHeight);
            using var fill = new SolidBrush(colorOf(i));
            g.FillRectangle(fill, cell);
            g.DrawRectangle(border, cell);
            g.DrawString(values[i].ToString(), valueFont, Brushes.Black, new Rectangle(cell.X, cell.Y + 2, cell.Width, 24), centered);
            g.DrawString($"[{i}]", indexFont, Brushes.DimGray, new Rectangle(cell.X, cell.Y + 26, cell.Width, 14), centered);
        }

        if (values.Length > visible)
        {
            var more = new Rectangle(left + visible * cellWidth, top, cellWidth - 4, CellHeight);
            using var dashed = new Pen(Color.Gray, 1.5F) { DashStyle = DashStyle.Dash };
            g.DrawRectangle(dashed, more);
            g.DrawString($"+{values.Length - visible}", valueFont, Brushes.DimGray, more, centered);
        }
    }

    private static void DrawText(Graphics g, string text, Font font, int x, int y, int width)
    {
        using var format = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
        g.DrawString(text, font, Brushes.Black, new RectangleF(x, y, width, font.Height + 2), format);
    }

    private static int DrawLegend(Graphics g, int x, int y, Color color, string text, Font font)
    {
        using var brush = new SolidBrush(color);
        g.FillRectangle(brush, x, y + 2, 14, 14);
        g.DrawRectangle(Pens.DimGray, x, y + 2, 14, 14);
        g.DrawString(text, font, Brushes.Black, x + 20, y);
        SizeF size = g.MeasureString(text, font);
        return x + 20 + (int)size.Width + 18;
    }
}
