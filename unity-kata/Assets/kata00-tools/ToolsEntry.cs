using UnityEngine;
using UnityEditor;

public class ToolsEntry : MonoBehaviour
{
    [MenuItem("Tools/Rename All Scenes")]
    static void RenameAllScenes()
    {
        RenameTool.RenameAllScenes();
    }

    [MenuItem("Tools/Rename Asset")]
    static void RenameAsset()
    {
        //TODO
        //EditorWindow.GetWindow<>
        RenameTool.RenameAsset();
    }
}
