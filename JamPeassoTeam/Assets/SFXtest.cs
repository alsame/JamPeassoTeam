using UnityEngine;
using System.Collections.Generic;

public class SFXtest : MonoBehaviour {
    IEnumerator<int[]> prng;

    void Start()
    {
        prng = Generator.SRMD(100);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SFX.play("sparkies");
    }
}
