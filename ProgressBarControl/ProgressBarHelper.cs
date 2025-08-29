namespace velocist.WinForms.ProgressBarControl;

/// <summary>
/// Class to support progress bar component
/// </summary>
public class ProgressBarHelper {

	/// <summary>
	/// The BCK WRK progress
	/// </summary>
	private readonly BackgroundWorker bckWrkProgress;

	/// <summary>
	/// The progress bar
	/// </summary>
	private readonly ProgressBar progressBar;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProgressBarHelper"/> class.
	/// </summary>
	/// <param name="bckWrkProgress">The BCK WRK progress.</param>
	/// <param name="progressBar">The progress bar.</param>
	public ProgressBarHelper(BackgroundWorker bckWrkProgress, ProgressBar progressBar) {
		this.bckWrkProgress = bckWrkProgress;
		this.progressBar = progressBar;
	}

	/// <summary>
	/// Handles the DoWork event of the BckWrkProgress control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
	private void BckWrkProgress_DoWork(object sender, DoWorkEventArgs e) => DoWorkProgressBar(sender, e);

	/// <summary>
	/// Handles the ProgressChanged event of the BckWrkProgress control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
	private void BckWrkProgress_ProgressChanged(object sender, ProgressChangedEventArgs e) => ChangeProgressBar(e);

	/// <summary>
	/// Handles the RunWorkerCompleted event of the BckWrkProgress control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
	private void BckWrkProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => RunWorkerCompletedProgressBar(e);

	/// <summary>
	/// Starts the asynchronous progress bar.
	/// </summary>
	public void StartAsyncProgressBar() {
		if (bckWrkProgress.IsBusy != true)              // Start the asynchronous operation.
			bckWrkProgress.RunWorkerAsync();
	}

	/// <summary>
	/// Cancels the asynchronous progress bar.
	/// </summary>
	public void CancelAsyncProgressBar() {
		if (bckWrkProgress.WorkerSupportsCancellation == true)              // Cancel the asynchronous operation.
			bckWrkProgress.CancelAsync();
	}

	/// <summary>
	/// Does the work progress bar.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
	private void DoWorkProgressBar(object sender, DoWorkEventArgs e) {
		var worker = sender as BackgroundWorker;
		for (var i = 1; i <= 100; i++)
			if (worker.CancellationPending == true) {
				e.Cancel = true;
				break;
			} else {
				// Perform a time consuming operation and report progress.
				Thread.Sleep(500);
				worker.ReportProgress(i * 1);
			}
	}

	/// <summary>
	/// Changes the progress bar.
	/// </summary>
	/// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
	public void ChangeProgressBar(ProgressChangedEventArgs e) =>
		//UpdateConsole(txtConsole, "...." + e.ProgressPercentage.ToString() + "%", false, false);
		progressBar.Value = e.ProgressPercentage;

	/// <summary>
	/// Runs the worker completed progress bar.
	/// </summary>
	/// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
	private void RunWorkerCompletedProgressBar(RunWorkerCompletedEventArgs e) {
		if (e.Cancelled == true)                //UpdateConsole(txtTabDatabaseConsole, DateTime.Now + " -->" + "Canceled!");
												//UpdateConsole(txtConsole, "100%", false, false);
			progressBar.Value = 0;
		else if (e.Error != null)               //UpdateConsole(txtConsole, DateTime.Now + " -->" + "Error! " + e.Error.Message, true, false);
			progressBar.Value = 0;
		else {
			//UpdateConsole(txtTabDatabaseConsole, DateTime.Now + " -->" + "Done!");
		}
	}
}
