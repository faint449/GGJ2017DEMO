using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
//using System.Collections;

public class ZDGUITopMenu : EditorWindow
{
    // %(Ctrl), #(Shift), &(Alt), _(None)

    [MenuItem("ZDGUI/SaveAsset (Really Save modified changes) &S", false, -99)]
    static void SaveAsset()
    {
        EditorApplication.SaveAssets();
        Debug.LogWarningFormat("<b>Asset Saved</b>");
    }

    [MenuItem("ZDGUI/Toggle Active &A", false, -98)]
    static void ToggleActivate()
    {
        if (Selection.activeGameObject.activeSelf)
        {
            Selection.activeGameObject.SetActive(false);
        }
        else
        {
            Selection.activeGameObject.SetActive(true);
        }
    }

    [MenuItem("File/Mark Scene Dirty", false, 9949)]
    static void MarkSceneDirty()
    {
        EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
    }

    [MenuItem("File/Revert Scene", false, 9999)]
    static void RevertScene()
    {
        string myScene = EditorSceneManager.GetActiveScene().path;
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/### UI_Window Template", false, 51)]
    static void NewSceneTemplate()
    {
        string myScene = "Assets/UI/Widgets/UI_WindowTemplate.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/### UI_Window Template (ssCamera)", false, 51)]
    static void NewSceneTemplate_ssCamera()
    {
        string myScene = "Assets/UI/Widgets/UI_WindowTemplate_ssCamera.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/### UI_Dialog Template", false, 51)]
    static void UI_DialogTemplate()
    {
        string myScene = "Assets/UI/Widgets/UI_DialogTemplate.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/Hierarchy", false, 51)]
    static void Hierarchy()
    {
        string myScene = "Assets/UI/Scenes/Hierarchy/Hierarchy.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/MainMenu", false, 51)]
    static void MainMenu()
    {
        string myScene = "Assets/UI/Scenes/Menu/UI_Menu.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/UI_Login_TC", false, 51)]
    static void Login_TC()
    {
        string myScene = "Assets/UI/Scenes/Login/UI_Login_TC.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/UI_Login_SC", false, 51)]
    static void Login_SC()
    {
        string myScene = "Assets/UI/Scenes/Login/UI_Login_SC.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/UI_LoadingScreen", false, 51)]
    static void LoadingScreen()
    {
        string myScene = "Assets/UI/Scenes/LoadingScreen/UI_LoadingScreen.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/GameIcons", false, 51)]
    static void GameIcons()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI/Widgets/GameIcons/root.tif");
    }

    [MenuItem("ZDGUI/PROGRAMMERS PREFAB FOLDER", false, 51)]
    static void ProgrammersP()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Scripts/UI/Prefab/ReadMe.txt");
    }

    [MenuItem("ZDGUI/!!! Open Q version of current UI file (UI_)", false, 101)]
    static void OpenQVersionUI()
    {
        var sc = EditorSceneManager.GetActiveScene();
        string myScene = "Assets/Scripts/UI/Prefab/Q_" + sc.name + ".unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/------> Login (Q)", false, 151)]
    static void LoginQ()
    {
        string myScene = "Assets/Scripts/UI/Scene/Login.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/------> Hierarchy (Q)", false, 151)]
    static void HierarchyQ()
    {
        string myScene = "Assets/Scripts/UI/Scene/Hierarchy/Q_Hierarchy.unity";
        OpenNewScene(myScene);
    }

    [MenuItem("ZDGUI/------> Q_UI_SplashUI", false, 151)]
    static void Q_UI_SplashUI()
    {
        string myScene = "Assets/Scripts/UI/Prefab/Q_UI_Splash.unity";
        OpenNewScene(myScene);
    }


    
    //####################################################################
    // Open Scene with confirmation
    //####################################################################
    //------------------------------------------
    static void OpenNewScene(string myScene)
    {
        var q = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        if (q)
        {
            EditorSceneManager.OpenScene(myScene);
        }
    }

}
