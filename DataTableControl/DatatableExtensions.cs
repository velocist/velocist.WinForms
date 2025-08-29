namespace velocist.WinForms.DataTableControl;

/// <summary>
/// Extensions for winforms datatables
/// </summary>
public static class DatatableExtensions {

	/// <summary>
	/// Autocompletes the specified dt.
	/// </summary>
	/// <param name="dt">The dt.</param>
	/// <param name="stringComplete">The string complete.</param>
	/// <param name="stringCompleteAux">The string complete aux.</param>
	/// <returns></returns>
	public static AutoCompleteStringCollection Autocomplete(this DataTable dt, string stringComplete, string stringCompleteAux) {

		AutoCompleteStringCollection coleccion = [];
		//recorrer y cargar los items para el autocompletado
		foreach (DataRow row in dt.Rows)
			if (stringCompleteAux != null && stringCompleteAux.Length > 0)
				_ = coleccion.Add(Convert.ToString(row[stringCompleteAux]));
			else
				_ = coleccion.Add(Convert.ToString(row[stringComplete]));

		return coleccion;
	}
}