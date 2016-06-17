using UnityEngine;
using System.Collections;

public class DiamondGenerator : MonoBehaviour {

	public ObjectPooler diamondsPool;

	public void SpawnDiamonds (Vector3 startPosition)
	{
		GameObject diamond = diamondsPool.GetPooledObject ();

		diamond.transform.position = startPosition;
		diamond.SetActive (true);
	}
}
