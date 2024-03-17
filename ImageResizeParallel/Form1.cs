using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageResizeParallel
{
    public partial class ParallelForm : Form
    {

        private byte[] originalImageData;
        private byte[] resizedImageData;


        public ParallelForm()
        {
            InitializeComponent();

        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image loadedImage = Image.FromFile(openFileDialog.FileName);
                        if (loadedImage != null)
                        {
                            pictureBoxOriginal.Image = loadedImage;
                            originalImageData = GetImageData(openFileDialog.FileName); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message);
                    }
                }
            }
        }

        private void btn_Resize_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(textBox.Text) > 0 && Convert.ToInt32(textBox.Text) <= 100)
            {
                if (pictureBoxOriginal.Image != null && float.TryParse(textBox.Text, out float scaling))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    try
                    {
                        int newWidth = (int)(pictureBoxOriginal.Image.Width * scaling / 100);
                        int newHeight = (int)(pictureBoxOriginal.Image.Height * scaling / 100);

                        ShowImgOnPictureBox(pictureBoxOriginal, pictureBoxResized, newWidth, newHeight);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error resizing image: " + ex.Message);
                    }

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


        private void ShowImgOnPictureBox(PictureBox sourcePictureBox, PictureBox targetPictureBox, int newWidth, int newHeight)
        {
            if (originalImageData != null && originalImageData.Length > 0)
            {
                resizedImageData = ParallelImgResize(originalImageData, sourcePictureBox.Image.Width, sourcePictureBox.Image.Height, newWidth, newHeight);
                if (resizedImageData != null && resizedImageData.Length > 0)
                {
                    Image resizedImage = CreateImageData(resizedImageData, newWidth, newHeight);
                    if (resizedImage != null)
                    {
                        targetPictureBox.Image = resizedImage;
                    }
                    else
                    {
                        MessageBox.Show("Error creating resized image.");
                    }
                }
                else
                {
                    MessageBox.Show("Error resizing image.");
                }
            }
            else
            {
                MessageBox.Show("Error: Original image data is null or empty.");
            }
        }


        private Image CreateImageData(byte[] resizedData, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb);

            BitmapData resizedImageData = resizedImage.LockBits(new Rectangle(Point.Empty, resizedImage.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            Marshal.Copy(resizedData, 0, resizedImageData.Scan0, resizedData.Length);

            resizedImage.UnlockBits(resizedImageData);

            return resizedImage;
        }


        private byte[] GetImageData(string fileName)
        {
            using (Image image = Image.FromFile(fileName))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }
        }
       
        private byte[] ParallelImgResize(byte[] originalData, int originalW, int originalH, int newW, int newH)
        {
            byte[] resizedData = new byte[newW * newH * 4];


            for (int y = 0; y < newH; y++)
            {
                int offsetYStart = y * originalH / newH;
                int offsetYEnd = Math.Min(offsetYStart + originalH / newH, originalH);

                for (int x = 0; x < newW; x++)
                {
                    int offsetXStart = x * originalW / newW;
                    int offsetXEnd = Math.Min(offsetXStart + originalW / newW, originalW);

                    int sumR = 0, sumG = 0, sumB = 0, sumA = 0;
                    int pixelCount = 0;

                    for (int iy = offsetYStart; iy < offsetYEnd; iy++)
                    {
                        for (int ix = offsetXStart; ix < offsetXEnd; ix++)
                        {
                            int pixelIndex = Math.Min((iy * originalW + ix) * 4, originalData.Length - 4);

                            sumR += originalData[pixelIndex];
                            sumG += originalData[pixelIndex + 1];
                            sumB += originalData[pixelIndex + 2];
                            sumA += originalData[pixelIndex + 3];
                            pixelCount++;
                        }
                    }

                    int newPixelIndex = (y * newW + x) * 4;
                    resizedData[newPixelIndex] = (byte)(sumR / pixelCount);
                    resizedData[newPixelIndex + 1] = (byte)(sumG / pixelCount);
                    resizedData[newPixelIndex + 2] = (byte)(sumB / pixelCount);
                    resizedData[newPixelIndex + 3] = (byte)(sumA / pixelCount);
                }
            }

            return resizedData;
        }

     
        private void btn_Save_Click(object sender, EventArgs e)
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

