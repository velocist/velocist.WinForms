using velocist.Services.Extensions;
using velocist.WinForms.DataTableControl;

namespace velocist.WinForms.ComboBoxControl {

	/// <summary>
	/// the utilities class for the typed common component
	/// </summary>
	public static class ComboBoxExtension {

		/// <summary>
		/// Loads the combo.
		/// </summary>
		/// <param name="combo">The combo.</param>
		/// <param name="valueMember">The value member.</param>
		/// <param name="displayMember">The display member.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="dt">The dt.</param>
		/// <param name="stringCompleteAux">The string complete aux.</param>
		/// <param name="selectedIdex">The selected idex.</param>
		public static ComboBox LoadCombo<TModel>(this ComboBox combo, string valueMember, string displayMember, IEnumerable<TModel> dataSource, DataTable dt = null, string stringCompleteAux = null, int selectedIdex = 0) {
			try {
				combo.DataSource = dataSource;
				combo.ValueMember = valueMember;
				combo.DisplayMember = displayMember;
				if (selectedIdex != 0)
					combo.SelectedIndex = selectedIdex;

				if (dt != null) {
					if (stringCompleteAux != null && stringCompleteAux.Length > 0)
						combo.AutoCompleteCustomSource = dt.Autocomplete(displayMember, stringCompleteAux);
					else
						combo.AutoCompleteCustomSource = dt.Autocomplete(displayMember, null);

					combo.AutoCompleteMode = AutoCompleteMode.Suggest;
					combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
				}

				return combo;
			} catch (Exception ex) {
				throw new Exception(ErrorCodesId.NotLoaded.ToDescription(), ex);
			}
		}

		/// <summary>
		/// Autocompletes the ComboBox.
		/// </summary>
		/// <param name="combobox">The combobox.</param>
		/// <param name="stringComplete">The string complete.</param>
		/// <param name="dt">The dt.</param>
		/// <exception cref="Exception"></exception>
		public static void Autocomplete(this ComboBox combobox, string stringComplete, DataTable dt) {
			try {
				if (dt != null) {
					combobox.AutoCompleteCustomSource = dt.Autocomplete(stringComplete, null);
					combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
					combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
				}
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				throw;
			}
		}
	}
}

//public static void LoadTable(string connectionString, string sql, DataGridView dgvTable) {
//    try {
//        DataTable dt = SqlConnection.Read(sql);
//        if (dt != null) {
//            if (dt.Rows.Count > 0) {
//                dgvTable.DataSource = dt;
//                dgvTable.ClearSelection();
//            } else {
//                throw new Exception("Ningún registro en la tabla");
//            }
//        } else {
//            throw new Exception("Error al cargar la tabla");
//        }
//    } catch (VelocistException) {
//        throw new Exception("Error interno");
//    } catch (Exception ex) {
//        Trace.WriteLine(ex); throw;
//    }
//}
//public static void LoadComboConnections(ComboBox combo, Dictionary<string, SqlConnection> connectionsList) {
//    try {
//        if (connectionsList.Count > 0) {
//            GetAll<ComboItemHelper> lstConnections = new GetAll<ComboItemHelper>();
//            foreach (KeyValuePair<string, SqlConnection> item in connectionsList) {
//                //string database = item.Value[1];
//                ComboItemHelper itemCombo = new ComboItemHelper();
//                itemCombo.Key = item.Value.Database;
//                itemCombo.Value = item.Value.GetConnectionString();
//                itemCombo.Display = item.Value.Name;
//                lstConnections.Add(itemCombo);
//            }

//            combo.DataSource = lstConnections;
//            combo.ValueMember = "Value";
//            combo.DisplayMember = "Display";
//            combo.SelectedIndex = -1;
//        } else {
//            MessageBox.Show("Necesita configurar la aplicación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//    } catch (Exception ex) {
//        MessageBox.Show("LoadComboConnections" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}

//public static void LoadComboType(ComboBox combo) {
//    try {
//        Dictionary<string, string> list = new Dictionary<string, string>();
//        list.Add("U", "BASE TABLE");
//        list.Add("V", "VIEW");
//        list.Add("UV", "TABLES AND VIEWS");
//        list.Add("PR", "PROCEDURES");
//        GetAll<ComboItemHelper> listCombo = new GetAll<ComboItemHelper>();
//        foreach (KeyValuePair<string, string> item in list) {
//            //string database = item.Value[1];
//            ComboItemHelper itemCombo = new ComboItemHelper();
//            itemCombo.Key = item.Key;
//            itemCombo.Value = item.Value;
//            itemCombo.Display = item.Value;
//            listCombo.Add(itemCombo);
//        }

//        combo.DataSource = listCombo;
//        combo.ValueMember = "Value";
//        combo.DisplayMember = "Display";
//        combo.SelectedIndex = -1;
//    } catch (Exception ex) {
//        MessageBox.Show("LoadComboType" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}