using UnityEngine;
using System.Collections;

public class main_keep_sound : MonoBehaviour {

	private static main_keep_sound _instance;

	void Awake(){
		if (!_instance)
		{
			_instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(transform.gameObject);
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
