using System.IO;
using System.Text;

namespace velocist.WinForms.TextBoxControl;


/// <summary>
/// TextWriter implementation that writes into a WinForms TextBox control.
/// </summary>
public class TextBoxWriter : TextWriter {
	private TextBox _textBox;

	/// <summary>
	/// Initializes a new instance of <see cref="TextBoxWriter"/>.
	/// </summary>
	/// <param name="textBox">Target TextBox control.</param>
	public TextBoxWriter(TextBox textBox) {
		//if (textBox == null)
		//	textBox = new TextBox();

		_textBox = textBox;
	}

	/// <inheritdoc/>
	public override void Write(char value) {
		_textBox.Invoke(new Action(() => _textBox.AppendText(value.ToString())));
	}

	/// <inheritdoc/>
	public override void Write(string value) {
		_textBox.Invoke(new Action(() => _textBox.AppendText($"{value}")));
	}

	/// <inheritdoc/>
	public override Encoding Encoding => Encoding.UTF8;
}
