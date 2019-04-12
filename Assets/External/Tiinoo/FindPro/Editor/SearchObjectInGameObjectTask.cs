using System;
using Tiinoo.Engine;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchObjectInGameObjectTask : TnAbstractTask
	{
		private GameObject m_go;

		public GameObject Go
		{
			get
			{
				return this.m_go;
			}
		}

		public SearchObjectInGameObjectTask(GameObject go)
		{
			this.m_go = go;
		}

		protected override void DoInit()
		{
		}
	}
}
