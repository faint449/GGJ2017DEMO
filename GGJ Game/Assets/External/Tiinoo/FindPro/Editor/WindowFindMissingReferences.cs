using System;
using System.Collections.Generic;
using System.IO;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class WindowFindMissingReferences : EditorWindow
	{
		private static string[] STR_TYPES = new string[]
		{
			"Project View",
			"Hierarchy View"
		};

		private static string[] STR_FILTERS = new string[]
		{
			"All",
			"Script"
		};

		private static float LABEL_WIDTH = 100f;

		private static float BUTTON_WIDTH = 100f;

		private bool m_includeMissing = true;

		private bool m_includeNull;

		private int m_typeIndex;

		private int m_filterIndex = 1;

		private SearchResultTabMgr m_tabMgr;

		private TnToggleButton m_btnShowHide;

		private TnEditorFolderList m_folderList;

		private TnEditorGameObjectList m_gameObjectList;

		private SearchMissingInFolderListJob m_job1;

		private SearchMissingInGameObjectListJob m_job2;

		private void OnEnable()
		{
			this.m_tabMgr = FindProFactory.CreateTabMgr();
			SearchResultTab tab = this.m_tabMgr.GetTab(SearchResultTabType.ResultsInFolder);
			tab.Drawer.SetDetailsButton(new Action<SearchResultDrawer, List<GameObject>>(this.ClickDetailsButton));
			this.m_btnShowHide = FindProFactory.CreateShowHideButton();
			this.m_folderList = FindProFactory.CreateFolderList();
			this.m_gameObjectList = FindProFactory.CreateGameObjectList();
			this.StartListenTaskEvents();
		}

		private void OnDisable()
		{
			this.StopListenTaskEvents();
		}

		private void OnGUI()
		{
			this.DrawSearchDialog();
			TnEditorGUIUtil.DrawSeparator();
			this.DrawSearchResults();
		}

		private void ClickDetailsButton(SearchResultDrawer drawer, List<GameObject> prefabs)
		{
			if (prefabs.Count > 0)
			{
				this.SearchInHierarchy(prefabs);
			}
		}

		private void DrawSearchDialog()
		{
			GUILayout.Label("Find missing references and/or null references.", new GUILayoutOption[0]);
			TnEditorGUIUtil.DrawSeparator();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Find:", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindMissingReferences.LABEL_WIDTH)
			});
			this.m_includeMissing = GUILayout.Toggle(this.m_includeMissing, "Missing References", new GUILayoutOption[]
			{
				GUILayout.Width(150f)
			});
			this.m_includeNull = GUILayout.Toggle(this.m_includeNull, "Null References", new GUILayoutOption[]
			{
				GUILayout.Width(150f)
			});
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Look in:", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindMissingReferences.LABEL_WIDTH)
			});
			this.m_typeIndex = GUILayout.Toolbar(this.m_typeIndex, WindowFindMissingReferences.STR_TYPES, EditorStyles.radioButton, new GUILayoutOption[]
			{
				GUILayout.Width(210f)
			});
			GUILayout.EndHorizontal();
			if (this.m_typeIndex == 0)
			{
				this.m_folderList.Draw();
			}
			else if (this.m_typeIndex == 1)
			{
				this.m_gameObjectList.Draw();
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Filter:", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindMissingReferences.LABEL_WIDTH)
			});
			this.m_filterIndex = GUILayout.Toolbar(this.m_filterIndex, WindowFindMissingReferences.STR_FILTERS, EditorStyles.radioButton, new GUILayoutOption[]
			{
				GUILayout.Width(210f)
			});
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			bool flag = TnGUIUtil.Button(TnColor.lightskyblue, ButtonColorMode.Background, "Search", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindMissingReferences.BUTTON_WIDTH)
			});
			GUILayout.EndHorizontal();
			if (flag)
			{
				if (!this.m_includeMissing && !this.m_includeNull)
				{
					EditorUtility.DisplayDialog("Warning", "You should select \"Missing References\" or \"Null References\"", "OK");
					return;
				}
				if (this.m_typeIndex == 0)
				{
					List<string> folders = this.m_folderList.GetFolders();
					if (folders.Count == 0)
					{
						FindProFactory.PopUpDialog_NoFolderSelected();
						return;
					}
					this.CreateJob1();
					return;
				}
				else if (this.m_typeIndex == 1)
				{
					List<GameObject> gameObjects = this.m_gameObjectList.GetGameObjects();
					if (gameObjects.Count == 0)
					{
						FindProFactory.PopUpDialog_NoHierarchyRootGameObjects();
						return;
					}
					this.CreateJob2();
				}
			}
		}

		private void DrawSearchResults()
		{
			if (this.m_btnShowHide.StateIndex == 0)
			{
				int num = (this.m_typeIndex == 0) ? this.m_folderList.SCROLL_VIEW_HEIGHT : this.m_gameObjectList.SCROLL_VIEW_HEIGHT;
				this.m_tabMgr.Draw(138 + num);
			}
		}

		private void DisplaySearchFinishedDialog(int resultCount)
		{
			EditorUtility.DisplayDialog("Search Finished!", "Find: " + resultCount, "OK");
		}

		private void Update()
		{
			this.ProcessJob1();
			this.ProcessJob2();
		}

		private void StartListenTaskEvents()
		{
			TnTaskNotifier.onTaskBegin += new Action<TnAbstractTask>(this.HandleOnTaskBegin);
			TnTaskNotifier.onTaskProcess += new Action<TnAbstractTask>(this.HandleOnTaskProcess);
			TnTaskNotifier.onTaskFinish += new Action<TnAbstractTask>(this.HandleOnTaskFinish);
		}

		private void StopListenTaskEvents()
		{
			TnTaskNotifier.onTaskBegin -= new Action<TnAbstractTask>(this.HandleOnTaskBegin);
			TnTaskNotifier.onTaskProcess -= new Action<TnAbstractTask>(this.HandleOnTaskProcess);
			TnTaskNotifier.onTaskFinish -= new Action<TnAbstractTask>(this.HandleOnTaskFinish);
		}

		private void HandleOnTaskBegin(TnAbstractTask task)
		{
			Type type = task.GetType();
			if (type == typeof(SearchMissingInPrefabTask))
			{
				this.UpdateSearchProgress(this.m_job1);
				return;
			}
			if (type == typeof(SearchMissingInGameObjectTask))
			{
				this.UpdateSearchProgress(this.m_job2);
			}
		}

		private void HandleOnTaskProcess(TnAbstractTask task)
		{
			Type type = task.GetType();
			if (type == typeof(SearchMissingInPrefabTask))
			{
				SearchMissingInPrefabTask searchMissingInPrefabTask = task as SearchMissingInPrefabTask;
				this.ProcessSearchInPrefab(searchMissingInPrefabTask.FilePath);
				return;
			}
			if (type == typeof(SearchMissingInGameObjectTask))
			{
				SearchMissingInGameObjectTask searchMissingInGameObjectTask = task as SearchMissingInGameObjectTask;
				this.ProcessSearchInGameObject(searchMissingInGameObjectTask.Go);
			}
		}

		private void HandleOnTaskFinish(TnAbstractTask task)
		{
			Type type = task.GetType();
			if (type == typeof(SearchMissingInFolderListJob))
			{
				this.HandleOnJob1Finish();
				return;
			}
			if (type == typeof(SearchMissingInGameObjectListJob))
			{
				this.HandleOnJob2Finish();
			}
		}

		private void CreateJob1()
		{
			this.m_job1 = new SearchMissingInFolderListJob(this.m_folderList);
			this.m_job1.Init();
		}

		private void ProcessJob1()
		{
			if (this.m_job1 == null)
			{
				return;
			}
			this.m_job1.Process();
		}

		private void HandleOnJob1Finish()
		{
			if (this.m_job1 == null)
			{
				return;
			}
			List<SearchResult> results = this.m_job1.GetResults();
			this.m_tabMgr.ShowTab(SearchResultTabType.ResultsInFolder, results);
			this.DisplaySearchFinishedDialog(results.Count);
			EditorUtility.ClearProgressBar();
			base.Repaint();
			this.m_job1 = null;
		}

		private void ProcessSearchInPrefab(string prefabPath)
		{
			if (this.m_job1 == null)
			{
				return;
			}
			this.SearchInPrefab(prefabPath, this.m_job1.GetResults());
		}

		private void UpdateSearchProgress(SearchMissingInFolderListJob job1)
		{
			if (job1 == null)
			{
				return;
			}
			SearchMissingInFolderJob searchMissingInFolderJob = job1.Current() as SearchMissingInFolderJob;
			string folderPath = searchMissingInFolderJob.FolderPath;
			int num = searchMissingInFolderJob.TaskCount();
			int num2 = searchMissingInFolderJob.CurrentIndex();
			SearchMissingInPrefabTask searchMissingInPrefabTask = searchMissingInFolderJob.Current() as SearchMissingInPrefabTask;
			string filePath = searchMissingInPrefabTask.FilePath;
			string fileName = Path.GetFileName(filePath);
			bool flag = EditorUtility.DisplayCancelableProgressBar("Searching: " + folderPath, "Search in: " + fileName, (float)(num2 + 1) / (float)num);
			if (flag)
			{
				job1.SetFinished();
			}
		}

		private void CreateJob2()
		{
			this.m_job2 = new SearchMissingInGameObjectListJob(this.m_gameObjectList);
			this.m_job2.Init();
		}

		private void ProcessJob2()
		{
			if (this.m_job2 == null)
			{
				return;
			}
			this.m_job2.Process();
		}

		private void HandleOnJob2Finish()
		{
			if (this.m_job2 == null)
			{
				return;
			}
			List<GameObject> missingComponents = this.m_job2.GetMissingComponents();
			List<SerializedProperty> missingProperties = this.m_job2.GetMissingProperties();
			List<SearchResult> list = new List<SearchResult>();
			foreach (GameObject current in missingComponents)
			{
				list.Add(new SearchResult
				{
					iid = current.GetInstanceID(),
					path = TnTransformUtil.GetHierarchyFullPath(current)
				});
			}
			foreach (SerializedProperty current2 in missingProperties)
			{
				SearchResult item = SearchResult.Create(current2);
				list.Add(item);
			}
			this.m_tabMgr.ShowTab(SearchResultTabType.ResultsInGameObject, list);
			this.DisplaySearchFinishedDialog(list.Count);
			EditorUtility.ClearProgressBar();
			base.Repaint();
			this.m_job2 = null;
		}

		private void ProcessSearchInGameObject(GameObject go)
		{
			if (this.m_job2 == null)
			{
				return;
			}
			List<GameObject> missingComponents = this.m_job2.GetMissingComponents();
			List<SerializedProperty> missingProperties = this.m_job2.GetMissingProperties();
			this.FindMissingReferencesRecursively(go, true, missingComponents, missingProperties);
		}

		private void UpdateSearchProgress(SearchMissingInGameObjectListJob job)
		{
			if (job == null)
			{
				return;
			}
			int num = job.TaskCount();
			int num2 = job.CurrentIndex();
			SearchMissingInGameObjectTask searchMissingInGameObjectTask = job.Current() as SearchMissingInGameObjectTask;
			GameObject go = searchMissingInGameObjectTask.Go;
			bool flag = EditorUtility.DisplayCancelableProgressBar("Searching", "Search in: " + go.name, (float)(num2 + 1) / (float)num);
			if (flag)
			{
				job.SetFinished();
			}
		}

		private void SearchInFolders(List<string> folderPaths)
		{
			List<SearchResult> list = new List<SearchResult>();
			foreach (string current in folderPaths)
			{
				List<SearchResult> collection = this.SearchInFolder(current);
				list.AddRange(collection);
			}
			this.m_tabMgr.ShowTab(SearchResultTabType.ResultsInFolder, list);
			this.DisplaySearchFinishedDialog(list.Count);
		}

		public List<SearchResult> SearchInFolder(string folderPath)
		{
			List<SearchResult> list = new List<SearchResult>();
			if (!this.m_folderList.CheckFolder(folderPath, false))
			{
				return list;
			}
			List<string> filePaths = TnEditorFileUtil.GetFilePaths(folderPath, "*.*", SearchOption.AllDirectories, ".meta", true);
			for (int i = 0; i < filePaths.Count; i++)
			{
				string fileName = Path.GetFileName(filePaths[i]);
				if (EditorUtility.DisplayCancelableProgressBar("Searching", "Search in: " + fileName, (float)(i + 1) / (float)filePaths.Count))
				{
					break;
				}
				this.SearchInPrefab(filePaths[i], list);
			}
			EditorUtility.ClearProgressBar();
			return list;
		}

		private bool SearchInPrefab(string prefabPath, List<SearchResult> results)
		{
			GameObject gameObject = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
			if (gameObject == null)
			{
				return false;
			}
			List<SerializedProperty> list = new List<SerializedProperty>();
			List<GameObject> list2 = new List<GameObject>();
			this.FindMissingReferencesRecursively(gameObject, false, list2, list);
			bool flag = false;
			if (list2.Count > 0 || list.Count > 0)
			{
				flag = true;
			}
			if (flag)
			{
				results.Add(new SearchResult
				{
					iid = gameObject.GetInstanceID(),
					path = TnFileUtil.UnifyFilePath(prefabPath)
				});
			}
			return flag;
		}

		public void SearchInHierarchy(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			this.SearchInHierarchy(new List<GameObject>
			{
				go
			});
		}

		public void SearchInHierarchy(List<GameObject> gos)
		{
			List<GameObject> list = new List<GameObject>();
			List<SerializedProperty> list2 = new List<SerializedProperty>();
			for (int i = 0; i < gos.Count; i++)
			{
				GameObject gameObject = gos[i];
				if (this.m_gameObjectList.CheckGameObject(gameObject, false))
				{
					if (EditorUtility.DisplayCancelableProgressBar("Searching", "Search in: " + gameObject.name, (float)(i + 1) / (float)gos.Count))
					{
						break;
					}
					this.FindMissingReferencesRecursively(gameObject, true, list, list2);
				}
			}
			EditorUtility.ClearProgressBar();
			List<SearchResult> list3 = new List<SearchResult>();
			foreach (GameObject current in list)
			{
				list3.Add(new SearchResult
				{
					iid = current.GetInstanceID(),
					path = TnTransformUtil.GetHierarchyFullPath(current)
				});
			}
			foreach (SerializedProperty current2 in list2)
			{
				SearchResult item = SearchResult.Create(current2);
				list3.Add(item);
			}
			this.m_tabMgr.ShowTab(SearchResultTabType.ResultsInGameObject, list3);
			this.DisplaySearchFinishedDialog(list3.Count);
		}

		private bool FindMissingReferencesRecursively(GameObject go, bool findAll, List<GameObject> out_missingComponents, List<SerializedProperty> out_missingProperties)
		{
			if (go == null)
			{
				return false;
			}
			bool result = false;
			bool flag = this.FindMissingReferences(go, out_missingComponents, out_missingProperties);
			if (flag)
			{
				result = true;
				if (!findAll)
				{
					return true;
				}
			}
			Transform transform = go.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				bool flag2 = this.FindMissingReferencesRecursively(gameObject, findAll, out_missingComponents, out_missingProperties);
				if (flag2)
				{
					result = true;
					if (!findAll)
					{
						return true;
					}
				}
			}
			return result;
		}

		private bool FindMissingReferences(GameObject go, List<GameObject> out_missingComponents, List<SerializedProperty> out_missingProperties)
		{
			bool result = false;
			Component[] components = go.GetComponents<Component>();
			Component[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				Component component = array[i];
				if (component == null)
				{
					if (out_missingComponents != null)
					{
						out_missingComponents.Add(go);
					}
					result = true;
				}
				else if (this.m_filterIndex != 1 && this.FindMissingProperties(component, out_missingProperties))
				{
					result = true;
				}
			}
			return result;
		}

		private bool FindMissingProperties(Component c, List<SerializedProperty> out_missingProperties)
		{
			bool result = false;
			SerializedObject serializedObject = new SerializedObject(c);
			SerializedProperty iterator = serializedObject.GetIterator();
			while (iterator.NextVisible(true))
			{
				if ((int)iterator.propertyType == 5 && iterator.objectReferenceValue == null && ((this.m_includeMissing && iterator.objectReferenceInstanceIDValue != 0) || (this.m_includeNull && iterator.objectReferenceInstanceIDValue == 0)))
				{
					if (out_missingProperties != null)
					{
						SerializedProperty item = iterator.Copy();
						out_missingProperties.Add(item);
					}
					result = true;
				}
			}
			return result;
		}
	}
}
