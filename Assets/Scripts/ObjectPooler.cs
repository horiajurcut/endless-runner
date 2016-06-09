using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int poolSize;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start ()
	{
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < poolSize; i++) {
			AddNewPooledObject ();
		}
	}
	
	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}

		return AddNewPooledObject ();
	}

	private GameObject AddNewPooledObject()
	{
		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (false);

		pooledObjects.Add (obj);

		return obj;
	}
}
