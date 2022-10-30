using System.ComponentModel;

namespace App.Extension
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
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                box.Invoke((MethodInvoker)delegate ()
                {
                    box.AppendText(text, color, addNewLine);
                });
            };
            worker.RunWorkerAsync();
        }
        public static void ColorLine(this RichTextBox box, int lineNumber, int lineLength, Color color)
        {
            box.Select(box.GetFirstCharIndexFromLine(lineNumber), lineLength);
            box.SelectionColor = color;
        }
        public static void ColorLineThreadSafe(this RichTextBox box, int lineNumber, int lineLength, Color color)
        {
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                box.Invoke((MethodInvoker)delegate ()
                {
                    box.ColorLine(lineNumber, lineLength, color);
                });
            };
            worker.RunWorkerAsync();
        }
    }
}
