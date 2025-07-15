namespace velocist.WinForms.MessageBoxControl {

	/// <summary>
	/// Handles error message.
	/// </summary>
	public class ErrorMessageBox {

		/// <summary>
		/// Handles the UIThreadException event of the ErrorMessageBox control.
		/// Handle the UI exceptions by showing a dialog box, and asking the user whether
		/// or not they wish to abort execution.        
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="t">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
		public static void ErrorMessageBox_UIThreadException(object sender, ThreadExceptionEventArgs t) {
			var result = DialogResult.Cancel;
			try {
				result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
			} catch {
				try {
					_ = MessageBox.Show("Fatal Windows Forms Error",
						"Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
				} finally {
					Application.Exit();
				}
			}

			// Exits the program when the user clicks Abort.
			if (result == DialogResult.Abort)
				Application.Exit();
		}

		/// <summary>
		/// Handles the UnhandledException event of the CurrentDomain control.
		///  Handle the UI exceptions by showing a dialog box, and asking the user whether
		/// or not they wish to abort execution.
		/// NOTE: This exception cannot be kept from terminating the application - it can only
		/// log the event, and inform the user about it.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
		public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			try {
				var ex = (Exception)e.ExceptionObject;

				//// Since we can't prevent the app from terminating, log this to the event log.
				//if (!EventLog.SourceExists("ThreadException")) {
				//    EventLog.CreateEventSource("ThreadException", "Application");
				//}

				//// Create an EventLog instance and assign its source.
				//EventLog myLog = new EventLog();
				//myLog.Source = "ThreadException";
				//myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
			} catch (Exception exc) {
				try {
					_ = MessageBox.Show("Fatal Non-UI Error",
						"Fatal Non-UI Error. Could not write the error to the event log. Reason: "
						+ exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				} finally {
					Application.Exit();
				}
			}
		}

		// Creates the error message and displays it.
		private static DialogResult ShowThreadExceptionDialog(string title, Exception e) {
			var errorMsg = "An application error occurred. Please contact the adminstrator " +
				"with the following information:\n\n";
			errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
			return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
				MessageBoxIcon.Stop);
		}
	}
}
