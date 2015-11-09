using UnityEditor;
using UnityEngine;

namespace UnityHelpers.EditorHelpers {

	/// <summary>Helper methods for serialized property arrays.</summary>
	public static class ArrayHelpers {

		/// <summary>Add a new array element at the end of an array.</summary>
		/// <param name="array">The array to add a new element to.</param>
		/// <returns><see cref="SerializedProperty"/> for the new array element.</returns>
		public static SerializedProperty AddArrayElement(SerializedProperty array) {
			return AddArrayElement(array, array.arraySize);
		}

		/// <summary>Add a new array element at the end of an array.</summary>
		/// <param name="array">The array to add a new element to.</param>
		/// <param name="index">Index position where to add the array element.</param>
		/// <returns><see cref="SerializedProperty"/> for the new array element.</returns>
		public static SerializedProperty AddArrayElement(SerializedProperty array, int index) {
			if (!array.isArray) {
				Debug.LogError("Specified property is not an array");
				return null;
			}
			array.InsertArrayElementAtIndex(index);

			return array.GetArrayElementAtIndex(index - 1);
		}
	}
}
