using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace UnityHelpers.EditorTools.Editor {

	/// <summary>Editor window to look for hidden objects.</summary>
	public class RemoveHiddenObjectsTool : EditorWindow {
		private Transform _removeParent;
		private HideFlags _hideFlags;
		private List<Transform> _deleteList;
		private Vector2 _scrollPos;
		private string _filter = string.Empty;
		private bool _includePrefabs = false;

		[MenuItem("UnityHelpers/Remove hidden objects")]
		private static void Init() {
			RemoveHiddenObjectsTool window = GetWindow<RemoveHiddenObjectsTool>();
			window.Show();
		}

		private void OnGUI() {
			_removeParent = (Transform)EditorGUILayout.ObjectField("Select object", _removeParent, typeof(Transform), true);

			_hideFlags = (HideFlags)EditorGUILayout.EnumPopup("Set hide flag", _hideFlags);

			if (GUILayout.Button("Look for hidden objects")) {
				if (_removeParent) {
					Transform[] childTransforms = _removeParent.GetComponentsInChildren<Transform>();

					_deleteList = new List<Transform>(childTransforms.Where(
						t => (t.gameObject.hideFlags & _hideFlags) == _hideFlags));
				} else {
					IEnumerable<GameObject> gos = Resources.FindObjectsOfTypeAll<GameObject>().Where(
						go => ((go.hideFlags & _hideFlags) == _hideFlags) && go.transform.parent == null);
					_deleteList = new List<Transform>();
					foreach (GameObject go in gos) {
						_deleteList.Add(go.transform);
					}
				}
			}
			if (_deleteList == null || _deleteList.Count <= 0) {
				return;
			}

			GUILayout.BeginHorizontal();
			GUILayout.Label("Regex", GUILayout.Width(40f));
			_filter = GUILayout.TextField(_filter);
			_includePrefabs = EditorGUILayout.Toggle("Include prefabs", _includePrefabs);
			GUILayout.EndHorizontal();
			Color oldColor = GUI.color;
			GUI.color = Color.red;
			if (GUILayout.Button("Destroy all")) {
				for (int i = 0; i < _deleteList.Count; i++) {
					if (ValidItem(_deleteList[i])) {
						DestroyImmediate(_deleteList[i].gameObject);
					}
				}
			}

			GUI.color = oldColor;
			_scrollPos = GUILayout.BeginScrollView(_scrollPos, false, true);
			for (int i = 0; i < _deleteList.Count; i++) {
				if (!ValidItem(_deleteList[i])) {
					continue;
				}
				GUILayout.BeginHorizontal();
				EditorGUILayout.ObjectField("", _deleteList[i], typeof(Transform), true);

				GUILayout.Label(PrefabUtility.GetPrefabType(_deleteList[i]).ToString());
				if (GUILayout.Button("Destroy")) {
					DestroyImmediate(_deleteList[i].gameObject);
				}

				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
			_deleteList.RemoveAll(t => !t);
		}

		private bool ValidItem(Transform t) {
			if (!t) {
				return false;
			}

			if (!_includePrefabs) {
				if (PrefabUtility.GetPrefabType(t) == PrefabType.Prefab) {
					return false;
				}
			}

			if (!string.IsNullOrEmpty(_filter)) {
				try {
					if (!string.IsNullOrEmpty(t.name) && !Regex.IsMatch(t.name, _filter)) {
						return false;
					}
				} catch (ArgumentException) {
					return true;
				}
			}
			return true;
		}
	}
}
