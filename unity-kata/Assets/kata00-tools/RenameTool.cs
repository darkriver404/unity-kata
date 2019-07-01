using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RenameTool
{
    /// <summary>
    /// 重命名场景
    /// </summary>
    public static void RenameAllScenes()
    {
        //1. find all scenes
        string[] guids = AssetDatabase.FindAssets("t:Scene");

        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            string dir = Path.GetDirectoryName(path);
            int pos = dir.LastIndexOf('/');
            string parentFolder = dir.Substring(pos + 1);
            Debug.Log(guid + " | " + path + " | " + parentFolder);

            // get index
            if (dict.ContainsKey(parentFolder))
            {
                dict[parentFolder]++;
            }
            else
            {
                dict.Add(parentFolder, 0);
            }
            int index = dict[parentFolder];
            // get name
            string newName = (index == 0) ? parentFolder : (parentFolder + "_" + index.ToString());
            //2. rename
            AssetDatabase.RenameAsset(path, newName);
        }
        dict.Clear();
        //3. save
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 重命名资源
    /// </summary>
    public static void RenameAsset()
    {
        //TODO
    }
}
