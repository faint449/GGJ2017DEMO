#if UNITY_5_3_OR_NEWER && !UNITY_5_3_1 && !UNITY_5_3_2 && !UNITY_5_3_3
#define UIBUILD_TOOLS
#endif

using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class UIEditorTools
{

    const string defaultQUIPath = "Assets/Scripts/UI/Prefab";
    /// <summary>
    /// Creates a prefab based on current selected gameobject in hierarchy.
    /// </summary>
    public static void CreateUIPrefab()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        var selected = Selection.activeGameObject as GameObject;
        GameObject prefab = null;

        if (selected != null)
        {
            string currentScene = EditorSceneManager.GetActiveScene().path;
            string sceneName = Path.GetFileNameWithoutExtension(currentScene);
            string currentFolder = Path.GetDirectoryName(currentScene).Replace('\\', '/');

            string targetFolder = string.Empty;
            string[] subfolders = AssetDatabase.GetSubFolders(currentFolder);
            foreach(string subfolder in subfolders)
            {
                if (Path.GetFileName(subfolder).StartsWith("P_"))
                {
                    targetFolder = subfolder;
                    break;
                }
            }

            if(targetFolder == string.Empty)
            {
                Debug.Log("Invalid folder or no folders found");
                return;
            }

            string targetPath = targetFolder + "/" + selected.name + ".prefab";


            prefab = AssetDatabase.LoadAssetAtPath<GameObject>(targetPath);
            var oldPrefabVersionNumber = 0;
            if (prefab == null)
            {
                prefab = PrefabUtility.CreatePrefab(targetPath, selected);
                Debug.Log("Created new prefab from gameobject: " + targetPath);


            }
            //if gameobject is already a prefab
            else if (PrefabUtility.GetPrefabType(selected) != PrefabType.None && PrefabUtility.FindPrefabRoot(selected) != null)
            {
                var verionComp = prefab.GetComponent<UI_VersionNumber>();
                if (verionComp != null)
                {
                    oldPrefabVersionNumber = verionComp.versionNumber;
                }
                prefab = PrefabUtility.ReplacePrefab(selected, prefab, ReplacePrefabOptions.ConnectToPrefab);
                Debug.Log("Replaced prefab of prefab: " + targetPath);
            }
            else
            {
                var verionComp = prefab.GetComponent<UI_VersionNumber>();
                if (verionComp != null)
                {
                    oldPrefabVersionNumber = verionComp.versionNumber;
                }
                prefab = PrefabUtility.ReplacePrefab(selected, prefab, ReplacePrefabOptions.ReplaceNameBased);
                Debug.Log("Replaced prefab of gameobject: " + targetPath);
            }

            Selection.activeObject = prefab;
            AssetDatabase.SaveAssets();
             
            //set label
            var labels = AssetDatabase.GetLabels(prefab);
            List<string> l_str = new List<string>(labels);
            if (!l_str.Contains("P_UI"))
                l_str.Add("P_UI");
            AssetDatabase.SetLabels(prefab, l_str.ToArray());

            //add/get PnQVersionNumber Component
            var ui_VersionNumber = prefab.GetComponent<UI_VersionNumber>();
            if (ui_VersionNumber != null)
            {
                ui_VersionNumber.versionNumber = oldPrefabVersionNumber + 1;
            }
            else
            {
                var comp = prefab.AddComponent<UI_VersionNumber>();
                comp.versionNumber = oldPrefabVersionNumber + 1;
            }
        }
    }

    public static void Create_QUI_Scene()
    {
#if UIBUILD_TOOLS
        string currentScene = EditorSceneManager.GetActiveScene().path;
        
        var selected = Selection.activeGameObject.gameObject;
        var programmerPath = defaultQUIPath + "/Q_" + selected.name + ".unity";

        string currentFolder = Path.GetDirectoryName(currentScene).Replace('\\', '/');
        string targetFolder = string.Empty;
        string[] subfolders = AssetDatabase.GetSubFolders(currentFolder);
        foreach (string subfolder in subfolders)
        {
            if (Path.GetFileName(subfolder).StartsWith("P_"))
            {
                targetFolder = subfolder;
                break;
            }
        }

        if (targetFolder == string.Empty)
        {
            Debug.Log("Invalid folder or no folders found");
            return;
        }

        string targetPath = targetFolder + "/" + selected.name + ".prefab";


        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(targetPath);
        if (prefab == null)
        {
            Debug.Log("prefab not found");
            return;
        }

        var programmerScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

        var uiGameObject = (GameObject)GameObject.Instantiate(prefab);
        PrefabUtility.ConnectGameObjectToPrefab(uiGameObject, prefab as GameObject);
        
        EditorSceneManager.SaveScene(programmerScene, programmerPath);

        //Create a scene with the prefab and save
        EditorSceneManager.OpenScene(currentScene);
#else
        Debug.Log("Not supported in this version");
#endif
    }

    public static void Create_QUI_Prefab(GameObject selected )
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        //var selected = Selection.activeGameObject as GameObject;
        if (selected != null)
        {
            string targetPath = defaultQUIPath + "/Q_" + selected.name + ".prefab";

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(targetPath);
            //var oldPrefab = PrefabUtility.GetPrefabParent(selected) as GameObject;//Get the prefab 

            var clone = GameObject.Instantiate(selected);//create a clone and save that clone as Q_prefab

            //Create/Replace 
            if (prefab == null)
            {
                prefab = PrefabUtility.CreatePrefab(targetPath, clone);//Create the prefab at Scripts (HG-able)
                Debug.Log("Created new prefab from gameobject: " + targetPath);
            }
            //if gameobject is already a prefab
            else if (PrefabUtility.GetPrefabType(clone) != PrefabType.None && PrefabUtility.FindPrefabRoot(selected) != null)
            {
                prefab = PrefabUtility.ReplacePrefab(clone, prefab, ReplacePrefabOptions.ConnectToPrefab);
                Debug.Log("Replaced prefab of prefab: " + targetPath);
            }
            else
            {
                prefab = PrefabUtility.ReplacePrefab(clone, prefab, ReplacePrefabOptions.ReplaceNameBased);
                Debug.Log("Replaced prefab of gameobject: " + targetPath);
            }
            prefab.name = "Q_" + selected.name ;

            GameObject.DestroyImmediate(clone);//destroy clone from scene

            Selection.activeObject = prefab;

            AssetDatabase.SaveAssets();

            //set label
            var labels = AssetDatabase.GetLabels(prefab);
            List<string> l_str = new List<string>(labels);
            if (!l_str.Contains("Q_UI"))
                l_str.Add("Q_UI");
            AssetDatabase.SetLabels(prefab, l_str.ToArray());
        }
    }
    
}

public class UIEditorToolsContentMenu : EditorWindow
{
    [MenuItem("GameObject/!!!!!! Programmer !!!!!!/Make Scene", false, -1051)]
    public static void CreateProgrammerUIScene()
    {
        UIEditorTools.Create_QUI_Scene();
    }

    [MenuItem("GameObject/!!!!!! Programmer !!!!!!/Make Prefab %Q", false, -1051)]
    public static void CreateProgrammerUIPrefab()
    {
        UIEditorTools.Create_QUI_Prefab(Selection.activeGameObject as GameObject);
    }
}