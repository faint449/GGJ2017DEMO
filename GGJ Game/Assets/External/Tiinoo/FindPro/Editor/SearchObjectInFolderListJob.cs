using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{
	public class SearchObjectInFolderListJob : TnAbstractJob
	{
		private TnEditorFolderList m_folderList;

		private List<SearchResult> m_results;

        private SearchType m_searchType;

		public SearchObjectInFolderListJob(TnEditorFolderList folderList, SearchType searchType)
		{
			this.m_folderList = folderList;
			this.m_results = new List<SearchResult>();
            this.m_searchType = searchType;
		}

		protected override void DoInit()
		{
			List<string> folders = this.m_folderList.GetFolders();
			foreach (string current in folders)
			{
				SearchObjectInFolderJob task = new SearchObjectInFolderJob(this.m_folderList, current, m_searchType);
				base.Add(task);
			}
		}

		public List<SearchResult> GetResults()
		{
			return this.m_results;
		}
	}
}
