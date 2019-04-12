using System;

namespace Tiinoo.FindPro
{
	public class SearchResultTab
	{
		private SearchResultTabType m_type;

		private string m_title;

		private SearchResultDrawer m_drawer;

		public SearchResultTabType Type
		{
			get
			{
				return this.m_type;
			}
		}

		public string Title
		{
			get
			{
				return this.m_title;
			}
		}

		public SearchResultDrawer Drawer
		{
			get
			{
				return this.m_drawer;
			}
		}

		public SearchResultTab(SearchResultTabType tabType, string title)
		{
			this.m_type = tabType;
			this.m_title = title;
			this.m_drawer = new SearchResultDrawer(tabType);
		}
	}
}
