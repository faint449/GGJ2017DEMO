using System;
using System.Collections.Generic;
using System.IO;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class WindowFindAssetReferences : EditorWindow
	{
		private static string[] STR_TYPES = new string[]
		{
			"Project View",
			"Hierarchy View"
		};

		private static float LABEL_WIDTH = 100f;

		private static float BUTTON_WIDTH = 100f;

		private TargetType m_targetType;

        private SearchType m_searchType;

		private UnityEngine.Object m_target;

		private bool m_isTargetPrefab;

		private List<int> m_targetComponentIID = new List<int>();

		private ValueType m_valueType;

		private int m_intValue;

		private float m_floatValue;

		private float m_decimalTolerance = 0.001f;

		private string m_strValue = "";

		private string m_strValueInternal = "";

		private bool m_isStrValueIgnoreCase = true;

		private string m_enumValue = "";

		private string m_enumValueInternal = "";

		private bool m_isEnumValueIgnoreCase = true;

		private int m_typeIndex;

		private SearchResultTabMgr m_tabMgr;

		private TnToggleButton m_btnShowHide;

		private TnEditorFolderList m_folderList;

		private TnEditorGameObjectList m_gameObjectList;

		private int m_extraLine;

		private SearchObjectInFolderListJob m_job1;

		private SearchObjectInGameObjectListJob m_job2;

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

		private void ClickDetailsButton(SearchResultDrawer drawer, List<GameObject> prefabs)
		{
			if (prefabs.Count > 0)
			{
				this.SearchInHierarchy(prefabs);
			}
		}

		private void OnGUI()
		{
			this.DrawSearchDialog();
			TnEditorGUIUtil.DrawSeparator();
			this.DrawSearchResults();
		}

		private void DrawSearchDialog()
		{
			GUILayout.Label("Find where a particular asset or value is being used.", new GUILayoutOption[0]);
			TnEditorGUIUtil.DrawSeparator();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Target Type:", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
			});
			this.m_targetType = (TargetType)EditorGUILayout.EnumPopup(this.m_targetType, new GUILayoutOption[]
			{
				GUILayout.Width(210f)
			});
            if (this.m_targetType == TargetType.Object)
            {
                GUILayout.Label("(Script, GameObject, Texture, etc)", new GUILayoutOption[0]);
            }
            else if (this.m_targetType == TargetType.Value)
            {
                GUILayout.Label("(Integer, String, Enum, etc)", new GUILayoutOption[0]);
            }
			GUILayout.EndHorizontal();
            if (this.m_targetType == TargetType.Object)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("Target:", new GUILayoutOption[]
				{
					GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
				});
				this.m_target = EditorGUILayout.ObjectField(this.m_target, typeof(UnityEngine.Object), false, new GUILayoutOption[]
				{
					GUILayout.Width(210f)
				});
				bool flag = GUILayout.Button("Select", new GUILayoutOption[]
				{
					GUILayout.Width(WindowFindAssetReferences.BUTTON_WIDTH)
				});
				if (flag)
				{
					UnityEngine.Object activeObject = Selection.activeObject;
					this.SetTarget(activeObject);
				}
				GUILayout.EndHorizontal();
				this.m_extraLine = 1;
			}
			else if (this.m_targetType == TargetType.Value)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("Value Type:", new GUILayoutOption[]
				{
					GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
				});
				this.m_valueType = (ValueType)EditorGUILayout.EnumPopup(this.m_valueType, new GUILayoutOption[]
				{
					GUILayout.Width(210f)
				});
				if (this.m_valueType == ValueType.Float)
				{
					GUILayout.Label("Tolerance:", new GUILayoutOption[]
					{
						GUILayout.Width(70f)
					});
					this.m_decimalTolerance = EditorGUILayout.FloatField(this.m_decimalTolerance, new GUILayoutOption[]
					{
						GUILayout.Width(90f)
					});
				}
				else if (this.m_valueType == ValueType.String)
				{
					this.m_isStrValueIgnoreCase = GUILayout.Toggle(this.m_isStrValueIgnoreCase, "Ignore Case", new GUILayoutOption[]
					{
						GUILayout.Width(WindowFindAssetReferences.BUTTON_WIDTH)
					});
				}
				else if (this.m_valueType == ValueType.Enum)
				{
					this.m_isEnumValueIgnoreCase = GUILayout.Toggle(this.m_isEnumValueIgnoreCase, "Ignore Case", new GUILayoutOption[]
					{
						GUILayout.Width(WindowFindAssetReferences.BUTTON_WIDTH)
					});
				}
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("Value:", new GUILayoutOption[]
				{
					GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
				});
				if (this.m_valueType == ValueType.Integer)
				{
					this.m_intValue = EditorGUILayout.IntField(this.m_intValue, new GUILayoutOption[]
					{
						GUILayout.Width(210f)
					});
				}
				else if (this.m_valueType == ValueType.Float)
				{
					this.m_floatValue = EditorGUILayout.FloatField(this.m_floatValue, new GUILayoutOption[]
					{
						GUILayout.Width(210f)
					});
				}
				else if (this.m_valueType == ValueType.String)
				{
					this.m_strValue = GUILayout.TextField(this.m_strValue, new GUILayoutOption[]
					{
						GUILayout.Width(210f)
					});
				}
				else if (this.m_valueType == ValueType.Enum)
				{
					this.m_enumValue = GUILayout.TextField(this.m_enumValue, new GUILayoutOption[]
					{
						GUILayout.Width(210f)
					});
				}
				GUILayout.EndHorizontal();
				this.m_extraLine = 2;
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Look in:", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
			});
			this.m_typeIndex = GUILayout.Toolbar(this.m_typeIndex, WindowFindAssetReferences.STR_TYPES, EditorStyles.radioButton, new GUILayoutOption[]
			{
				GUILayout.Width(210f)
			});
            if (this.m_typeIndex == 0)
            {
                GUILayout.Label("Search Type:", new GUILayoutOption[]
                {
                    GUILayout.Width(WindowFindAssetReferences.LABEL_WIDTH)
                });
                this.m_searchType = (SearchType)EditorGUILayout.EnumPopup(this.m_searchType, new GUILayoutOption[]
                {
                    GUILayout.Width(210f)
                });
            }
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
			bool flag2 = TnGUIUtil.Button(TnColor.lightskyblue, ButtonColorMode.Background, "Search", new GUILayoutOption[]
			{
				GUILayout.Width(WindowFindAssetReferences.BUTTON_WIDTH)
			});
			GUILayout.EndHorizontal();
			if (flag2)
			{
				if (this.m_targetType == TargetType.Object)
				{
					if (!WindowFindAssetReferences.CheckTarget(this.m_target, true))
					{
						return;
					}
					this.m_isTargetPrefab = TnEditorPrefabUtil.IsPrefab(this.m_target);
					this.m_targetComponentIID.Clear();
					GameObject gameObject = this.m_target as GameObject;
					if (gameObject != null)
					{
						Component[] components = gameObject.GetComponents(typeof(Component));
						Component[] array = components;
						for (int i = 0; i < array.Length; i++)
						{
							Component component = array[i];
							int instanceID = component.GetInstanceID();
							this.m_targetComponentIID.Add(instanceID);
						}
					}
				}
				else if (this.m_targetType == TargetType.Value)
				{
					if (!this.CheckValue(true))
					{
						return;
					}
					if (this.m_valueType == ValueType.String)
					{
						this.m_strValueInternal = this.m_strValue;
						if (this.m_isStrValueIgnoreCase)
						{
							this.m_strValueInternal = this.m_strValue.ToLower();
						}
					}
					else if (this.m_valueType == ValueType.Enum)
					{
						this.m_enumValueInternal = this.m_enumValue;
						if (this.m_isEnumValueIgnoreCase)
						{
							this.m_enumValueInternal = this.m_enumValue.ToLower();
						}
					}
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
				this.m_tabMgr.Draw(116 + this.m_extraLine * 22 + num);
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

		public void SetTarget(UnityEngine.Object target)
		{
			if (!WindowFindAssetReferences.CheckTarget(target, true))
			{
				return;
			}
			this.m_target = target;
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
            if (task is SearchObjectTask)
			{
				this.UpdateSearchProgress(this.m_job1);
				return;
			}
			if (task is SearchObjectInGameObjectTask)
			{
				this.UpdateSearchProgress(this.m_job2);
			}
		}

		private void HandleOnTaskProcess(TnAbstractTask task)
		{
			Type type = task.GetType();
			if (type == typeof(SearchObjectInPrefabTask))
			{
				SearchObjectInPrefabTask searchObjectInPrefabTask = task as SearchObjectInPrefabTask;
				this.ProcessSearchInPrefab(searchObjectInPrefabTask.FilePath);
			}
            else if (type == typeof(SearchObjectInMaterialTask))
            {
                SearchObjectInMaterialTask searchObjectInMaterialTask = task as SearchObjectInMaterialTask;
                this.ProcessSearchInMaterial(searchObjectInMaterialTask.FilePath);
            }
			else if (type == typeof(SearchObjectInGameObjectTask))
			{
				SearchObjectInGameObjectTask searchObjectInGameObjectTask = task as SearchObjectInGameObjectTask;
				this.ProcessSearchInGameObject(searchObjectInGameObjectTask.Go);
			}
		}

		private void HandleOnTaskFinish(TnAbstractTask task)
		{
			Type type = task.GetType();
			if (type == typeof(SearchObjectInFolderListJob))
			{
				this.HandleOnJob1Finish();
				return;
			}
			if (type == typeof(SearchObjectInGameObjectListJob))
			{
				this.HandleOnJob2Finish();
			}
		}

		private void CreateJob1()
		{
			this.m_job1 = new SearchObjectInFolderListJob(this.m_folderList, this.m_searchType);
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

        private void ProcessSearchInMaterial(string materialPath)
        {
            if (this.m_job1 == null)
            {
                return;
            }
            this.SearchInMaterial(materialPath, this.m_job1.GetResults());
        }

        private void UpdateSearchProgress(SearchObjectInFolderListJob job1)
		{
			if (job1 == null)
			{
				return;
			}
			SearchObjectInFolderJob searchObjectInFolderJob = job1.Current() as SearchObjectInFolderJob;
			string folderPath = searchObjectInFolderJob.FolderPath;
			int num = searchObjectInFolderJob.TaskCount();
			int num2 = searchObjectInFolderJob.CurrentIndex();
			SearchObjectTask searchObjectInPrefabTask = searchObjectInFolderJob.Current() as SearchObjectTask;
			string filePath = searchObjectInPrefabTask.FilePath;
			string fileName = Path.GetFileName(filePath);
			bool flag = EditorUtility.DisplayCancelableProgressBar("Searching: " + folderPath, "Search in: " + fileName, (float)(num2 + 1) / (float)num);
			if (flag)
			{
				job1.SetFinished();
			}
		}

		private void CreateJob2()
		{
			this.m_job2 = new SearchObjectInGameObjectListJob(this.m_gameObjectList);
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
			List<SerializedProperty> properties = this.m_job2.GetProperties();
			List<GameObject> prefabInsts = this.m_job2.GetPrefabInsts();
			List<SearchResult> list = new List<SearchResult>();
			foreach (SerializedProperty current in properties)
			{
				SearchResult item = SearchResult.Create(current);
				list.Add(item);
			}
			foreach (GameObject current2 in prefabInsts)
			{
				list.Add(new SearchResult
				{
					iid = current2.GetInstanceID(),
					path = TnTransformUtil.GetHierarchyFullPath(current2)
				});
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
			List<SerializedProperty> properties = this.m_job2.GetProperties();
			List<GameObject> prefabInsts = this.m_job2.GetPrefabInsts();
			this.FindTargetRecursively(go, true, properties, prefabInsts);
		}

		private void UpdateSearchProgress(SearchObjectInGameObjectListJob job)
		{
			if (job == null)
			{
				return;
			}
			int num = job.TaskCount();
			int num2 = job.CurrentIndex();
			SearchObjectInGameObjectTask searchObjectInGameObjectTask = job.Current() as SearchObjectInGameObjectTask;
			GameObject go = searchObjectInGameObjectTask.Go;
			bool flag = EditorUtility.DisplayCancelableProgressBar("Searching", "Search in: " + go.name, (float)(num2 + 1) / (float)num);
			if (flag)
			{
				job.SetFinished();
			}
		}

        private bool SearchInPrefab(string prefabPath, List<SearchResult> results)
		{
			GameObject gameObject = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
			if (gameObject == null)
			{
				return false;
			}
			List<SerializedProperty> out_properties = new List<SerializedProperty>();
			List<GameObject> out_prefabInsts = new List<GameObject>();
			bool flag = this.FindTargetRecursively(gameObject, false, out_properties, out_prefabInsts);
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

        private bool SearchInMaterial(string materialPath, List<SearchResult> results)
        {
            Material material = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
            if (material == null)
            {
                return false;
            }
            List<SerializedProperty> out_properties = new List<SerializedProperty>();
            bool flag = this.FindTarget(material, out_properties);
            if (flag)
            {
                results.Add(new SearchResult
                {
                    iid = material.GetInstanceID(),
                    path = TnFileUtil.UnifyFilePath(materialPath)
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
			List<SerializedProperty> list = new List<SerializedProperty>();
			List<GameObject> list2 = new List<GameObject>();
			for (int i = 0; i < gos.Count; i++)
			{
				GameObject gameObject = gos[i];
				if (this.m_gameObjectList.CheckGameObject(gameObject, false))
				{
					if (EditorUtility.DisplayCancelableProgressBar("Searching", "Search in: " + gameObject.name, (float)(i + 1) / (float)gos.Count))
					{
						break;
					}
					this.FindTargetRecursively(gameObject, true, list, list2);
				}
			}
			EditorUtility.ClearProgressBar();
			List<SearchResult> list3 = new List<SearchResult>();
			foreach (SerializedProperty current in list)
			{
				SearchResult item = SearchResult.Create(current);
				list3.Add(item);
			}
			foreach (GameObject current2 in list2)
			{
				list3.Add(new SearchResult
				{
					iid = current2.GetInstanceID(),
					path = TnTransformUtil.GetHierarchyFullPath(current2)
				});
			}
			this.m_tabMgr.ShowTab(SearchResultTabType.ResultsInGameObject, list3);
			this.DisplaySearchFinishedDialog(list3.Count);
		}

		private bool FindTargetRecursively(GameObject go, bool findAll, List<SerializedProperty> out_properties, List<GameObject> out_prefabInsts)
		{
			if (go == null)
			{
				return false;
			}
			bool result = false;
			bool flag = this.FindTarget(go, out_properties, out_prefabInsts);
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
				bool flag2 = this.FindTargetRecursively(gameObject, findAll, out_properties, out_prefabInsts);
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

        private bool FindTarget(GameObject go, List<SerializedProperty> out_properties, List<GameObject> out_prefabInsts)
		{
			if (this.m_targetType == TargetType.Object)
			{
				if (this.m_target == go)
				{
					out_prefabInsts.Add(go);
					return true;
				}
				if (this.m_isTargetPrefab)
				{
                    bool flag = TnEditorPrefabUtil.IsPrefabInstance(this.m_target, go);
                    if (flag)
					{
						out_prefabInsts.Add(go);
						return true;
					}
				}
			}
			bool result = false;
			Component[] components = go.GetComponents<Component>();
			Component[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				Component component = array[i];
				if (!(component == null) && this.FindTarget(component, out_properties))
				{
					result = true;
				}
			}
			return result;
		}

        private bool FindTarget(UnityEngine.Object c, List<SerializedProperty> out_properties)
        {
			bool result = false;
            SerializedObject serializedObject = new SerializedObject(c);
            SerializedProperty iterator = serializedObject.GetIterator();
            int num = 0;
            while (iterator.NextVisible(true))
            {
                if (this.m_targetType == TargetType.Object)
                {
                    if (num == 0)
                    {
                        num = this.m_target.GetInstanceID();
                    }
                    if (iterator.propertyType == SerializedPropertyType.ObjectReference && iterator.objectReferenceValue != null)
                    {
                        if (iterator.objectReferenceInstanceIDValue == num)
                        {
                            if (out_properties != null)
                            {
                                SerializedProperty item = iterator.Copy();
                                out_properties.Add(item);
                            }
                            result = true;
                        }
                        else
                        {
                            int count = this.m_targetComponentIID.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (this.m_targetComponentIID[i] == iterator.objectReferenceInstanceIDValue)
                                {
                                    if (out_properties != null)
                                    {
                                        SerializedProperty item2 = iterator.Copy();
                                        out_properties.Add(item2);
                                    }
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (this.m_targetType == TargetType.Value)
                {
                    if (this.m_valueType == ValueType.Integer)
                    {
                        if (iterator.intValue == this.m_intValue)
                        {
                            if (out_properties != null)
                            {
                                SerializedProperty item3 = iterator.Copy();
                                out_properties.Add(item3);
                            }
                            result = true;
                        }
                    }
                    else if (this.m_valueType == ValueType.Float)
                    {
                        if ((int)iterator.propertyType == 2 && Mathf.Abs(iterator.floatValue - this.m_floatValue) <= this.m_decimalTolerance)
                        {
                            if (out_properties != null)
                            {
                                SerializedProperty item4 = iterator.Copy();
                                out_properties.Add(item4);
                            }
                            result = true;
                        }
                    }
                    else if (this.m_valueType == ValueType.String)
                    {
                        if ((int)iterator.propertyType == 3 && !string.IsNullOrEmpty(iterator.stringValue))
                        {
                            string text = iterator.stringValue;
                            if (this.m_isStrValueIgnoreCase)
                            {
                                text = iterator.stringValue.ToLower();
                            }
                            if (text.Contains(this.m_strValueInternal))
                            {
                                if (out_properties != null)
                                {
                                    SerializedProperty item5 = iterator.Copy();
                                    out_properties.Add(item5);
                                }
                                result = true;
                            }
                        }
                    }
                    else if (this.m_valueType == ValueType.Enum && (int)iterator.propertyType == 7)
                    {
                        string text2 = iterator.enumNames[iterator.enumValueIndex];
                        if (!string.IsNullOrEmpty(text2))
                        {
                            string text3 = text2;
                            if (this.m_isEnumValueIgnoreCase)
                            {
                                text3 = text2.ToLower();
                            }
                            if (text3.Contains(this.m_enumValueInternal))
                            {
                                if (out_properties != null)
                                {
                                    SerializedProperty item6 = iterator.Copy();
                                    out_properties.Add(item6);
                                }
                                result = true;
                            }
                        }
                    }
                }
            }
			return result;
		}

        public static bool CheckTarget(UnityEngine.Object target, bool promptIfInvalid)
		{
			bool flag = true;
			if (target == null)
			{
				flag = false;
			}
			if (!flag && promptIfInvalid)
			{
				EditorUtility.DisplayDialog("Warning", "You should set target!", "OK");
			}
			return flag;
		}

		public bool CheckValue(bool promptIfInvalid)
		{
			bool flag = true;
			if (this.m_valueType != ValueType.Integer && this.m_valueType != ValueType.Float)
			{
				if (this.m_valueType == ValueType.String)
				{
					if (string.IsNullOrEmpty(this.m_strValue))
					{
						flag = false;
					}
					if (!flag && promptIfInvalid)
					{
						EditorUtility.DisplayDialog("Warning", "You should set a valid string value!", "OK");
					}
				}
				else if (this.m_valueType == ValueType.Enum)
				{
					if (string.IsNullOrEmpty(this.m_enumValue))
					{
						flag = false;
					}
					if (!flag && promptIfInvalid)
					{
						EditorUtility.DisplayDialog("Warning", "You should set a valid enum value!", "OK");
					}
				}
			}
			return flag;
		}
	}
}
