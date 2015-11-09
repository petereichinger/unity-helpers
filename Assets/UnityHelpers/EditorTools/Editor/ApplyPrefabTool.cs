using System.Collections;
using UnityEditor;
using UnityEngine;

namespace UnityHelpers.EditorTools.Editor {

	/// <summary>Apply the changes to all selected prefabs.</summary>
	public class ApplyPrefabTool {

		[MenuItem("UnityHelpers/Apply Selected Prefabs")]
		private static void ApplySelectedPrefabs() {
			foreach (GameObject go in Selection.gameObjects) {
				if (!go) {
					continue;
				}
				var instanceRoot = PrefabUtility.FindRootGameObjectWithSameParentPrefab(go);
				if (!instanceRoot) {
					continue;
				}
				var targetPrefab = PrefabUtility.GetPrefabParent(instanceRoot);
				if (!targetPrefab) {
					continue;
				}
				Undo.RecordObject(instanceRoot, "Apply prefab");
				Undo.RecordObject(targetPrefab, "Apply prefab");
				Undo.FlushUndoRecordObjects();
				PrefabUtility.ReplacePrefab(instanceRoot, targetPrefab,
					ReplacePrefabOptions.ConnectToPrefab);
			}
		}
	}
}
