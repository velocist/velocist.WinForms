using velocist.Utilities.Helpers;

namespace velocist.WinForms.PictureBoxControl;

/// <summary>
/// PictureBox extensions
/// </summary>
public static class PictureBoxExtensions {

	/// <summary>
	/// Loads the image.
	/// </summary>
	/// <param name="pictureImage">The picture image.</param>
	/// <param name="imagePath">The image path.</param>
	/// <param name="image">The image.</param>
	/// <exception cref="System.Exception"></exception>
	public static void LoadImage(this PictureBox pictureImage, string imagePath = null, Image image = null) {
		try {
			if (image != null)
				pictureImage.Image = image;
			else {
				if (imagePath.Equals(string.Empty)) {
					pictureImage.Image = image;//;Properties.Resources.NoImage;
				} else {
					pictureImage.Image = Image.FromFile(imagePath);
				}
			}
		} catch (Exception ex) {
			throw new Exception(GlobalStrings.ERROR_LOAD_IMAGE, ex);
		}
	}
}
