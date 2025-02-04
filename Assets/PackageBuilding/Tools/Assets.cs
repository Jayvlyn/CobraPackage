using UnityEngine;
using Cobra.DesignPattern;

/*
 * Global Asset references
 * Edit Asset references in the prefab Resources/AssetRefs
 * */
public class Assets : Singleton<Assets>
{
	// Hides Instance property in Singleton to:
	// add functionality for creating the instance when it does not exist in the scene
	public static new Assets Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindFirstObjectByType<Assets>();

				if (instance == null)
				{
					Debug.LogError("Assets Singleton: Instance not found in scene! \n Creating new instance");
				}

				instance = Instantiate(Resources.Load<Assets>("AssetRefs"));
			}
			return instance;
		}
	}

	[Header("Assets")]
	public Transform exampleReference;
}
