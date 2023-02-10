using UnityEngine;

namespace EditorTool.File
{
    public abstract class ImageFileSaver
    {
        protected abstract string FileExtention { get; }
        public virtual void SaveImage(Texture2D image, string filePath)
        {
            filePath = $"{filePath}.{FileExtention}";
        }
    }
}
