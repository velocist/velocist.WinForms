using log4net;

namespace velocist.WinForms.DataGridViewControl {
	public class DataGridViewHelper {

		private static readonly ILog _log = LogManager.GetLogger(typeof(DataGridViewHelper));

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

		public static DataGridView CreateColumns() {
			try {

				return null;
			} catch (Exception ex) {
				_log.Error("Error iniciael datagridview", ex);
				return null;
			}
		}

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
}
