using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

    void Awake()
    {
    }

	public void Click()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
