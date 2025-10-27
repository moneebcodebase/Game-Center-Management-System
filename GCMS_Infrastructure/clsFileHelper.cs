using System;
using System.IO;
using System.Drawing;

namespace GCMS_Infrastructure
{
    public class clsFileHelper
    {
        /// <summary>
        /// Copies an image to the destination folder with a new GUID name.
        /// Returns the full path of the new image.
        /// </summary>
        public static string CopyImageToFolder(string imagePath, string destinationFolder)
        {
            if (!File.Exists(imagePath))
                throw new FileNotFoundException("Image file does not exist.", imagePath);

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            string extension = Path.GetExtension(imagePath);
            string newFileName = Guid.NewGuid().ToString() + extension;
            string newFullPath = Path.Combine(destinationFolder, newFileName);

            File.Copy(imagePath, newFullPath);

            return newFullPath;
        }

        /// <summary>
        /// Deletes the image at the given path if it exists.
        /// </summary>
        public static void DeleteImageFromFolder(string imagePath)
        {
            if (File.Exists(imagePath))
                File.Delete(imagePath);
            else
                return;

        }
    }
}
