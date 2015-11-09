using System.Collections;
using UnityEngine;

namespace UnityHelpers.Components {

	/// <summary>Extension methods for <see cref="Component"/>.</summary>
	public static class ComponentExtensions {

		/// <summary>
		/// Get or add an component. If the gameObject with the specified
		/// <paramref name="component"/> already has the specified <typeparamref name="T"/> it will
		/// be returned. Else a new component of the specified type will be added and returned.
		/// </summary>
		/// <typeparam name="T">Type of component to add or get.</typeparam>
		/// <param name="component">Component where to add or get the specified type of component.</param>
		/// <returns>A new or the existing instance of the specified component.</returns>
		public static T GetOrAddComponent<T>(this Component component) where T : Component {
			return GetOrAddComponent<T>(component.gameObject);
		}

		/// <summary>
		/// Get or add an component. If the gameObject already has the specified kind of component
		/// it will be returned. Else a new component of the specified type will be added and returned.
		/// </summary>
		/// <typeparam name="T">Type of component to add or get.</typeparam>
		/// <param name="gameObject">Game Object where to get or add the component.</param>
		/// <returns>A new or the existing instance of the specified component.</returns>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
			return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
		}
	}
}
