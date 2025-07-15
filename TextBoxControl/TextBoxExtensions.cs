using velocist.WinForms.DataTableControl;

namespace velocist.WinForms.TextBoxControl {

	/// <summary>
	/// The utilities class for common controls 
	/// </summary>
	public static class TextBoxExtensions {

		/// <summary>
		/// Copies the specified text to clipboard
		/// </summary>
		/// <param name="text">The text.</param>
		public static void Copy(string text) {
			if (text.Length > 0)
				Clipboard.SetText(text);
		}

		/// <summary>
		/// Updates the console.
		/// </summary>
		/// <param name="console">The console.</param>
		/// <param name="text">The text.</param>
		/// <param name="newLine">if set to <c>true</c> [new line].</param>
		/// <param name="inicio">if set to <c>true</c> [inicio].</param>
		public static void UpdateConsole(this TextBox console, string text, bool newLine = true, bool inicio = false) {
			var data = console.Text;
			string aux;
			if (newLine)
				if (inicio)
					aux = text + Environment.NewLine + data;
				else
					aux = data + Environment.NewLine + text;
			else if (inicio)
				aux = text + Environment.NewLine + data;
			else
				aux = data + text;

			console.Text = aux;
		}

		/// <summary>
		/// Autocompletes the textox.
		/// </summary>
		/// <param name="textBox">The text box.</param>
		/// <param name="stringComplete">The string complete.</param>
		/// <param name="dt">The dt.</param>
		/// <param name="stringCompleteAux">The string complete aux.</param>
		/// <exception cref="Exception"></exception>
		public static void AutocompleteTextox(this TextBox textBox, string stringComplete, DataTable dt, string stringCompleteAux = null) {
			try {
				if (dt != null) {
					textBox.AutoCompleteCustomSource = dt.Autocomplete(stringComplete, stringCompleteAux);
					textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
					textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
				}
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				throw;
			}
		}
	}
}
