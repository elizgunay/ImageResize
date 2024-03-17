using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;




namespace ImageResize
{
    public partial class Consequential : Form
    {
        private byte[] originalImageData;
        private byte[] resizedImageData;

        public Consequential()
        {
            InitializeComponent();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxOriginal.Image = Image.FromFile(openFileDialog.FileName, true);

                    if (pictureBoxOriginal.Image != null)
                    {
                        originalImageData = GetImageData(pictureBoxOriginal.Image);
                    }
                    else
                    {
                        MessageBox.Show("Error loading the image.");
                    }
                }
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox.Text) > 0 && Convert.ToInt32(textBox.Text) <= 100)
            {

                if (pictureBoxOriginal.Image != null && float.TryParse(textBox.Text, out float scaling))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    ShowImgOnPictureBox(pictureBoxOriginal, pictureBoxResized, scaling);

                    stopwatch.Stop();
                    MessageBox.Show($"Image processing time: {stopwatch.ElapsedMilliseconds} milliseconds");
                }
                else
                {
                    MessageBox.Show("Please select an image and enter a valid scaling factor.");
                }

            }
            else
            {
                MessageBox.Show("Invalid scaling. Enter a value between 0 and 100.");

            }

        }


        private void ShowImgOnPictureBox(PictureBox sourcePictureBox, PictureBox targetPictureBox, float scaling)
        {
            if (originalImageData != null)
            {
                int newW = (int)(sourcePictureBox.Image.Width * scaling / 100);
                int newH = (int)(sourcePictureBox.Image.Height * scaling / 100);

                if (newW > 0 && newH > 0)
                {
                    resizedImageData = ResizeImage(originalImageData, sourcePictureBox.Image.Width, sourcePictureBox.Image.Height, newW, newH);
                    targetPictureBox.Image = CreateImageData(resizedImageData);
                }
                else
                {
                    MessageBox.Show("Invalid dimensions after scaling.");
                }
            }
        }


        private byte[] GetImageData(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ImageFormat format = image.RawFormat;
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        private byte[] ResizeImage(byte[] originalData, int originalWidth, int originalHeight, int newW, int newH)
        {
            try
            {
                using (MemoryStream originalStream = new MemoryStream(originalData))
                using (MagickImage originalImage = new MagickImage(originalStream))
                {
                    originalImage.Resize(newW, newH);
                    return originalImage.ToByteArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing image: {ex.Message}");
                return null;
            }
        }

        private Image CreateImageData(byte[] imageData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    PixelFormat format = GetImageFormat(imageData);

                    if (format != PixelFormat.Undefined)
                    {
                        return new Bitmap(image);
                    }
                    else
                    {
                        MessageBox.Show("Invalid image format.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating image: " + ex.Message);
                return null;
            }
        }


        private PixelFormat GetImageFormat(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            using (Image image = Image.FromStream(ms))
            {
                return image.PixelFormat;
            }
        }



       


        private void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap resizedImage = (Bitmap)pictureBoxResized.Image;

            if (resizedImage != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg;*.jpeg|PNG Image|*.png";
                    saveFileDialog.Title = "Save Resized Image";
                    saveFileDialog.ShowDialog();

                    if (saveFileDialog.FileName != "")
                    {
                        ImageFormat format = GetImageFormat1(saveFileDialog.FileName);

                        resizedImage.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("Image saved successfully.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No resized image to save. Please resize an image first.");
            }
        }
        
        private ImageFormat GetImageFormat1(string fileName)
        {
            string ext = Path.GetExtension(fileName);

            switch (ext.ToLower())
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                default:
                    throw new ArgumentException("Unsupported file format.");
            }
        }
    }
}
