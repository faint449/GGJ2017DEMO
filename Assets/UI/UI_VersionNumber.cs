#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif


using UnityEngine;

public class UI_VersionNumber : MonoBehaviour
{
    public int versionNumber;
}

#if UNITY_EDITOR
[CustomEditor(typeof(UI_VersionNumber))]
public class UI_VersionNumber_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        UI_VersionNumber script = (UI_VersionNumber)target;
        GUILayout.Label("Version Number : " + script.versionNumber);
    }
}

//public class UI_VersionNumberPreProcesser : UnityEditor.AssetModificationProcessor
//{
//    void OnWillSaveAssets(string[] assetPaths)
//    {
//        foreach (string path in assetPaths)
//        {
//            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(path);
//            if (asset != null)
//            {
//                var comp = asset.GetComponent<UI_VersionNumber>();
//                if (comp != null)
//                {
//                    ++comp.versionNumber;
//                }
//            }
//        }
//        //return assetPaths;
//    }
//}

#endif