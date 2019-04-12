using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchMissingInGameObjectListJob : TnAbstractJob
	{
		private TnEditorGameObjectList m_gameObjectList;

		private List<GameObject> m_missingComponents;

		private List<SerializedProperty> m_missingProperties;

		public SearchMissingInGameObjectListJob(TnEditorGameObjectList gameObjectList)
		{
			this.m_gameObjectList = gameObjectList;
			this.m_missingComponents = new List<GameObject>();
			this.m_missingProperties = new List<SerializedProperty>();
		}

		protected override void DoInit()
		{
			List<GameObject> gameObjects = this.m_gameObjectList.GetGameObjects();
			for (int i = 0; i < gameObjects.Count; i++)
			{
				GameObject go = gameObjects[i];
				if (this.m_gameObjectList.CheckGameObject(go, false))
				{
					SearchMissingInGameObjectTask task = new SearchMissingInGameObjectTask(go);
					base.Add(task);
				}
			}
		}

		public List<GameObject> GetMissingComponents()
		{
			return this.m_missingComponents;
		}

		public List<SerializedProperty> GetMissingProperties()
		{
			return this.m_missingProperties;
		}
	}
}
