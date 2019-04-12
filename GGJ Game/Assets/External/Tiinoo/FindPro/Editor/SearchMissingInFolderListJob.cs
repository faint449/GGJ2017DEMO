using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{
	public class SearchMissingInFolderListJob : TnAbstractJob
	{
		private TnEditorFolderList m_folderList;

		private List<SearchResult> m_results;

		public SearchMissingInFolderListJob(TnEditorFolderList folderList)
		{
			this.m_folderList = folderList;
			this.m_results = new List<SearchResult>();
		}

		protected override void DoInit()
		{
			List<string> folders = this.m_folderList.GetFolders();
			foreach (string current in folders)
			{
				SearchMissingInFolderJob task = new SearchMissingInFolderJob(this.m_folderList, current);
				base.Add(task);
			}
		}

		public List<SearchResult> GetResults()
		{
			return this.m_results;
		}
	}
}
