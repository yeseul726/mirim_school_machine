using UnityEngine;
using System.Collections;

public class arrow_stop : MonoBehaviour {

	public static float arrow_x = 0;


	// Use this for initialization
	void Start () {
		Debug.Log ("SIBAL JOTTO ANDAE");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click(GameObject arrow) {
		arrow_x = arrow.transform.position.x;
		Debug.Log ("Click!");
		arrow_move.enable_move = false;
		arrow_move.bnt_tmp = true;
	}
}
