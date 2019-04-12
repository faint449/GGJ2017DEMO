using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchObjectInGameObjectListJob : TnAbstractJob
	{
		private TnEditorGameObjectList m_gameObjectList;

		private List<SerializedProperty> m_properties;

		private List<GameObject> m_prefabInsts;

		public SearchObjectInGameObjectListJob(TnEditorGameObjectList gameObjectList)
		{
			this.m_gameObjectList = gameObjectList;
			this.m_properties = new List<SerializedProperty>();
			this.m_prefabInsts = new List<GameObject>();
		}

		protected override void DoInit()
		{
			List<GameObject> gameObjects = this.m_gameObjectList.GetGameObjects();
			for (int i = 0; i < gameObjects.Count; i++)
			{
				GameObject go = gameObjects[i];
				if (this.m_gameObjectList.CheckGameObject(go, false))
				{
					SearchObjectInGameObjectTask task = new SearchObjectInGameObjectTask(go);
					base.Add(task);
				}
			}
		}

		public List<SerializedProperty> GetProperties()
		{
			return this.m_properties;
		}

		public List<GameObject> GetPrefabInsts()
		{
			return this.m_prefabInsts;
		}
	}
}
