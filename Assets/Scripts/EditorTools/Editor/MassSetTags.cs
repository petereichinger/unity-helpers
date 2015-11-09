using System.Collections;
using UnityEditor;
using UnityEngine;

/// <summary>Tool that applies a tag to the currently selected objects and all their child objects.</summary>
public class MassSetTags : EditorWindow {
	private string _tag;

	[MenuItem("UnityHelpers/Mass Set Tags")]
	public static void Init() {
		MassSetTags window = GetWindow<MassSetTags>();
		window.Show();
	}

	private void OnGUI() {
		EditorGUILayout.HelpBox("Applies the selected tag to all selected objects and their child objects", MessageType.Info);
		_tag = EditorGUILayout.TagField("Tag", _tag);

		if (GUILayout.Button("Apply")) {
			foreach (GameObject go in Selection.gameObjects) {
				Undo.RegisterFullObjectHierarchyUndo(go, "Mass set tag '" + _tag + "' for " + go.name);
				SetTagRecursively(go, _tag);
			}
		}
	}

	private void SetTagRecursively(GameObject go, string tag) {
		go.tag = tag;

		foreach (Transform t in go.transform) {
			SetTagRecursively(t.gameObject, tag);
		}
	}
}
