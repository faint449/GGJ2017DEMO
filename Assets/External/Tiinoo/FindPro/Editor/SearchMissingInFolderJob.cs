using System;
using System.Collections.Generic;
using System.IO;
using Tiinoo.Editor;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{
	public class SearchMissingInFolderJob : TnAbstractJob
	{
		private TnEditorFolderList m_folderList;

		private string m_folderPath;

		public string FolderPath
		{
			get
			{
				return this.m_folderPath;
			}
		}

		public SearchMissingInFolderJob(TnEditorFolderList folderList, string folderPath)
		{
			this.m_folderList = folderList;
			this.m_folderPath = folderPath;
		}

		protected override void DoInit()
		{
			if (!this.m_folderList.CheckFolder(this.m_folderPath, false))
			{
				base.Cancel();
				return;
			}
			List<string> filePaths = TnEditorFileUtil.GetFilePaths(this.m_folderPath, "*.*", SearchOption.AllDirectories, "*.meta", true);
			for (int i = 0; i < filePaths.Count; i++)
			{
				SearchMissingInPrefabTask task = new SearchMissingInPrefabTask(filePaths[i]);
				base.Add(task);
			}
		}
	}
}
