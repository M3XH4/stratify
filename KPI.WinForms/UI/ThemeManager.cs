using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace KPI.WinForms.UI;

public static class ThemeManager
{
    public static void ApplyFormStyle(Form form)
    {
        form.BackColor = ThemePalette.LightGray;
        form.Font = new Font("Segoe UI", 10F);

        var elipse = new Guna2Elipse
        {
            BorderRadius = 16,
            TargetControl = form
        };

        var shadow = new Guna2ShadowForm
        {
            ShadowColor = Color.Black
        };
        shadow.SetShadowForm(form);
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = ThemePalette.White;
        grid.BorderStyle = BorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = ThemePalette.DarkBlue;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = ThemePalette.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        grid.DefaultCellStyle.SelectionForeColor = Color.Black;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
    }
}
