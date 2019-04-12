using System;
using System.Collections.Generic;
using System.IO;
using Tiinoo.Editor;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{
	public class SearchObjectInFolderJob : TnAbstractJob
	{
		private TnEditorFolderList m_folderList;

		private string m_folderPath;

        private SearchType m_searchType;

		public string FolderPath
		{
			get
			{
				return this.m_folderPath;
			}
		}

		public SearchObjectInFolderJob(TnEditorFolderList folderList, string folderPath, SearchType searchType)
		{
			this.m_folderList = folderList;
			this.m_folderPath = folderPath;
            this.m_searchType = searchType;
		}

		protected override void DoInit()
		{
			if (!this.m_folderList.CheckFolder(this.m_folderPath, false))
			{
				base.Cancel();
				return;
			}
            if (this.m_searchType == SearchType.Prefab)
            {
                List<string> filePaths = TnEditorFileUtil.GetFilePaths(this.m_folderPath, "*.prefab", SearchOption.AllDirectories, "*.meta", true);
                for (int i = 0; i < filePaths.Count; i++)
                {
                    SearchObjectInPrefabTask task = new SearchObjectInPrefabTask(filePaths[i]);
                    base.Add(task);
                }
            }
            else if (this.m_searchType == SearchType.FBX)
            {
                List<string> filePaths = TnEditorFileUtil.GetFilePaths(this.m_folderPath, "*.fbx", SearchOption.AllDirectories, "*.meta", true);
                for (int i = 0; i < filePaths.Count; i++)
                {
                    SearchObjectInPrefabTask task = new SearchObjectInPrefabTask(filePaths[i]);
                    base.Add(task);
                }
            }
            else if (this.m_searchType == SearchType.Material)
            {
                List<string> filePaths = TnEditorFileUtil.GetFilePaths(this.m_folderPath, "*.mat", SearchOption.AllDirectories, "*.meta", true);
                for (int i = 0; i < filePaths.Count; i++)
                {
                    SearchObjectInMaterialTask task = new SearchObjectInMaterialTask(filePaths[i]);
                    base.Add(task);
                }
            }
        }
	}
}
