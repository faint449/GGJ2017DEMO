using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;
//using System.Collections;

public class ZDGUIContextMenu : EditorWindow
{
    [MenuItem("GameObject/--> Select Current Scene", false, -1050)]
    static void SelectCurrentScene()
    {
        string myScene = EditorSceneManager.GetActiveScene().path;

        if (myScene == "")
        {
            Debug.LogFormat("<b>" + "Your scene is not saved yet!" + "</b>");
        }
        else
        {
            Debug.LogFormat("<b><color=Blue>" + myScene + "</color></b>");
            EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(myScene));
        }

    }
    [MenuItem("GameObject/!!!!!! Make UI Prefab !!!!!!", false, -1051)]
    public static void CreateUIPrefab()
    {
        UIEditorTools.CreateUIPrefab();
    }

    [MenuItem("Assets/AddPVersion", false, -1052)]
    static void AddPVersion()
    {
        //set label
        var labels = AssetDatabase.GetLabels(Selection.activeGameObject);
        List<string> l_str = new List<string>(labels);
        if (!l_str.Contains("P_UI"))
            l_str.Add("P_UI");
        AssetDatabase.SetLabels(Selection.activeGameObject, l_str.ToArray());

        if (Selection.activeGameObject.GetComponent<UI_VersionNumber>() == null)
        {
            var comp = Selection.activeGameObject.AddComponent<UI_VersionNumber>();
            comp.versionNumber = 1;
        }
        else
        {
            ++Selection.activeGameObject.GetComponent<UI_VersionNumber>().versionNumber;
        }
    }

    [MenuItem("Assets/---> Scene", false, 10000)]
    static void UIScene()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI/Scenes/root.tif");
        //EditorGUIUtility.PingObject(Selection.activeObject);
    }

    [MenuItem("Assets/---> Textures", false, 10002)]
    static void UITextures()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI/Textures/root.tif");
    }

    [MenuItem("Assets/---> Widgets", false, 10003)]
    static void UIWidgets()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI/Widgets/root.tif");
    }

    [MenuItem("Assets/---> SoundService (OnClick Sound)", false, 10004)]
    static void SoundService()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Scripts/Audio/SoundService.cs");
    }

    [MenuItem("Assets/---> PlayUISound (Awake)", false, 10005)]
    static void PlayUISoundAwake()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Scripts/Audio/PlayUISound.cs");
    }

    //TEXT
    [MenuItem("GameObject/ZDGUI/Text/Text20", false, -1000)]
    static void Text22()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/Text/Text20.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text26", false, -1000)]
    static void Text24()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/Text/Text26.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }


    //MISC
    [MenuItem("GameObject/ZDGUI/EditorOnly/TestButton", false, 1)]
    static void TestButton()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/TestButton/TestButton.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/3DCube", false, 1)]
    static void EDITORONLY3DTEST()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/EditorOnly3DCube/EDITOR_ONLY_3D_CUBE.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/PCFemale", false, 1)]
    static void PCFemale()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models/pc/prefabs/prefab_pc_female.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/PCMale", false, 1)]
    static void PCMale()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models/pc/prefabs/prefab_pc_male.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/Hero", false, 1)]
    static void Hero()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models/hero/prefabs/prefab_hero_0021.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/Boss", false, 1)]
    static void Boss()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models/boss/prefabs/prefab_boss_0148.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }
    [MenuItem("GameObject/ZDGUI/EditorOnly/AudioListenerEditorOnly", false, 1)]
    static void AudioListenerEditorOnly()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/AudioListenerEditorOnly.prefab", typeof(GameObject));
        CreateInRoot(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/ProgressBarFill", false, 1)]
    static void ProgressBarFill()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/ProgressBar/ProgressBarFill.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }


    //FPS Counter
    [MenuItem("GameObject/ZDGUI/Misc/FPS", false, -100)]
    static void FPS()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/FPS/Canvas_ssOverlay_FPS.prefab", typeof(GameObject));
        CreateInRoot(uiWidget);
    }


    //####################################################################

    //BUTTONS

    //####################################################################


    //####################################################################

    //TABS


    //####################################################################

    //SPINNER


    //####################################################################
    //####################################################################

    //SLIDER

    //####################################################################

    //FAKE DIALOG

    //####################################################################


    //####################################################################
    // Create widget as a child of selection
    //####################################################################

    //------------------------------------------
    //Create as a child object
    static void CreateAsChild(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        newPrefab.transform.SetParent(Selection.activeTransform, false);
        PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;
    }

    static void CreateAsChildNoBreak(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        newPrefab.transform.SetParent(Selection.activeTransform, false);
        //PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;
    }

    //Create In Root
    static void CreateInRoot(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;
    }

    [System.Serializable]
    public class GameObjectDifference
    {
        public GameObject p_UI;
        public GameObject q_UI;
    }


    static Dictionary<int, List<GameObjectDifference>> GetDifference()
    {
        Dictionary<int, List<GameObjectDifference>> result = new Dictionary<int, List<GameObjectDifference>>();

        result[0] = new List<GameObjectDifference>(); //result[0] = list of Q P UI assets name that version is different
        result[1] = new List<GameObjectDifference>(); //result[1] = list of P UI asset name that cant find Q UI asset

        //P_UI Prefab
        string[] p_guids = AssetDatabase.FindAssets("l:P_UI", new string[] { "Assets/UI/Scenes" });
        foreach (var p_guid in p_guids)
        {
            int pVersionNum = 0, qVersionNum = 0;

            var p_path = AssetDatabase.GUIDToAssetPath(p_guid);

            GameObject p_go = AssetDatabase.LoadAssetAtPath(p_path, typeof(GameObject)) as GameObject;
            var pVersionComp = p_go.GetComponent<UI_VersionNumber>();
            if (pVersionComp != null)
                pVersionNum = pVersionComp.versionNumber;

            //Q_UI Prefab
            string[] q_guids = AssetDatabase.FindAssets(p_go.name + " l:Q_UI", new string[] { "Assets/Scripts/UI/Prefab" });
            if (q_guids.Length < 1)
            {
                result[1].Add(new GameObjectDifference() { p_UI = p_go });
            }
            foreach (var q_guid in q_guids)
            {
                var q_path = AssetDatabase.GUIDToAssetPath(q_guid);

                GameObject q_go = AssetDatabase.LoadAssetAtPath(q_path, typeof(GameObject)) as GameObject;
                if (q_go.name != "Q_"+p_go.name) continue;
                var qVersionComp = q_go.GetComponent<UI_VersionNumber>();
                if (qVersionComp != null)
                    qVersionNum = qVersionComp.versionNumber;

                if (qVersionNum != pVersionNum)
                {
                    result[0].Add(new GameObjectDifference() { p_UI = p_go, q_UI = q_go });
                }
            }
        }
        return result;
    }

    [MenuItem("ZDGUI/Check UI Version Number", false, 1)]
    static void CheckUIVersionNumber()
    {
        Dictionary<int,List<GameObjectDifference>> result = GetDifference();
        
        string resLog = "";
        if (result[0].Count > 0)
        {
            resLog = "The following is different in version number.\n";
            foreach (var diffRes in result[0])
            {
                resLog += diffRes.p_UI.name + " " + diffRes.q_UI.name + "\n";
            }
        }
        if (result[1].Count > 0)
        {
            resLog += "The following is missing it's Q_UIPrefab.\n";
            foreach (var missingRes in result[1])
            {
                resLog += missingRes.p_UI.name +  "\n";
            }
        }

        if (result[0].Count == 0 && result[1].Count == 0)
        {
            resLog = "Good. No discrepancies found.";
        }

        EditorUtility.DisplayDialog("UI Verion Diff", resLog, "OK");
        Debug.Log(resLog);
    }

    [MenuItem("ZDGUI/Mass Build QPrefab", false, 1)]
    static void MassBuildQPrefab()
    {
        string output = "";
        var oldScene = EditorSceneManager.GetActiveScene().path;
        Dictionary<int, List<GameObjectDifference>> result = GetDifference();
        EditorUtility.DisplayProgressBar("Mass Build QPrefab", "Building", 0);
        for (int iter = 0; iter < result[0].Count; ++iter)
        {
            string path = Application.dataPath.Substring(0,Application.dataPath.IndexOf("Assets")) + "Assets/Scripts/UI/Prefab/" + result[0][iter].q_UI.name + ".unity";

            if (!System.IO.File.Exists(path))
            {
                output += "Unable to Open Scene " + result[0][iter].q_UI.name + "\n";
                continue;
            }

            var scene = EditorSceneManager.OpenScene(path);
            
            var go = GameObject.FindObjectOfType<UI_VersionNumber>();
            if (go != null)
            {
                UIEditorTools.Create_QUI_Prefab(go.gameObject);
                output += "Q prefab made successfully " + result[0][iter].q_UI.name + "\n";
            }
            else
            {
                output += "Unable to Find Object with UI_VersionNumber " + result[0][iter].q_UI.name + "\n";
            }

            EditorUtility.DisplayProgressBar("Mass Build QPrefab", "Building", iter / result[0].Count);

        }
        EditorSceneManager.OpenScene(oldScene);
        EditorUtility.ClearProgressBar();
        foreach (var obj in result[1])
        {
            output += "Unable to Find Scene " + obj.p_UI.name + "\n";
        }
        Debug.Log(output);
    }

    [MenuItem("ZDGUI/Open Diff Window", false, 1)]
    static void OpenDiffWindow()
    {
        UIVersionNumberDiff_EditorWindow window = (UIVersionNumberDiff_EditorWindow)EditorWindow.GetWindow<UIVersionNumberDiff_EditorWindow>();
        window.diff = GetDifference();
        window.ShowPopup();
    }

    
}

public class UIVersionNumberDiff_EditorWindow : EditorWindow
{
    public Dictionary<int, List<ZDGUIContextMenu.GameObjectDifference>> diff;
    void OnGUI()
    {
        foreach (var entry in diff[0])
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(entry.p_UI.name);
            if (GUILayout.Button(entry.q_UI.name))
            {
                string path = "Assets/Scripts/UI/Prefab/" + entry.q_UI.name + ".unity";
                EditorSceneManager.OpenScene(path);
            }
            EditorGUILayout.EndHorizontal();
        }
        foreach (var entry in diff[1])
        {
            EditorGUILayout.BeginHorizontal();
            //GUILayout.Label(entry.p_UI.name);
            if (GUILayout.Button(entry.p_UI.name))
            {
                string path = "Assets/Scripts/UI/Prefab/Q_" + entry.p_UI.name + ".unity";
                EditorSceneManager.OpenScene(path);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}

public class LocalisationSwitch
{
    static string workingTexturesFolder = "Assets/UI/Textures/Localized";
    static string SCTexturesFolder = "Assets/UI/Textures/LocalizedxSC";
    static string TCTexturesFolder = "Assets/UI/Textures/LocalizedxTC";

    static string workingIconsFolder = "Assets/UI/Icons";
    static string SCIconsFolder = "Assets/UI/Icons_SC";
    static string TCIconsFolder = "Assets/UI/Icons_TC";

    static string workingLoginFolder = "Assets/UI/Scenes/Login/P_Login";
    static string SCLoginFolder = "Assets/UI/Scenes/Login/SC_Login";
    static string TCLoginFolder = "Assets/UI/Scenes/Login/TC_Login";

    [MenuItem("ZDGUI/Localisation/Traditional Chinese", false, 1)]
    static void TraditionalChinese()
    {
        ReplaceDirectory(TCTexturesFolder, workingTexturesFolder);
        ReplaceDirectory(TCIconsFolder, workingIconsFolder);
        ReplaceDirectory(TCLoginFolder, workingLoginFolder);        
    }

    [MenuItem("ZDGUI/Localisation/Simplified Chinese", false, 1)]
    static void SimplifiedChinese()
    {
        ReplaceDirectory(SCTexturesFolder, workingTexturesFolder);
        ReplaceDirectory(SCIconsFolder, workingIconsFolder);
        ReplaceDirectory(SCLoginFolder, workingLoginFolder);
    }

    static void ReplaceDirectory(string src, string dst, string ignore = ".meta")
    {
        var dirinfo = new DirectoryInfo(src);
        var directories = dirinfo.GetDirectories();

        foreach (var dir in directories)
        {
            ReplaceDirectory(src + '/' + dir.Name, dst + '/' + dir.Name, ignore);
        }

        var files = dirinfo.GetFiles();

        foreach (var file in files)
        {
            if (file.Name.EndsWith(ignore))
                continue;

            FileUtil.ReplaceFile(src + '/' + file.Name, dst + '/' + file.Name);
        }
    }
};