using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//****************************************이거 안쓰는 파일(실패해서 arrow_stop.cs로 갈아탐)*************************************


public class move_stop : MonoBehaviour {

	public GameObject arrow;
	public int test = 0;
	public static float arrow_x;
	public static float arrow_y;
	public Vector3 pos;
	public int stage;
	public int cnt = 0;
	//public bool bnt_enable = false;

	

	// Use this for initialization
	void Start () {
		stage = arrow_move.stage;
	}
	//Input.GetKey (KeyCode.Mouse0)
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKey (KeyCode.Mouse0)) {
			stop ();
		}*/
		
	}

	public void Click(){
		
			/*bnt_enable = true;
			if (bnt_enable == true) {
				arrow_move.enable_move = false;
				arrow_x = arrow.transform.position.x;
				arrow_y = arrow.transform.position.y;
				pos.x = arrow_x;
				pos.y = arrow_y;
				arrow.transform.position = pos;
				cnt++;
				arrow_move.stage++;
				stage = arrow_move.stage;

				//stage = arrow_move.stage;
				//arrow.transform.position = new vector3 (pos.x, pos.y, z);
			}
			arrow_move.enable_move = true;*/
		cnt++;
		arrow_move.stage++;
		arrow_move.enable_move = false;
		
	}
}