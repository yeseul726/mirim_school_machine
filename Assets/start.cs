using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

    void Awake()
    {
    }

    /*public void StartButton()
    {
		startgame ();
    }*/
    public void Click()
    {
		SceneManager.LoadScene(2);
		Debug.Log ("click");
    }
}
