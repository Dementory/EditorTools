using UnityEngine;

namespace EditorTool.Editor.IconCreator
{
    public interface IIconCreator
    {
        void SaveIcon(IconData iconData);

        Texture2D CreateIcon(IconData iconData);
    }
}
