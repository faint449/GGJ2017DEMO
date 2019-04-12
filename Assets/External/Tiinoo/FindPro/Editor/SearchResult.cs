using System;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEditor;
using UnityEngine;

namespace Tiinoo.FindPro
{
	public class SearchResult
	{
		public int iid;

		public string path;

		public string AssetPath
		{
			get
			{
				return AssetDatabase.GetAssetPath(this.iid);
			}
		}

		public bool IsMainAsset()
		{
			return AssetDatabase.IsMainAsset(this.iid);
		}

		public static SearchResult Create(SerializedProperty p)
		{
			Component component = p.serializedObject.targetObject as Component;
			return new SearchResult
			{
				iid = component.GetInstanceID(),
				path = string.Concat(new string[]
				{
					TnTransformUtil.GetHierarchyFullPath(component.gameObject),
					"/<",
					component.GetType().Name,
					">/[",
					TnEditorBridge.GetDisplayName(p),
					"]"
				})
			};
		}
	}
}
