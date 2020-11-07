using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonScripts.Extension
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
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                box.Invoke((MethodInvoker)delegate () {
                    AppendText(box, text, color, addNewLine);
                });
            };
            worker.RunWorkerAsync();
        }

        public static void AppendText(this RichTextBox box, object any, Color color, bool addNewLine = false) => AppendText(box, any.ToString(), color, addNewLine);

        public static void AppendTextThreadSafe(this RichTextBox box, object any, Color color, bool addNewLine = false) => AppendTextThreadSafe(box, any.ToString(), color, addNewLine);
    }
}
