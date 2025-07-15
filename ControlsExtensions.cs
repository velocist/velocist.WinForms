namespace velocist.WinForms {

	/// <summary>
	/// Class that extends win forms System.Windows.Forms.Controls
	/// </summary>
	public static class ControlsExtensions {

		/// <summary>
		/// Cleans the controls.
		/// </summary>
		/// <param name="controls">The controls.</param>
		public static void CleanControls(this Control controls) {
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(TextBox)))).Cast<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(ComboBox)))).Cast<ComboBox>().ToList().ForEach(x => x.SelectedIndex = -1);
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(DataGridView)))).Cast<DataGridView>().ToList().ForEach(x => x.ClearSelection());
		}

		/// <summary>
		/// Sets the controls to read only.
		/// </summary>
		/// <param name="controls">The controls.</param>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		public static void SetControlsToReadOnly(this Control controls, bool readOnly) {
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(TextBox)))).Cast<TextBox>().ToList().ForEach(x => x.Enabled = !readOnly);
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(ComboBox)))).Cast<ComboBox>().ToList().ForEach(x => x.Enabled = !readOnly);
			controls.Controls.Cast<Control>().ToList().Where(x => (x.GetType().Equals(typeof(DataGridView)))).Cast<DataGridView>().ToList().ForEach(x => x.ClearSelection());
		}

		///// <summary>
		///// Cleans the controls.
		///// </summary>
		///// <param name="controls">The controls.</param>
		//[Obsolete("Change for CleanControls(this Control controls)")]
		//public static void CleanControls(this Control.ControlCollection controls) {
		//	foreach (Control control in controls) {
		//		if (control.Controls != null && control.Controls.Count > 0) {
		//			CleanControls(controls);
		//		} else {
		//			if (control.GetType().Equals(typeof(TextBox))) {
		//				control.Text = string.Empty;
		//			} else if (control.GetType().Equals(typeof(ComboBox))) {
		//				var item = (ComboBox)control;
		//				item.SelectedIndex = -1;
		//			} else if (control.GetType().Equals(typeof(PictureBox))) {
		//				//PictureBox item = (PictureBox)control;
		//				//item.BackgroundImage = Properties.Resources.LogoSample;
		//			} else if (control.GetType().Equals(typeof(DataGridView))) {
		//				var item = (DataGridView)control;
		//				item.ClearSelection();
		//			}
		//		}
		//	}
		//}

		/// <summary>
		/// Sets the controls to read only.
		/// </summary>
		/// <param name="controls">The controls.</param>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		[Obsolete("Change for SetControlsToReadOnly(this Control controls, ...)")]
		public static void SetControlsToReadOnly(Control.ControlCollection controls, bool readOnly) {
			foreach (Control control in controls) {
				if (control.GetType().Equals(typeof(TextBox))) {
					var item = (TextBox)control;
					item.Enabled = !readOnly;
				} else if (control.GetType().Equals(typeof(ComboBox))) {
					var item = (ComboBox)control;
					item.Enabled = !readOnly;
				} else if (control.GetType().Equals(typeof(CheckBox))) {
					var item = (CheckBox)control;
					item.Enabled = !readOnly;
				} else if (control.GetType().Equals(typeof(DataGridView))) {
					var item = (DataGridView)control;
					//item.Enabled = !readOnly;
					//item.ReadOnly = readOnly;
					if (item.Columns.Count > 0) {
						for (var i = 0; i < item.Columns.Count; i++) {
							item.Columns[i].ReadOnly = readOnly;
						}
					}
				} else if (control.Controls != null && control.Controls.Count > 0) {
					SetControlsToReadOnly(control.Controls, readOnly);
				}

				//if (control.Controls != null && control.Controls.Count > 0) {
				//    ReadOnlyControls(control.Controls, readOnly);
				//} else {
				//    if (control.GetType().Equals(typeof(TextBox))) {
				//        TextBox item = (TextBox)control;
				//        item.Enabled = !readOnly;
				//    } else if (control.GetType().Equals(typeof(ComboBox))) {
				//        ComboBox item = (ComboBox)control;
				//        item.Enabled = !readOnly;
				//    } else if (control.GetType().Equals(typeof(CheckBox))) {
				//        CheckBox item = (CheckBox)control;
				//        item.Enabled = !readOnly;
				//    } else if (control.GetType().Equals(typeof(DataGridView))) {
				//        DataGridView item = (DataGridView)control;
				//        item.Enabled = !readOnly;
				//    }
				//}
			}
		}
	}
}
