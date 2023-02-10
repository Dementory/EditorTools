using UnityEngine;

public interface IIconComposer
{
    void Compose(IconData iconData, out Camera camera);

    void Clear();
}
