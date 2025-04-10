using System;
using System.Windows.Forms;

public class InputDialog : Form
{
    private TextBox inputTextBox;
    private Button okButton;
    private Button cancelButton;

    public string InputText { get; private set; }

    public InputDialog(string title, string prompt)
    {
        this.Text = title;
        this.Width = 300;
        this.Height = 150;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        Label promptLabel = new Label() { Left = 10, Top = 10, Width = 260, Text = prompt };
        inputTextBox = new TextBox() { Left = 10, Top = 40, Width = 260 };

        okButton = new Button() { Text = "Aceptar", Left = 100, Width = 80, Top = 70 };
        okButton.Click += (sender, e) => { InputText = inputTextBox.Text; this.DialogResult = DialogResult.OK; this.Close(); };

        cancelButton = new Button() { Text = "Cancelar", Left = 190, Width = 80, Top = 70 };
        cancelButton.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

        this.Controls.Add(promptLabel);
        this.Controls.Add(inputTextBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);
    }

    public static string ShowDialog(string title, string prompt)
    {
        using (InputDialog dialog = new InputDialog(title, prompt))
        {
            return dialog.ShowDialog() == DialogResult.OK ? dialog.InputText : null;
        }
    }
}
