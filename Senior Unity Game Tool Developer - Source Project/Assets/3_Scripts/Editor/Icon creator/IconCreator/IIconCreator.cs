using UnityEngine;

public interface IIconCreator
{
    void SaveIcon(IconData iconData);

    Texture2D CreateIcon(IconData iconData);
}
