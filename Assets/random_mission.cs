using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class random_mission : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Click()
	{
		SceneManager.LoadScene(2);
		Debug.Log ("click");
	}
}
