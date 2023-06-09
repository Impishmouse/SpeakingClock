﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ScriptableObjects
{
	public abstract class ScriptableObjectSigletone<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Resources.Load<T>(typeof(T).Name);
#if UNITY_EDITOR
					if (_instance == null)
					{
						_instance = CreateInstance<T>();
						AssetDatabase.CreateAsset(_instance, "Assets/Resources/" + typeof(T).Name + ".asset");
						AssetDatabase.Refresh();
					}
#endif
				}

				(_instance as ScriptableObjectSigletone<T>)?.OnInstanceCreated();

				return _instance;
			}
		}

		protected virtual void OnInstanceCreated() { }
	}
}