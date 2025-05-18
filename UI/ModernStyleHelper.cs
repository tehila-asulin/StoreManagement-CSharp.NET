using System.Drawing;
using System.Windows.Forms;

public static class ModernStyleHelper
{
    private static readonly Color BackgroundColor = Color.FromArgb(255, 255, 220, 220);

    private static readonly Color ButtonColor = Color.FromArgb(255, 220, 220, 220);

    private static readonly Color TextColor = Color.FromArgb(50, 50, 50);

    public static void ApplyModernStyle(Form form)
    {
        form.BackColor = BackgroundColor;
        foreach (Control control in form.Controls)
        {
            if (control is Button button)
            {
                StyleButton(button);
            }
            else if (control is Label label)
            {
                StyleLabel(label);
            }
            else if (control is TextBox textBox)
            {
                StyleTextBox(textBox);
            }
         
        }
    }

    private static void StyleButton(Button button)
    {
        button.BackColor = ButtonColor;
        button.ForeColor = TextColor;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
    }

    private static void StyleLabel(Label label)
    {
        label.ForeColor = TextColor;
        label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
    }

    private static void StyleTextBox(TextBox textBox)
    {
        textBox.BackColor = Color.White;
        textBox.ForeColor = TextColor;
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
    }
}
