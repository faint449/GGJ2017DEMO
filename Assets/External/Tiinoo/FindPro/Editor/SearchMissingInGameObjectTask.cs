using System;
using Tiinoo.Engine;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchMissingInGameObjectTask : TnAbstractTask
	{
		private GameObject m_go;

		public GameObject Go
		{
			get
			{
				return this.m_go;
			}
		}

		public SearchMissingInGameObjectTask(GameObject go)
		{
			this.m_go = go;
		}

		protected override void DoInit()
		{
		}
	}
}
