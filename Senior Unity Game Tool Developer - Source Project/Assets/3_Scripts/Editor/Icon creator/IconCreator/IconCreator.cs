using EditorTool.File;
using UnityEditor;
using UnityEngine;

namespace EditorTool.Editor.IconCreator
{
    public class IconCreator : IIconCreator
    {
        private const int ICON_WIDTH = 195;
        private const int ICON_HEIGHT = 285;
        private const int ICON_DEPTH = 24;

        private IScreenshotCapture _screenshotCapture = new ScreenshotCapture();
        private IIconComposer _iconComposer = new IconComposer();
        private ImageFileSaver _imageSaver = new ImageJPGFileSaver();

        public void SaveIcon(IconData iconData)
        {
            if (!iconData.ModelPrefab) return;

            string saveFolder = EditorUtility.OpenFolderPanel("Choose save folder", "", "");
            string filePath = $"{saveFolder}/{iconData.ModelPrefab.gameObject.name}_icon.jpg";

            Texture2D icon = CreateIcon(iconData);
            _imageSaver.SaveImage(icon, filePath);
        }

        public Texture2D CreateIcon(IconData iconData)
        {
            if (!iconData.ModelPrefab) return null;

            _iconComposer.Compose(iconData, out Camera camera);

            Texture2D icon = _screenshotCapture.CaptureScreen(camera, ICON_WIDTH, ICON_HEIGHT, ICON_DEPTH);

            _iconComposer.Clear();

            return icon;
        }

    }
}
