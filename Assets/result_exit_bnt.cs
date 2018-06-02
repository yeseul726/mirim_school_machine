using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class result_exit_bnt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		//System.Diagnostics.Process.GetCurrentProcess().Kill();
		SceneManager.LoadScene(0);
	}
}
