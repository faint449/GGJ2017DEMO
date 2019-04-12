using System;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{
	public class SearchMissingInPrefabTask : TnAbstractTask
	{
		private string m_filePath;

		public string FilePath
		{
			get
			{
				return this.m_filePath;
			}
		}

		public SearchMissingInPrefabTask(string filePath)
		{
			this.m_filePath = filePath;
		}

		protected override void DoInit()
		{
		}
	}
}
