using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchResultDrawer : DataItemMgrDrawer
	{
		private const string STR_PATH = "Path: ";

		private const string STR_GOTO = "Goto";

		private const string STR_SHOULD_SELECT_A_RESULT = "You should select one result at least.";

		private const string STR_SEE_DETAILS_IN_HIERARCHY = "Select and See Details In Hierarchy View";

		private const string STR_SEE_DETAILS_IN_HIERARCHY_WARNING = "This operation will create a duplicate of the object being looked up in the hierarchy. Continue?";

		private Action<SearchResultDrawer, List<GameObject>> m_onDetailsButtonClicked;

		private SearchResultTabType m_tabType;

		public SearchResultDrawer(SearchResultTabType tabType)
		{
			this.m_tabType = tabType;
			DataItemMgr itemMgr = new DataItemMgr();
			base.Init(itemMgr);
		}

		public void SetDetailsButton(Action<SearchResultDrawer, List<GameObject>> onBtnClicked)
		{
			this.m_onDetailsButtonClicked = onBtnClicked;
		}

		public void SetResults(List<SearchResult> results, bool selectAll)
		{
			this.m_itemMgr.ClearAllItems();
			foreach (SearchResult current in results)
			{
				DataItem dataItem = new DataItem();
				dataItem.Data = current;
				dataItem.IsSelected = selectAll;
				this.m_itemMgr.AddItem(dataItem);
			}
		}

		public void SelectResult(int index)
		{
			DataItem item = this.m_itemMgr.GetItem(index);
			if (item != null)
			{
				item.IsSelected = true;
			}
		}

		protected override void DrawEx()
		{
			TnEditorGUIUtil.DrawSeparator();
			if (this.m_tabType == SearchResultTabType.ResultsInFolder)
			{
				this.DrawDetailsButton();
				return;
			}
			SearchResultTabType arg_1D_0 = this.m_tabType;
		}

		protected override void DrawItem(DataItem item, int index)
		{
			GUILayout.Label("Path: ", new GUILayoutOption[]
			{
				this.m_optionTitle
			});
			SearchResult searchResult = (SearchResult)item.Data;
			GUILayout.Label(searchResult.path, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			bool flag = GUILayout.Button("Goto", new GUILayoutOption[]
			{
				this.m_optionButton
			});
			if (flag)
			{
				Selection.activeInstanceID = searchResult.iid;
				base.SelectItem(index);
			}
		}

		private void DrawDetailsButton()
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			bool flag = this.m_itemMgr.GetSelectedItemCount() > 0;
			Color color = flag ? TnColor.green : TnColor.gold;
			bool flag2 = TnGUIUtil.Button(color, ButtonColorMode.Background, "Select and See Details In Hierarchy View", new GUILayoutOption[]
			{
				GUILayout.Width(350f)
			});
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			if (!flag2)
			{
				return;
			}
			if (!flag)
			{
				EditorUtility.DisplayDialog("Warning", "You should select one result at least.", "OK");
				return;
			}
			if (!EditorUtility.DisplayDialog("Warning", "This operation will create a duplicate of the object being looked up in the hierarchy. Continue?", "Yes", "No"))
			{
				return;
			}
			List<GameObject> list = this.CreatePrefabsOfSelectedItems();
			if (list.Count <= 0)
			{
				return;
			}
			Selection.objects = list.ToArray();
			if (this.m_onDetailsButtonClicked != null)
			{
				this.m_onDetailsButtonClicked(this, list);
			}
		}

		private List<GameObject> CreatePrefabsOfSelectedItems()
		{
			List<GameObject> list = new List<GameObject>();
			int itemCount = base.GetItemCount();
			for (int i = 0; i < itemCount; i++)
			{
				DataItem item = this.m_itemMgr.GetItem(i);
				if (item.IsSelected)
				{
					SearchResult searchResult = item.Data as SearchResult;
					if (searchResult.IsMainAsset())
					{
						string assetPath = searchResult.AssetPath;
						GameObject gameObject = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
						if (!(gameObject == null))
						{
							GameObject gameObject2 = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;
							if (gameObject2 != null)
							{
								list.Add(gameObject2);
							}
						}
					}
				}
			}
			return list;
		}
	}
}
