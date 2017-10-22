using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_way : MonoBehaviour {

    void Awake()
    {
    }

    /*public void StartButton()
    {
        Invoke("startgame", .5f);
    }*/
	public void Click()
    {
		SceneManager.LoadScene(1);
    }
}
