using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class go_next : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		SceneManager.LoadScene (8);
	}
}
