using UnityEngine;
using System.IO;

namespace GamestureInterviewTask.Utilities
{
    public static class FileConverter
    {
        public static Texture2D ToTexture2D(FileInfo fileInfo)
        {
            return ToTexture2D(fileInfo.FullName);
        }

        public static Texture2D ToTexture2D(string path)
        {
            Texture2D texture = new Texture2D(2, 2);

            if(texture.LoadImage(File.ReadAllBytes(path)))
            {
                return texture;
            }
            return null;
        }
    }
}
