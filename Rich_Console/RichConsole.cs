using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace Rich_Console
{
    /// <summary>
    /// Use to output Console to RichTextBox
    /// </summary>
    public class RichConsole : TextWriter
    {
        RichTextBox Output = null;

        private delegate void RichTextBoxUpdateEventHandler(char value);


        /// <summary>
        /// Set the RichTextBox for output.
        /// </summary>
        /// <param name="richTextBox"></param>
        public RichConsole(RichTextBox richTextBox)
        {
            Output = richTextBox;
        }

        /// <summary>
        /// Writes text to output.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(char value)
        {
            if (Output.InvokeRequired)
            {
                Output.Invoke(new RichTextBoxUpdateEventHandler(Write), new object[] { value });
            }
            else
            {
                base.Write(value);
                Output.AppendText(value.ToString()); // When character data is written, append it to the text box.
                Output.SelectionStart = Output.Text.Length;
                Output.ScrollToCaret();
            }
        }

        private void UpdateRichTextBox(string value)
        {
            base.Write(value);
            Output.AppendText(value.ToString()); // When character data is written, append it to the text box.
            Output.SelectionStart = Output.Text.Length;
            Output.ScrollToCaret();
        }

        /// <summary>
        /// Encodes text UTF8.
        /// </summary>
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
