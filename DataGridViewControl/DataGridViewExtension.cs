using velocist.Services.Reflection;

namespace velocist.WinForms.DataGridViewControl {

	/// <summary>
	/// The class fot init custom Datagridview without data
	/// </summary>
	public static class DataGridViewExtension {

		/// <summary>
		/// Initializes the table.
		/// </summary>
		/// <param name="dataGrid">The data grid.</param>
		/// <param name="columns">The columns.</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static DataGridView InitTable(this DataGridView dataGrid, Dictionary<int, object> columns) {
			try {
				dataGrid.Columns.Clear();

				var collumnsCollection = new DataGridViewColumn[columns.Count];
				for (var i = 0; i < columns.Count; i++) {
					if (!columns.ContainsKey(i))
						continue;

					collumnsCollection[i] = (DataGridViewColumn)columns[i];
				}

				dataGrid.Columns.AddRange(collumnsCollection);

				return dataGrid;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		public static DataGridView InitTable<TModel>(this DataGridView dataGrid) where TModel : class {
			try {
				dataGrid.Columns.Clear();

				Dictionary<int, object> columns = new();
				var properties = ObjectManager<TModel>.GetPropertiesDictionary(true).ToList();
				for (var i = 0; i < properties.Count; i++)
					columns.Add(i, CreateTextBox(properties[i].Key, properties[i].Key));

				var collumnsCollection = new DataGridViewColumn[columns.Count];
				for (var i = 0; i < columns.Count; i++) {
					if (!columns.ContainsKey(i))
						continue;

					collumnsCollection[i] = (DataGridViewColumn)columns[i];
				}

				dataGrid.Columns.AddRange(collumnsCollection);

				return dataGrid;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Configures the table.
		/// </summary>
		/// <param name="dgv">The DGV.</param>
		/// <param name="edit">if set to <c>true</c> [edit].</param>
		/// <param name="dataGridViewAutoSizeColumnsMode">The data grid view automatic size columns mode.</param>
		/// <param name="searchRow">if set to <c>true</c> [search row].</param>
		public static void ConfigureTable(this DataGridView dgv, bool edit = false, DataGridViewAutoSizeColumnsMode dataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells, bool searchRow = false) {

			dgv.AutoSizeColumnsMode = dataGridViewAutoSizeColumnsMode;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.AllowUserToResizeColumns = false;

			if (!edit) {
				dgv.AllowUserToAddRows = false;
				dgv.AllowUserToDeleteRows = false;
				dgv.AllowUserToResizeRows = false;
			}
		}

		/// <summary>
		/// Loads the table.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="dgvTable">The DGV table.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="searchRow">if set to <c>true</c> [search row].</param>
		/// <param name="allowAddNewRow"></param>
		/// <param name="allowDeleteRow"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static DataGridView LoadTable<TModel>(this DataGridView dgvTable, List<TModel> dataSource, bool searchRow = false, bool allowAddNewRow = false, bool allowDeleteRow = false) {
			try {
				if (dataSource != null)
					if (dataSource.Count > 0)
						//if (dgvTable.Columns.Count > 0)
						//	dgvTable.AutoGenerateColumns = false;
						//else 
						if (dataSource is List<string>)
							dgvTable.DataSource = dataSource.Select(x => new { Value = x }).ToList();
						else
							dgvTable.DataSource = dataSource;
				//else
				//	throw new Exception(ErrorCodesId.NoData.ToString());

				dgvTable.ClearSelection();
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}

			return dgvTable;
		}

		///// <summary>
		///// Exports the specified path.
		///// </summary>
		///// <typeparam name="TypeToConvert"></typeparam>
		///// <param name="path">The path.</param>
		///// <param name="dgw">The DGW.</param>
		///// <param name="type">The type.</param>
		///// <param name="rowHeader">if set to <c>true</c> [row header].</param>
		///// <returns></returns>
		///// <exception cref="Exception"></exception>
		//public static bool Export<TypeToConvert>(this DataGridView dgw, string path, string type, bool rowHeader) where TypeToConvert : class {
		//	try {
		//		var lines = new List<string>();
		//		var dt = (List<TypeToConvert>)dgw.DataSource;

		//		if (ExcelHelper<TypeToConvert>.Export(path, dt, type, rowHeader))
		//			return true;

		//		return false;
		//	} catch (Exception ex) {
		//		Trace.WriteLine(ex); throw;
		//	}
		//}

		//public static DataGridView CreateColumns() {
		//    try {

		//        return null;
		//    } catch (Exception ex) {
		//        _logger.LogError("Error iniciael datagridview", ex);
		//        return null;
		//    }
		//}

		/// <summary>
		/// Creates the text box.
		/// </summary>
		/// <param name="dataproperty">The dataproperty.</param>
		/// <param name="headertext">The headertext.</param>
		/// <param name="index"></param>
		/// <param name="isLink"></param>
		/// <param name="name">The name.</param>
		/// <param name="isNumbers">if set to <c>true</c> [is numbers].</param>
		/// <param name="visible">if set to <c>true</c> [visible].</param>
		/// <param name="link">Si el texto es un link o no.</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static DataGridViewTextBoxColumn CreateTextBox(string dataproperty, string headertext, int index = -1, bool isLink = false, string name = null, bool isNumbers = false, bool visible = true, string link = "") {
			try {
				DataGridViewTextBoxColumn item = new() {
					DataPropertyName = dataproperty,
					HeaderText = headertext,
					Name = "dgvTxt" + dataproperty,
					Visible = visible,
					DisplayIndex = index,
				};

				if (!string.IsNullOrEmpty(name))
					item.Name = "dgvTxt" + name;

				if (isNumbers) {
					item.DefaultCellStyle.Format = "0.00";
					item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}

				//if (isLink) {
				//	DataGridViewLinkColumn cell = new DataGridViewLinkColumn() {
				//		DataPropertyName = dataproperty,
				//		HeaderText = headertext,
				//		Name = "dgvTxt" + dataproperty,
				//		Visible = visible,
				//	};
				//}
				return item;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Creates the ComboBox.
		/// </summary>
		/// <param name="dataproperty">The dataproperty.</param>
		/// <param name="headertext">The headertext.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="valueMember">The value member.</param>
		/// <param name="displayMember">The display member.</param>
		/// <param name="name">The name.</param>
		/// <param name="visible">if set to <c>true</c> [visible].</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static DataGridViewComboBoxColumn CreateComboBox(string dataproperty, string headertext, DataTable dataSource, string valueMember, string displayMember, string name = null, bool visible = true) {
			try {
				DataGridViewComboBoxColumn item = new() {
					DataPropertyName = dataproperty,
					HeaderText = headertext,
					Name = "dgvCmb" + dataproperty,
					Visible = visible,

					DataSource = dataSource,
					ValueMember = valueMember,
					DisplayMember = displayMember
				};

				if (!string.IsNullOrEmpty(name))
					item.Name = "dgvCmb" + name;

				return item;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Creates the ComboBox.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataproperty">The dataproperty.</param>
		/// <param name="headertext">The headertext.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="valueMember">The value member.</param>
		/// <param name="displayMember">The display member.</param>
		/// <param name="name">The name.</param>
		/// <param name="visible">if set to <c>true</c> [visible].</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static DataGridViewComboBoxColumn CreateComboBox<T>(string dataproperty, string headertext, List<T> dataSource, string valueMember, string displayMember, string name = null, bool visible = true) {
			try {
				DataGridViewComboBoxColumn item = new() {
					DataPropertyName = dataproperty,
					HeaderText = headertext,
					Name = "dgvCmb" + dataproperty,
					Visible = visible,

					DataSource = dataSource,
					ValueMember = valueMember,
					DisplayMember = displayMember
				};

				if (!string.IsNullOrEmpty(name))
					item.Name = "dgvCmb" + name;

				return item;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Loads the combo.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="combo">The combo.</param>
		/// <param name="valueMember">The value member.</param>
		/// <param name="displayMember">The display member.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="dt">The dt.</param>
		/// <exception cref="Exception"></exception>
		public static void LoadCombo<TModel>(this DataGridViewComboBoxColumn combo, string valueMember, string displayMember, List<TModel> dataSource, DataTable dt = null) {
			try {
				combo.DataSource = dataSource;
				combo.ValueMember = valueMember;
				combo.DisplayMember = displayMember;
				//TODO ComboClumn
				//combo.SelectedIndex = -1;

			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Changes the color row.
		/// </summary>
		/// <param name="dtgv">The DTGV.</param>
		/// <param name="value">The value.</param>
		/// <param name="color">The color.</param>
		/// <exception cref="Exception"></exception>
		public static void ChangeColorRow(this DataGridView dtgv, string value, Color color) {
			try {
				foreach (DataGridViewRow row in dtgv.Rows)
					foreach (DataGridViewCell cell in row.Cells)
						if (cell.Value.Equals(value))
							row.DefaultCellStyle.BackColor = color;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Trace.WriteLine(ex);
				throw;
			}
		}
	}

	//public class DataGridViewColumnHelper {

	//    public DataGridViewCellStyle DefaultCellStyle { get; set; }
	//    public string HeaderText { get; set; }
	//    public string ToolTipText { get; set; }
	//    public bool Visible { get; set; }

	//    public bool ReadOnly { get; set; }
	//    public DataGridViewColumnSortMode SortMode { get; set; }

	//    public string DataPropertyName { get; set; }

	//    public string Name { get; set; }
	//    public AutoSizeMode AutoSizeMode { get; set; }
	//    public string ColumnType { get; set; }
	//    public int DividerWidth { get; set; }
	//    public int FillWeight { get; set; }
	//    public bool Frozen { get; set; }
	//    public int MinimumWidth { get; set; }
	//    public int Width { get; set; }

	//}

	//public class DataGridViewTextBoxHelper : DataGridViewTextBoxColumn {

	//    public int MaxInputLength { get; set; }

	//}

	//public class DataGridViewComboBoxHelper : DataGridViewColumnHelper {

	//    public DataGridViewComboBoxDisplayStyle DisplayStyle { get; set; }
	//    public bool DisplayStyleForCurrentCellOnly { get; set; }
	//    public FlatStyle FlatStyle { get; set; }

	//    public bool Sorted { get; set; }
	//    public bool AutoComplete { get; set; }
	//    public int DropDownWidth { get; set; }
	//    public int MaxDropDownItems { get; set; }

	//    public DataTable DataSource { get; set; }
	//    public string DisplayMember { get; set; }
	//    public GetAll<object> Items { get; set; }
	//    public string ValueMember { get; set; }

	//}
}
