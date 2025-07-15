using velocist.Services.Crypto;

namespace velocist.WinForms {

	/// <summary>
	/// Class for generates passwords
	/// </summary>
	public static class GeneratedPasswords {

		public static void Generate(bool generatePassword, TextBox password, string passwordSize, string randomStringSize, TextBox passwordSaltInput, TextBox passwordHash) {
			try {
				var passwordAux = password.Text;
				if (generatePassword) {
					passwordAux = Password(passwordSize);
					password.Text = passwordAux;
				}

				var saltInput = SaltInput(passwordAux, randomStringSize);
				var hash = Hash(passwordAux, saltInput);

				passwordSaltInput.Text = saltInput;
				passwordHash.Text = hash;
			} catch (Exception) {
				//MessageBox.Show("Generate" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static string Password(string passwordSize) {
			try {
				if (passwordSize.Length > 0)
					return CryptoBackendHelper.GeneratePassword(int.Parse(passwordSize));
			} catch (Exception) {
				//MessageBox.Show("Password" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}

		public static string SaltInput(string password, string randomStringSize) {
			try {
				if (password.Length > 0 && randomStringSize.Length > 0) {
					var salt = CryptoBackendHelper.GetRandomNumberString(int.Parse(randomStringSize));
					return CryptoBackendHelper.GenerateSalt(password, salt);
				}
			} catch (Exception) {
				//MessageBox.Show("SaltInput" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}

		public static string Hash(string password, string saltInput) {
			try {
				if (password.Length > 0 && saltInput.Length > 0)
					return CryptoBackendHelper.ComputeHash(password, new System.Security.Cryptography.SHA256CryptoServiceProvider(), saltInput);
			} catch (Exception) {
				//MessageBox.Show("Hash" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}
	}
}
