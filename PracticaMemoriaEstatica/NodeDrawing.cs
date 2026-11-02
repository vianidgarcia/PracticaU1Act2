using System.Drawing.Drawing2D;

namespace PracticaU1Act2;

public static class NodeDrawing
{
    private const int Margin = 16;
    private const int BoxWidth = 92;
    private const int BoxHeight = 42;
    private const int PointerWidth = 30;
    private const int Gap = 34;
    private const int RowHeight = 90;
    private const int HeaderHeight = 34;
    private const int GhostZoneHeight = 78;

    private static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);
    private static readonly Color HeadColor = Color.FromArgb(129, 199, 132);
    private static readonly Color NodeColor = Color.FromArgb(144, 202, 249);
    private static readonly Color GhostColor = Color.FromArgb(224, 224, 224);

    // Draws the chain of nodes (as many as fit), the "+k" box for the rest and, if there is one, the node removed last.
    public static void Draw(Graphics g, Rectangle area, IReadOnlyList<NodeInfo> nodes, int total, NodeInfo? detached)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackgroundColor);

        using var textFont = new Font("Segoe UI", 9F);
        using var boldFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        using var valueFont = new Font("Consolas", 10F, FontStyle.Bold);
        using var idFont = new Font("Segoe UI", 7.5F);
        using var centered = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        using var solidPen = new Pen(Color.FromArgb(70, 80, 95), 1.5F);
        using var dashedPen = new Pen(Color.Gray, 1.5F) { DashStyle = DashStyle.Dash };
        using var arrowPen = new Pen(Color.FromArgb(90, 100, 115), 1.5F);
        using var cap = new AdjustableArrowCap(3, 4);
        arrowPen.CustomEndCap = cap;

        if (total == 0 && detached is null)
        {
            g.DrawString("Crea nodos para ver cómo se enlazan en el Heap.", textFont, Brushes.Gray, area, centered);
            return;
        }

        g.DrawString("Cada caja es un nodo creado con new en el Heap. El punto es la referencia al siguiente; la diagonal indica null (no hay siguiente).",
            textFont, Brushes.DimGray, new RectangleF(Margin, 8, area.Width - 2 * Margin, 30));

        if (total == 0)
        {
            g.DrawString("La lista está vacía: la cabeza es null y no hay nodos enlazados.", boldFont, Brushes.Black, Margin, HeaderHeight + 12);
        }
        else
        {
            int ghostZone = detached.HasValue ? GhostZoneHeight : 0;
            int rows = Math.Max(1, (area.Height - ghostZone - (HeaderHeight + 16) - BoxHeight) / RowHeight + 1);
            int perRow = Math.Max(1, (area.Width - 2 * Margin + Gap) / (BoxWidth + Gap));
            int capacity = perRow * rows;

            int visibleNodes = Math.Min(nodes.Count, capacity);
            if (total > visibleNodes && visibleNodes == capacity)
            {
                visibleNodes = Math.Max(0, capacity - 1);
            }

            bool hasMore = total > visibleNodes;

            Point Origin(int slot) => new(
                Margin + (slot % perRow) * (BoxWidth + Gap),
                HeaderHeight + 16 + (slot / perRow) * RowHeight);

            void Arrow(int fromSlot)
            {
                Point from = Origin(fromSlot);
                Point to = Origin(fromSlot + 1);
                int startX = from.X + BoxWidth - PointerWidth / 2;
                int centerY = from.Y + BoxHeight / 2;
                if (to.Y == from.Y)
                {
                    g.DrawLine(arrowPen, startX, centerY, to.X - 2, centerY);
                }
                else
                {
                    int bendY = from.Y + BoxHeight + 14;
                    int targetX = to.X + BoxWidth / 2;
                    g.DrawLines(arrowPen, new[]
                    {
                        new Point(startX, centerY),
                        new Point(startX, bendY),
                        new Point(targetX, bendY),
                        new Point(targetX, to.Y - 2)
                    });
                }
            }

            for (int slot = 0; slot < visibleNodes; slot++)
            {
                DrawNode(g, Origin(slot), nodes[slot], slot == 0 ? HeadColor : NodeColor, solidPen, valueFont, idFont, centered);
                if (slot < visibleNodes - 1 || hasMore)
                {
                    Arrow(slot);
                }
            }

            if (visibleNodes > 0)
            {
                Point head = Origin(0);
                g.DrawString("cabeza", idFont, Brushes.DarkGreen, head.X, head.Y - 14);
            }

            if (hasMore)
            {
                Point origin = Origin(visibleNodes);
                var more = new Rectangle(origin.X, origin.Y, BoxWidth, BoxHeight);
                g.DrawRectangle(dashedPen, more);
                g.DrawString($"+{total - visibleNodes} nodos", boldFont, Brushes.DimGray, more, centered);
            }
        }

        if (detached is { } ghost)
        {
            int y = area.Height - GhostZoneHeight + 14;
            DrawNode(g, new Point(Margin, y), ghost, GhostColor, dashedPen, valueFont, idFont, centered);

            string next = ghost.NextId is int nextId
                ? $" Su campo siguiente aún apunta al nodo #{nextId}, pero eso no lo mantiene vivo."
                : " No tenía siguiente.";
            int textX = Margin + BoxWidth + 16;
            g.DrawString($"Nodo eliminado: nada lo referencia, así que el GC puede liberarlo.{next}",
                textFont, Brushes.Black, new RectangleF(textX, y - 2, Math.Max(100, area.Width - textX - Margin), 60));
        }
    }

    private static void DrawNode(Graphics g, Point origin, NodeInfo info, Color color, Pen pen,
        Font valueFont, Font idFont, StringFormat centered)
    {
        var box = new Rectangle(origin.X, origin.Y, BoxWidth, BoxHeight);
        var data = new Rectangle(origin.X, origin.Y, BoxWidth - PointerWidth, BoxHeight);
        var pointer = new Rectangle(origin.X + BoxWidth - PointerWidth, origin.Y, PointerWidth, BoxHeight);

        using var fill = new SolidBrush(color);
        g.FillRectangle(fill, data);
        g.FillRectangle(Brushes.White, pointer);
        g.DrawRectangle(pen, box);
        g.DrawLine(pen, pointer.X, pointer.Y, pointer.X, pointer.Bottom);

        g.DrawString(info.Value.ToString(), valueFont, Brushes.Black, new Rectangle(data.X, data.Y + 2, data.Width, 22), centered);
        g.DrawString($"#{info.Id}", idFont, Brushes.DimGray, new Rectangle(data.X, data.Y + 24, data.Width, 16), centered);

        if (info.NextId is null)
        {
            g.DrawLine(pen, pointer.X + 5, pointer.Bottom - 5, pointer.Right - 5, pointer.Y + 5);
        }
        else
        {
            g.FillEllipse(Brushes.Black, pointer.X + PointerWidth / 2 - 4, origin.Y + BoxHeight / 2 - 4, 8, 8);
        }
    }
}
