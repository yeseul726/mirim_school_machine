using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class arrow_move : MonoBehaviour {

	public GameObject stop_bnt;
	public GameObject arrow, top, bottom, stocking, socks, hair_tie, hair, outer, backpack;


	public float arrow_pos = 0.1f;
	public static bool enable_move = true;
	public static int stage = 0;
	public static float pos_max = 6.92f;
	public static float pos_min = -6.92f;
	public static float arrow_x, arrow_y;
	public static Vector3 pos;
	public int cnt = 0;
	public static float deltime = 1f;
	public static float ticktime = 0;
	public static bool bnt_tmp = false;

	//reference
	public int score = 0;
	public static float start_first_blk = -6.92f, end_first_blk = -3.89f;
	public static float start_second_blk = -3.9f, end_second_blk = -0.01f;
	public static float start_third_blk = 0, end_third_blk = 3.87f;
	public static float start_fourth_blk = 3.88f, end_fourth_blk = 6.92f;
	public int season = 0; //춘추복, 동복, 하복 구별하기 위해서


	// Use this for initialization
	public void Start () {
		//replay시 값 초기화
		stage = 0;
		cnt = 0;
		deltime = 1f;
		ticktime = 0;
		score = 0;
		season = 0;

		arrow.SetActive (true);
		top.SetActive (false);
		bottom.SetActive (false);
		stocking.SetActive (false);
		socks.SetActive (false);
		hair_tie.SetActive (false);
		hair.SetActive (false);
		outer.SetActive (false);
		backpack.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		ticktime += deltime;
		//arrow_x = transform.position.x;
		//화살이 좌우로 왔다갔다 하도록 구현하는 소스코드
		if (ticktime >= deltime) {
			move ();
			show_clothe ();
		}
	} //end of Update

	void move(){
		switch(stage){ //속도 조절 switch문 (갈수록 빨라짐)
		case 0: arrow_pos = 0.15f; break;
		case 1: arrow_pos = 0.25f; break;
		case 2: arrow_pos = 0.3f; break;
		case 3: arrow_pos = 0.35f; break;
		case 4: arrow_pos = 0.4f; break;
		case 5: arrow_pos = 0.45f; break;
		case 6: arrow_pos = 0.5f; break;
		case 7: arrow_pos = 0.55f; break;
		default: break;
		} //end of switch ~ case

		//arrow 이동 로직
		if (enable_move == true) {
			if (transform.position.x < pos_max) {
				transform.Translate (arrow_pos, 0, 0);

			} else {
				pos.x = pos_min;
				pos.y = -1.72f;
				transform.position = pos;
				if (transform.position.x < pos_max) {
					transform.Translate (arrow_pos, 0, 0);
				}
			}
		} //end of if
		else if (enable_move == false) {
			arrow_x = transform.position.x;
			arrow_y = transform.position.y;
			pos.x = arrow_x;
			pos.y = arrow_y;
			transform.position = pos;
			cnt++;
			pos.x = pos_min;
			pos.y = -1.72f;
			transform.position = pos;
			stage++;
			enable_move = true;

		}

	}

	void show_clothe(){

		//arrow_stop button을 클릭하면서 호출되는 증감연산자때문에 로직이 복잡해짐.. 하나씩 밀려남

		//춘추복에 해당하는 복장일 경우 +3 동복에 해당하는 복장일 경우 +2 하복에 해당하는 복장일 경우 +7
		//두가지 이상 해당되는 복장일 경우 +10, 하나도 해당 안되는 경우 +0

		switch (cnt) {
		case 0: //상의
			top.SetActive (true);                                                                                                                                               
			break;
		case 1: //상의
			top.SetActive (false);
			bottom.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 0;
				bnt_tmp = false;
				Debug.Log ("stage1 blank1");
				top.SetActive (false);
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 3;
				season = 1; //춘추복
				bnt_tmp = false;
				Debug.Log ("stage1 blank2");
				top.SetActive (false);
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 2;
				season = 2; //동복
				bnt_tmp = false;
				Debug.Log ("stage1 blank3");
				top.SetActive (false);
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 7;
				season = 3; //하복
				bnt_tmp = false;
				Debug.Log ("stage1 blank4");
				top.SetActive (false);
			}
			break;

		default:
			Debug.Log ("hh");
			break;

		case 2: //하의
			bottom.SetActive(false);
			stocking.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 10;

				bnt_tmp = false;
				Debug.Log ("stage2 blank1");
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 0;
				bnt_tmp = false;
				Debug.Log ("stage2 blank2");
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 0;
				bnt_tmp = false;
				Debug.Log ("stage2 blank3");
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 0;
				bnt_tmp = false;
				Debug.Log ("stage2 blank4");
			}
			break;

		case 3: //스타킹
			stocking.SetActive (false);
			socks.SetActive (true);

			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 3;
				bnt_tmp = false;
				Debug.Log ("stage3 blank1");
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 0;
				bnt_tmp = false;
				Debug.Log ("stage3 blank2");
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 2;
				bnt_tmp = false;
				Debug.Log ("stage3 blank3");
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 10;
				bnt_tmp = false;
				Debug.Log ("stage3 blank4");
			}

			break;

		case 4: //양말
			socks.SetActive (false);
			hair_tie.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 2;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 10;
				bnt_tmp = false;
			}
			break;

		case 5: //머리끈
			hair_tie.SetActive (false);
			hair.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 10;
				bnt_tmp = false;
			}
			break;

		case 6: //머리
			hair.SetActive (false);
			outer.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 10;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 10;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 0;
				bnt_tmp = false;
			}
			break;
			
		case 7: //겉옷
			outer.SetActive (false);
			backpack.SetActive (true);
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 10;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 2;
				bnt_tmp = false;
			}
			break;

		case 8: //가방
			if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
				score += 10;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
				score += 0;
				bnt_tmp = false;
			} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
				score += 0;
				bnt_tmp = false;
			}
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("result", 1.5f);
			break;

		} //end of switch
			
	}

	public void result(){
		switch (season) {
		case 1:
			if (score == 66 || score == 73) {
				Debug.Log ("atum success");
				SceneManager.LoadScene (3);
			} else {
				Debug.Log ("faliure");
				SceneManager.LoadScene (4);
			}
			break;
		case 2:
			if (score == 48) {
				Debug.Log ("winter success");
				SceneManager.LoadScene (3);
			} else {
				Debug.Log ("faliure");
				SceneManager.LoadScene (4);
			}
			break;
		case 3:
			if (score == 77) {
				Debug.Log ("summer success");
				SceneManager.LoadScene (3);
			} else {
				Debug.Log ("faliure");
				SceneManager.LoadScene (4);
			}
			break;
		default:
			SceneManager.LoadScene (4);
			break;
		}
	}

} //end of class
