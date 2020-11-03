using System;
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
        public static void AppendText(this RichTextBox box, object any, Color color, bool addNewLine = false) => AppendText(box, any.ToString(), color, addNewLine);
    }
}
