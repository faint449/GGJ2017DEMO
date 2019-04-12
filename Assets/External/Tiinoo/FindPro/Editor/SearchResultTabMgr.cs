using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchResultTabMgr
	{
		private List<SearchResultTab> m_tabs = new List<SearchResultTab>();

		private string[] m_tabTitles;

		private int m_tabIndex;

		public void Prepared()
		{
			List<string> list = new List<string>();
			foreach (SearchResultTab current in this.m_tabs)
			{
				list.Add(current.Title);
			}
			this.m_tabTitles = list.ToArray();
		}

		public void AddTab(SearchResultTab tab)
		{
			this.m_tabs.Add(tab);
		}

		public void ClearTabs()
		{
			this.m_tabs.Clear();
		}

		public void SetCurTab(SearchResultTabType tabType)
		{
			int curTab = this.TabTypeToTabIndex(tabType);
			this.SetCurTab(curTab);
		}

		private void SetCurTab(int tabIndex)
		{
			if (!this.IsValidTabIndex(tabIndex))
			{
				return;
			}
			this.m_tabIndex = tabIndex;
		}

		public SearchResultTab GetTab(SearchResultTabType tabType)
		{
			int tabIndex = this.TabTypeToTabIndex(tabType);
			return this.GetTab(tabIndex);
		}

		private SearchResultTab GetTab(int tabIndex)
		{
			if (!this.IsValidTabIndex(tabIndex))
			{
				return null;
			}
			return this.m_tabs[tabIndex];
		}

		private int TabTypeToTabIndex(SearchResultTabType tabType)
		{
			int result = -1;
			for (int i = 0; i < this.m_tabs.Count; i++)
			{
				if (this.m_tabs[i].Type == tabType)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public bool IsValidTabIndex(int tabIndex)
		{
			return tabIndex >= 0 && tabIndex <= this.m_tabs.Count - 1;
		}

		public void Draw(int startY)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			int curTab = GUILayout.Toolbar(this.m_tabIndex, this.m_tabTitles, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			this.SetCurTab(curTab);
			SearchResultTab tab = this.GetTab(this.m_tabIndex);
			if (tab != null)
			{
				int startY2 = startY + 22;
				tab.Drawer.Draw(startY2);
			}
		}

		public void ShowTab(SearchResultTabType tabType, List<SearchResult> results)
		{
			this.SetCurTab(tabType);
			this.SetResults(tabType, results);
		}

		public void SetResults(SearchResultTabType tabType, List<SearchResult> results)
		{
			SearchResultTab tab = this.GetTab(tabType);
			if (tab == null)
			{
				return;
			}
			tab.Drawer.SetResults(results, false);
			tab.Drawer.SelectResult(0);
		}
	}
}
