using UnityEngine;

namespace EditorTool.Editor.IconCreator
{
    public interface IIconComposer
    {
        void Compose(IconData iconData, out Camera camera);

        void Clear();
    }
}
