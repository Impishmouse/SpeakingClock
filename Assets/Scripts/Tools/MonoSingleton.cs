using UnityEngine;

namespace Tools
{
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		private static T instance = null;

		public static T Instance
		{
			get
			{
				CreateInstance();
				return instance;
			}
		}

		public static void CreateInstance()
		{
			if (ReferenceEquals(instance, null))
			{
				instance = FindObjectOfType(typeof(T)) as T;
				if (ReferenceEquals(instance, null))
				{
					Debug.Log("No instance of " + typeof(T) + ", a temporary one is created.");
					instance = new GameObject("_" + typeof(T), typeof(T)).GetComponent<T>();
					DontDestroyOnLoad(instance);
					if (ReferenceEquals(instance, null))
					{
						Debug.LogError("Problem during the creation of " + typeof(T));
					}
				}

				instance.Init();
			}
		}

		public virtual void Init()
		{
		}

		private void OnDestroy()
		{
			instance = null;
		}
	}
}