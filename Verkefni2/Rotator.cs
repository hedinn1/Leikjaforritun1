using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	void Update () 
	{	
		// Snýr hlut örlitið einu sinni á sekundu, 15 við X ás, 30 við y ás og 45 við z ás
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}	