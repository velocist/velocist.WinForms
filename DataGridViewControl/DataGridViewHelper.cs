using log4net;

namespace velocist.WinForms.DataGridViewControl;
/// <summary>
/// Helper methods for configuring WinForms DataGridView columns and controls.
/// </summary>
public class DataGridViewHelper {

	private static readonly ILog _log = LogManager.GetLogger(typeof(DataGridViewHelper));

	/// <summary>
	/// Initializes a DataGridView with the provided columns dictionary.
	/// </summary>
	/// <param name="dataGrid">Target DataGridView.</param>
	/// <param name="columns">Map of index to DataGridViewColumn.</param>
	/// <returns>Configured DataGridView or null on error.</returns>
	public static DataGridView InitDataGridView(DataGridView dataGrid, Dictionary<int, object> columns) {
		try {
			dataGrid.Columns.Clear();

			var collumnsCollection = new DataGridViewColumn[columns.Count];
			for (var i = 0; i < columns.Count; i++) {
				if (columns.ContainsKey(i)) {
					collumnsCollection[i] = (DataGridViewColumn)columns[i];
				}
			}

			dataGrid.Columns.AddRange(collumnsCollection);

			return dataGrid;
		} catch (Exception ex) {
			_log.Error("Error iniciael datagridview", ex);
			return null;
		}
	}

	/// <summary>
	/// Creates and returns a DataGridView with default columns.
	/// </summary>
	public static DataGridView CreateColumns() {
		try {

			return null;
		} catch (Exception ex) {
			_log.Error("Error iniciael datagridview", ex);
			return null;
		}
	}

	/// <summary>
	/// Creates a configured DataGridViewTextBoxColumn.
	/// </summary>
	/// <param name="dataproperty">Data property name.</param>
	/// <param name="headertext">Header text.</param>
	/// <param name="name">Column name.</param>
	/// <param name="is_numbers">Whether to format as number.</param>
	/// <param name="visible">Column visibility.</param>
	/// <returns>Configured text box column.</returns>
	public static DataGridViewTextBoxColumn CreateTextBox(string dataproperty, string headertext, string name, bool is_numbers = false, bool visible = true) {
		try {
			var item = new DataGridViewTextBoxColumn {
				DataPropertyName = dataproperty,
				HeaderText = headertext,
				Name = name,
				Visible = visible
			};

			if (is_numbers) {
				item.DefaultCellStyle.Format = "0.00";
				item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}

			return item;
		} catch (Exception ex) {
			_log.Error("Error iniciando DataGridViewTextBoxColumn", ex);
			return null;
		}
	}

	/// <summary>
	/// Creates a configured DataGridViewComboBoxColumn.
	/// </summary>
	/// <param name="dataproperty">Data property name.</param>
	/// <param name="headertext">Header text.</param>
	/// <param name="name">Column name.</param>
	/// <param name="dataSource">Combo data source.</param>
	/// <param name="valueMember">Value member.</param>
	/// <param name="displayMember">Display member.</param>
	/// <param name="visible">Column visibility.</param>
	/// <returns>Configured combo box column.</returns>
	public static DataGridViewComboBoxColumn CreateComboBox(string dataproperty, string headertext, string name, DataTable dataSource, string valueMember, string displayMember, bool visible = true) {
		try {
			var item = new DataGridViewComboBoxColumn {
				DataPropertyName = dataproperty,
				HeaderText = headertext,
				Name = name,
				Visible = visible,

				DataSource = dataSource,
				ValueMember = valueMember,
				DisplayMember = displayMember
			};

			return item;
		} catch (Exception ex) {
			_log.Error("Error iniciael datagridview", ex);
			return null;
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
//    public List<object> Items { get; set; }
//    public string ValueMember { get; set; }

//}
