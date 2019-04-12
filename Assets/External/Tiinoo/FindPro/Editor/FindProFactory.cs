using System;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
    public class FindProFactory
    {
        public static void PopUpDialog_NoFolderSelected()
        {
            EditorUtility.DisplayDialog("Warning", "You should select a folder.", "OK");
        }

        public static void PopUpDialog_NoGameObjectSelected()
        {
            EditorUtility.DisplayDialog("Warning", "You should select a game object.", "OK");
        }

        public static void PopUpDialog_NoHierarchyRootGameObjects()
        {
            EditorUtility.DisplayDialog("Warning", "There is no root game objects in hierarchy.", "OK");
        }

        public static void FolderErrorHandler(TnEditorFolderList.ErrorType errorType, string folderPath)
        {
            if (errorType == TnEditorFolderList.ErrorType.Folder_Null)
            {
                EditorUtility.DisplayDialog("Warning", "Folder not exist!", "OK");
                return;
            }
            if (errorType == TnEditorFolderList.ErrorType.Folder_Not_Exist)
            {
                EditorUtility.DisplayDialog("Warning", "Folder not exist: " + folderPath, "OK");
                return;
            }
            if (errorType == TnEditorFolderList.ErrorType.Folder_Count_Zero)
            {
                FindProFactory.PopUpDialog_NoFolderSelected();
            }
        }

        public static void GameObjectErrorHandler(TnEditorGameObjectList.ErrorType errorType, GameObject go)
        {
            if (errorType == TnEditorGameObjectList.ErrorType.GameObject_Null)
            {
                FindProFactory.PopUpDialog_NoGameObjectSelected();
                return;
            }
            if (errorType == TnEditorGameObjectList.ErrorType.GameObject_Count_Zero)
            {
                FindProFactory.PopUpDialog_NoGameObjectSelected();
            }
        }

        public static SearchResultTabMgr CreateTabMgr()
        {
            SearchResultTabMgr searchResultTabMgr = new SearchResultTabMgr();
            SearchResultTab tab = new SearchResultTab(SearchResultTabType.ResultsInFolder, "Results In Project View");
            searchResultTabMgr.AddTab(tab);
            tab = new SearchResultTab(SearchResultTabType.ResultsInGameObject, "Results In Hierarchy View");
            searchResultTabMgr.AddTab(tab);
            searchResultTabMgr.Prepared();
            searchResultTabMgr.SetCurTab(SearchResultTabType.ResultsInFolder);
            return searchResultTabMgr;
        }

        public static TnToggleButton CreateShowHideButton()
        {
            TnToggleButton tnToggleButton = new TnToggleButton();
            tnToggleButton.Init(new string[]
            {
                "Hide Results <<",
                "Show Results >> "
            });
            return tnToggleButton;
        }

        public static TnEditorFolderList CreateFolderList()
        {
            TnEditorFolderList tnEditorFolderList = new TnEditorFolderList();
            tnEditorFolderList.Init(new Action<TnEditorFolderList.ErrorType, string>(FindProFactory.FolderErrorHandler));
            tnEditorFolderList.BUTTON_SPACE_WIDTH = 4;
            tnEditorFolderList.SCROLL_VIEW_HEIGHT = 66;
            return tnEditorFolderList;
        }

        public static TnEditorGameObjectList CreateGameObjectList()
        {
            TnEditorGameObjectList tnEditorGameObjectList = new TnEditorGameObjectList();
            tnEditorGameObjectList.Init(new Action<TnEditorGameObjectList.ErrorType, GameObject>(FindProFactory.GameObjectErrorHandler));
            tnEditorGameObjectList.BUTTON_SPACE_WIDTH = 4;
            tnEditorGameObjectList.SCROLL_VIEW_HEIGHT = 66;
            return tnEditorGameObjectList;
        }
    }
}
