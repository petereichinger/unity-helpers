using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityHelpers.EditorHelpers {

	/// <summary>Iterator over serialized property arrays.</summary>
	/// <typeparam name="T">Type of object to iterate over.</typeparam>
	public class ArrayIterator<T> : IEnumerable<T> where T : Object {
		private readonly SerializedProperty _property;

		/// <summary>Create a new instance of the iterator.</summary>
		/// <param name="property">The SerializedProperty that will be iterated over.</param>
		private ArrayIterator(SerializedProperty property) {
			_property = property;
		}

		/// <summary>Create a new iterator.</summary>
		/// <param name="property">The SerializedProperty that will be iterated over.</param>
		/// <returns>An instance of the iterator class.</returns>
		public static ArrayIterator<T> Create(SerializedProperty property) {
			if (!property.isArray) {
				Debug.LogError("Can only iterate over arrays.");
				return null;
			}
			return new ArrayIterator<T>(property);
		}

		public IEnumerator<T> GetEnumerator() {
			int arrayLength = _property.arraySize;
			for (int i = 0; i < arrayLength; i++) {
				Object obj = _property.GetArrayElementAtIndex(i).objectReferenceValue;
				if (obj) {
					yield return (T)obj;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
