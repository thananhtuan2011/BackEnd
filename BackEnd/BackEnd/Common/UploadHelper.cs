using System.IO;

namespace BackEnd.Common
{
    public class UploadHelper
    {

        public static async Task<string> UploadImgAsync(string imageBase64, string filename)
        {
            if (string.IsNullOrEmpty(imageBase64) || string.IsNullOrEmpty(filename))
            {
                return null; // Return null if inputs are invalid
            }

            try
            {
                // Extract base64 string (remove the data:image/...;base64, prefix if present)
                var base64Data = imageBase64.Contains(",")
                    ? imageBase64.Split(',')[1]
                    : imageBase64;

                // Convert base64 string to byte array
                byte[] imageBytes = Convert.FromBase64String(base64Data);

                // Define file path and ensure directory exists
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                filename = checkFilename(filename, directoryPath);

                Directory.CreateDirectory(directoryPath);

                // Append file extension if not present in the filename
                string fileExtension = ".png"; // Default file extension
                if (!filename.Contains("."))
                {
                    filename += fileExtension;
                }

                var filePath = Path.Combine(directoryPath, filename);

                // Save the image to disk
                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                // Return the file path for reference
                return filePath;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error uploading image: {ex.Message}");
                return null;
            }
        }
        private static string checkFilename(string filename, string path)
        {
            int i = 1;
            var arr = filename.Split(".");
            string _filename = "";
            for (int ii = 0; ii < arr.Length - 1; ii++)
            {
                _filename += (_filename == "" ? "" : ".") + arr[ii];
            }
            string _extension = "." + arr[arr.Length - 1];
            string filename_new = _filename;
            string pathFile = _filename + _extension;
            while (File.Exists(path + pathFile))
            {
                filename_new = _filename + " (" + i + ")";
                pathFile = filename_new + _extension;
                i = i + 1;
            }

            return pathFile;
        }

    }
}
