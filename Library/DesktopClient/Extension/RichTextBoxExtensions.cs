namespace DesktopClient.Extension
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            box.SuspendLayout();
            box.SelectionColor = color;
            box.AppendText(addNewLine
                ? $"{text}{Environment.NewLine}"
                : text);
            box.ScrollToCaret();
            box.ResumeLayout();
        }
        public static void AppendTextThreadSafe(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            if (box.InvokeRequired)
            {
                box.Invoke((MethodInvoker)delegate ()
                {
                    box.AppendText(text, color, addNewLine);
                });
            }
            else
            {
                box.AppendText(text, color, addNewLine);
            }
        }
        public static void ColorLine(this RichTextBox box, int lineNumber, int lineLength, Color color)
        {
            box.Select(box.GetFirstCharIndexFromLine(lineNumber), lineLength);
            box.SelectionColor = color;
        }
        public static void ColorLineThreadSafe(this RichTextBox box, int lineNumber, int lineLength, Color color)
        {
            if (box.InvokeRequired)
            {
                box.Invoke((MethodInvoker)delegate ()
                {
                    box.ColorLine(lineNumber, lineLength, color);
                });
            }
            else
            {
                box.ColorLine(lineNumber, lineLength, color);
            }
        }
    }
}
