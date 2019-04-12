using System;
using Tiinoo.Engine;

namespace Tiinoo.FindPro
{ 
	public abstract class SearchObjectTask : TnAbstractTask
	{
		protected string m_filePath;

		public string FilePath
		{
			get
			{
				return this.m_filePath;
			}
		}

		protected override void DoInit()
		{
		}
	}

    public class SearchObjectInPrefabTask : SearchObjectTask
    {
        public SearchObjectInPrefabTask(string filePath)
        {
            this.m_filePath = filePath;
        }
    }

    public class SearchObjectInMaterialTask : SearchObjectTask
    {
        public SearchObjectInMaterialTask(string filePath)
        {
            this.m_filePath = filePath;
        }
    }
}
