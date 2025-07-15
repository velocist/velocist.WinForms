using System.IO;
using System.Text;

namespace velocist.WinForms.TextBoxControl {


	public class TextBoxWriter : TextWriter {
		private TextBox _textBox;

		public TextBoxWriter(TextBox textBox) {
			//if (textBox == null)
			//	textBox = new TextBox();

			_textBox = textBox;
		}

		public override void Write(char value) {
			_textBox.Invoke(new Action(() => _textBox.AppendText(value.ToString())));
		}

		public override void Write(string value) {
			_textBox.Invoke(new Action(() => _textBox.AppendText($"{value}")));
		}

		public override Encoding Encoding => Encoding.UTF8;
	}
}
