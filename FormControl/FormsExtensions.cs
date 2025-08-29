namespace velocist.WinForms.FormControl;

/// <summary>
/// Forms extensions
/// </summary>
public static class FormsExtensions {

	/// <summary>
	/// Checks the open forms.
	/// </summary>
	/// <typeparam name="TForm">The type of the form.</typeparam>
	/// <param name="form">The form.</param>
	/// <returns></returns>
	public static bool CheckOpenForms<TForm>(this Form form) {
		var openForm = form.Controls.Cast<Control>().ToList().Where(x => x.GetType().Equals(typeof(Form))).Cast<Form>().ToList().Find(x => x.Name.Equals(nameof(TForm)));
		if (openForm != null) {
			_ = openForm.Focus();
			return true;

		}
		//foreach (var childForm in form.MdiChildren) {
		//	if (childForm.Name.Equals(nameof(TForm))) {
		//		_ = childForm.Focus();
		//		return true;
		//	}
		//}

		return false;
	}

	/// <summary>
	/// Resizes the form.
	/// </summary>
	/// <param name="form">The form.</param>
	/// <param name="heightRatio">The height ratio.</param>
	/// <param name="widthRatio">The width ratio.</param>
	public static void ResizeForm(this Form form, float heightRatio = 0, float widthRatio = 0) {
		try {
			if (form != null)                   //form.AutoSize = true;
												//form.AutoSizeMode = AutoSizeMode.GrowAndShrink;

				//float widthRatio1 = form.Bounds.Width/1280;// Screen.PrimaryScreen.Bounds.Width / 1280;
				//float heightRatio1 = form.Bounds.Height / 800f;//Screen.PrimaryScreen.Bounds.Height / 800f;
				//SizeF scale = new SizeF(widthRatio1, heightRatio1);
				//form.Scale(scale);
				//form.AutoScaleMode = AutoScaleMode.Font;

				//foreach (Control control in form.Controls) {
				if (form.Controls != null && form.Controls.Count > 0)
					ResizeControls(form.Controls, heightRatio, widthRatio);
		} catch (Exception ex) {
			Trace.WriteLine(ex);
			throw;
		}
	}

	/// <summary>
	/// Resizes the controls.
	/// </summary>
	/// <param name="controls">The controls.</param>
	/// <param name="heightRatio">The height ratio.</param>
	/// <param name="widthRatio">The width ratio.</param>
	private static void ResizeControls(Control.ControlCollection controls, float heightRatio = 0, float widthRatio = 0) {
		try {
			if (controls != null)                   //AnchorStyles anchorStyles = AnchorStyles.Top | AnchorStyles.Right;
													//AnchorStyles anchorStylesButton = AnchorStyles.Bottom | AnchorStyles.Right;
													//AnchorStyles anchorStylesGroupBox = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

				foreach (Control control in controls) {
					float XAxisLocation;
					float YAxisLocation;
					if (control.GetType().Equals(typeof(TextBox))) {
						var item = (TextBox)control;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;

					} else if (control.GetType().Equals(typeof(Label))) {
						var item = (Label)control;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;

					} else if (control.GetType().Equals(typeof(ComboBox))) {
						var item = (ComboBox)control;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;

					} else if (control.GetType().Equals(typeof(CheckBox))) {
						var item = (CheckBox)control;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;

					} else if (control.GetType().Equals(typeof(PictureBox))) {
						var item = (PictureBox)control;

					} else if (control.GetType().Equals(typeof(DataGridView))) {
						var item = (DataGridView)control;
						//item.Dock = DockStyle.Fill;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;

					} else if (control.GetType().Equals(typeof(GroupBox))) {
						var item = (GroupBox)control;

					} else if (control.GetType().Equals(typeof(Button))) {
						var item = (Button)control;
						//item.Anchor = anchorStylesButton;
						XAxisLocation = item.Location.X + widthRatio;
						YAxisLocation = item.Location.Y + heightRatio;
					}

					//_log.DebugFormat($"widthInitial: {control.Width}");
					//control.Width = Convert.ToInt32(control.Width) - Convert.ToInt32(widthRatio);
					//_log.DebugFormat($"widthEnd: {control.Width}");

					if (control.Controls != null && control.Controls.Count > 0)
						ResizeControls(control.Controls, heightRatio, widthRatio);

					//control.AutoSize = true;
					//control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * heightRatio * widthRatio);
					//control.Location = new Point();
					//var XAxisLocation = item.Location.X + item.Width * (.42);
					//var YAxisLocation = item.Location.Y + item.Height * (.30);
					//item.Location = item.PointToClient(new Point(Convert.ToInt32(XAxisLocation), Convert.ToInt32(YAxisLocation)));
					//item.Width = Convert.ToInt32(item.Width);// *(.14));
					//item.Height = Convert.ToInt32(item.Height);// * (.05));
					//item.Font = new Font("Microsoft Sans Serif", Convert.ToInt32(item.Width/2));

				}
		} catch (Exception ex) {
			Trace.WriteLine(ex);
			throw;
		}
	}

	/// <summary>
	/// Configures the form.
	/// </summary>
	/// <param name="form">The form.</param>
	/// <param name="title"></param>
	/// <param name="windowsState"></param>
	/// <param name="minimizeBox"></param>
	/// <param name="maximizeBox"></param>
	public static void ConfigureForm(this Form form, string title, FormWindowState windowsState = FormWindowState.Maximized, bool minimizeBox = true, bool maximizeBox = true) {
		form.Text = title;
		form.StartPosition = FormStartPosition.CenterScreen;
		form.WindowState = windowsState;
		form.BackColor = SystemColors.Control;

		form.MaximizeBox = minimizeBox;
		form.MinimizeBox = maximizeBox;
		form.ControlBox = true;

		//form.Icon = Properties.Resources.IconSample;
		//form.MinimumSize = form.Size;
		//form.MaximumSize = 

		//form.AutoSize = true;
		//form.AutoScaleMode = AutoScaleMode.Font;
		//form.AutoScaleDimensions = System.Drawing.SizeF.;
		//float widthRatio = Screen.PrimaryScreen.Bounds.Width / 1280;
		//float heightRatio = Screen.PrimaryScreen.Bounds.Height / 800f;
		//SizeF scale = new SizeF(widthRatio, heightRatio);
		////form.Scale(scale);
		//form.Font = new Font("Microsoft Sans Serif", form.Font.SizeInPoints * heightRatio * widthRatio);
	}

	/// <summary>
	/// Configures the modal.
	/// </summary>
	/// <param name="form">The form.</param>
	/// <param name="title">The title.</param>
	public static void ConfigureModal(this Form form, string title) {
		form.Text = title;
		form.StartPosition = FormStartPosition.CenterScreen;
		form.BackColor = SystemColors.Control;

		form.ControlBox = true;
		form.MaximizeBox = false;
		form.MinimizeBox = false;
	}
}
