using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebugPrefixes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.LogError(DebugPrefixEnum.test, "1234567890".Colored(Colors.brown));
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
