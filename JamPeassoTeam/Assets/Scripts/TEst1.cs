using UnityEngine;
using System.Collections.Generic;

public class TEst : MonoBehaviour {

	IEnumerator<int[]> prng;

	void Start () {
		prng = Generator.SRMD(100);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			if(prng.MoveNext()){
				Debug.Log(Generator.text(prng.Current));
				Debug.Log(Generator.text(prng.Current,true));
			}
	}
}
