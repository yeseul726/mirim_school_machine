/*using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class arrow_move : MonoBehaviour {

	public GameObject stop_bnt;
	public GameObject arrow, top, bottom, stocking, socks, hair_tie, hair, outer, backpack;
	public GameObject top1, top2, top3, top4;
	public GameObject bottom1, bottom2, bottom3, bottom4;
	public GameObject stocking1, stocking2, stocking3, stocking4;
	public GameObject socks1, socks2, socks3, socks4;
	public GameObject hair_tie1, hair_tie2, hair_tie3, hair_tie4;
	public GameObject hair1, hair2, hair3, hair4;
	public GameObject outer1, outer2, outer3, outer4;
	public GameObject backpack1, backpack2, backpack3, backpack4;

	public int[] result_tmp = new int[8];

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

	public GameObject[] play_result = new GameObject[8];

	//reference
	public int score = 0;
	public static float start_first_blk = -6.92f, end_first_blk = -3.89f;
	public static float start_second_blk = -3.9f, end_second_blk = -0.01f;
	public static float start_third_blk = 0, end_third_blk = 3.87f;
	public static float start_fourth_blk = 3.88f, end_fourth_blk = 6.92f;
	public static int season = 0; //춘추복, 동복, 하복 구별하기 위해서


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

		top1.SetActive (false); top2.SetActive (false); top3.SetActive (false); top4.SetActive (false);
		bottom1.SetActive (false); bottom2.SetActive (false); bottom3.SetActive (false); bottom4.SetActive (false);
		stocking1.SetActive (false); stocking2.SetActive (false); stocking3.SetActive (false); stocking4.SetActive (false);
		socks1.SetActive (false); socks2.SetActive (false); socks3.SetActive (false); socks4.SetActive (false);
		hair_tie1.SetActive (false); hair_tie2.SetActive (false); hair_tie3.SetActive (false); hair_tie4.SetActive (false);
		hair1.SetActive (false); hair2.SetActive (false); hair3.SetActive (false); hair4.SetActive (false);
		outer1.SetActive (false); outer2.SetActive (false); outer3.SetActive (false); outer4.SetActive (false);
		backpack1.SetActive (false); backpack2.SetActive (false); backpack3.SetActive (false); backpack4.SetActive (false);
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

	public void a(){
		Debug.Log ("a");
	}

	void move(){
		switch(stage){ //속도 조절 switch문 (갈수록 빨라짐)
		case 0: arrow_pos = 0.15f; break;
		case 1: arrow_pos = 0.25f; break;
		case 2: arrow_pos = 0.25f; break;
		case 3: arrow_pos = 0.25f; break;
		case 4: arrow_pos = 0.35f; break;
		case 5: arrow_pos = 0.35f; break;
		case 6: arrow_pos = 0.4f; break;
		case 7: arrow_pos = 0.4f; break;
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

	void click_stop_button(){
		Debug.Log ("Click!");
		arrow_move.enable_move = false;
		arrow_move.bnt_tmp = true;
	}

	void show_clothe(){

		//arrow_stop button을 클릭하면서 호출되는 증감연산자때문에 로직이 복잡해짐.. 하나씩 밀려남

		//춘추복에 해당하는 복장일 경우 +3 동복에 해당하는 복장일 경우 +2 하복에 해당하는 복장일 경우 +7
		//두가지 이상 해당되는 복장일 경우 +10, 하나도 해당 안되는 경우 +0

		switch (cnt) {
		case 0: //상의
			//top.SetActive (true);
			stage_top ();
			break;
		case 1: //상의
			Debug.Log("stage : top");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_top2", 1f);
			break;

		case 2: //하의
			Debug.Log("stage : bottom");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_bottom", 1f);
			break;

		case 3: //스타킹
			Debug.Log("stage : stocking");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_stocking", 1f);
			break;

		case 4: //양말
			Debug.Log("stage : socks");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_socks", 1f);
			break;

		case 5: //머리끈
			Debug.Log("stage : hair_tie");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_hair_tie", 1f);
			break;

		case 6: //머리
			Debug.Log("stage : hair");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_hair", 1f);
			break;

		case 7: //겉옷
			Debug.Log("stage : outer");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke("stage_outer", 1f);
			break;

		case 8: //가방
			Debug.Log("stage : backpack");
			pos.x = arrow_stop.arrow_x;
			transform.position = pos;
			Invoke ("stage_backpack", 1f);
			break;
		} //end of switch

	}

	public void stage_top(){
		top.SetActive (true);
	}

	public void stage_top2(){
		top.SetActive (false);
		bottom.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result [0] = top1;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage1 blank1");
			show_play_result.result_tmp [0] = 1;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result [0] = top2;
			score += 3;
			season = 1; //춘추복
			bnt_tmp = false;
			Debug.Log ("stage1 blank2");
			show_play_result.result_tmp [0] = 2;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result [0] = top3;
			score += 2;
			season = 2; //동복
			bnt_tmp = false;
			Debug.Log ("stage1 blank3");
			show_play_result.result_tmp [0] = 3;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result [0] = top4;
			score += 7;
			season = 3; //하복
			bnt_tmp = false;
			Debug.Log ("stage1 blank4");
			show_play_result.result_tmp [0] = 4;
			top.SetActive (false);
		}
		Debug.Log ("score" + score);
	}

	public void stage_bottom(){
		bottom.SetActive(false);
		stocking.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[1] = bottom1;
			score += 10;
			bnt_tmp = false;
			Debug.Log ("stage2 blank1");
			show_play_result.result_tmp [1] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[1] = bottom2;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank2");
			show_play_result.result_tmp [1] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[1] = bottom3;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank3");
			show_play_result.result_tmp [1] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[1] = bottom4;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank4");
			show_play_result.result_tmp [1] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_stocking(){
		stocking.SetActive (false);
		socks.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[2] = stocking1;
			score += 3;
			bnt_tmp = false;
			Debug.Log ("stage3 blank1");
			show_play_result.result_tmp [2] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[2] = stocking2;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage3 blank2");
			show_play_result.result_tmp [2] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[2] = stocking3;
			score += 2;
			bnt_tmp = false;
			Debug.Log ("stage3 blank3");
			show_play_result.result_tmp [2] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[2] = stocking4;
			score += 10;
			bnt_tmp = false;
			Debug.Log ("stage3 blank4");
			show_play_result.result_tmp [2] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_socks(){
		socks.SetActive (false);
		hair_tie.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[3] = socks1;
			score += 2;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[3] = socks2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[3] = socks3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[3] = socks4;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_hair_tie(){
		hair_tie.SetActive (false);
		hair.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[4] = hair_tie1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[4] = hair_tie2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[4] = hair_tie3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[4] = hair_tie4;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_hair(){
		hair.SetActive (false);
		outer.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[5] = hair1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[5] = hair2;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[5] = hair3;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[5] = hair4;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_outer(){
		outer.SetActive (false);
		backpack.SetActive (true);
		pos.x = pos_min;
		transform.position = pos;
		move ();
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[6] = outer1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[6] = outer2;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[6] = outer3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[6] = outer4;
			score += 2;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_backpack(){
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result [7] = backpack1;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result [7] = backpack2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result [7] = backpack3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result [7] = backpack4;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 4;
		}
		pos.x = arrow_stop.arrow_x;
		transform.position = pos;
		Invoke ("", 1.5f);
		SceneManager.LoadScene (12);
		//Debug.Log ("score" + score);
		start.player_score = score;
		start.player_season_num = season;
		Invoke ("result", 1.5f);
	}


	public void result(){
		Debug.Log ("total score : " + start.player_score);
		Debug.Log("season : " + start.player_season_num);
		if (start.player_season_num == start.mission_num && start.player_score == 66 || start.player_score == 73) {
			Debug.Log ("atum success");
			SceneManager.LoadScene (3);
		} 
		else if (start.player_season_num == start.mission_num && start.player_score == 48) {
			Debug.Log ("winter success");
			SceneManager.LoadScene (3);
		}
		else if (start.player_season_num == start.mission_num && start.player_score == 77) {
			Debug.Log ("summer success");
			SceneManager.LoadScene (3);
		}
		else {
			Debug.Log ("faliure");
			SceneManager.LoadScene (4);
		}
	}

} //end of class
*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class arrow_move : MonoBehaviour {

	public GameObject stop_bnt;
	public GameObject arrow, top, bottom, stocking, socks, hair_tie, hair, outer, backpack;
	public GameObject top1, top2, top3, top4;
	public GameObject bottom1, bottom2, bottom3, bottom4;
	public GameObject stocking1, stocking2, stocking3, stocking4;
	public GameObject socks1, socks2, socks3, socks4;
	public GameObject hair_tie1, hair_tie2, hair_tie3, hair_tie4;
	public GameObject hair1, hair2, hair3, hair4;
	public GameObject outer1, outer2, outer3, outer4;
	public GameObject backpack1, backpack2, backpack3, backpack4;

	public int[] result_tmp = new int[8];

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

	public GameObject[] play_result = new GameObject[8];

	//reference
	public int score = 0;
	public static float start_first_blk = -6.92f, end_first_blk = -3.89f;
	public static float start_second_blk = -3.9f, end_second_blk = -0.01f;
	public static float start_third_blk = 0, end_third_blk = 3.87f;
	public static float start_fourth_blk = 3.88f, end_fourth_blk = 6.92f;
	public static int season = 0; //춘추복, 동복, 하복 구별하기 위해서


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

		top1.SetActive (false); top2.SetActive (false); top3.SetActive (false); top4.SetActive (false);
		bottom1.SetActive (false); bottom2.SetActive (false); bottom3.SetActive (false); bottom4.SetActive (false);
		stocking1.SetActive (false); stocking2.SetActive (false); stocking3.SetActive (false); stocking4.SetActive (false);
		socks1.SetActive (false); socks2.SetActive (false); socks3.SetActive (false); socks4.SetActive (false);
		hair_tie1.SetActive (false); hair_tie2.SetActive (false); hair_tie3.SetActive (false); hair_tie4.SetActive (false);
		hair1.SetActive (false); hair2.SetActive (false); hair3.SetActive (false); hair4.SetActive (false);
		outer1.SetActive (false); outer2.SetActive (false); outer3.SetActive (false); outer4.SetActive (false);
		backpack1.SetActive (false); backpack2.SetActive (false); backpack3.SetActive (false); backpack4.SetActive (false);
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

	public void a(){
		Debug.Log ("a");
	}

	void move(){
		switch(stage){ //속도 조절 switch문 (갈수록 빨라짐)
		case 0: arrow_pos = 0.15f; break;
		case 1: arrow_pos = 0.25f; break;
		case 2: arrow_pos = 0.25f; break;
		case 3: arrow_pos = 0.25f; break;
		case 4: arrow_pos = 0.35f; break;
		case 5: arrow_pos = 0.35f; break;
		case 6: arrow_pos = 0.4f; break;
		case 7: arrow_pos = 0.4f; break;
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

	void click_stop_button(){
		Debug.Log ("Click!");
		arrow_move.enable_move = false;
		arrow_move.bnt_tmp = true;
	}

	void show_clothe(){

		//arrow_stop button을 클릭하면서 호출되는 증감연산자때문에 로직이 복잡해짐.. 하나씩 밀려남

		//춘추복에 해당하는 복장일 경우 +3 동복에 해당하는 복장일 경우 +2 하복에 해당하는 복장일 경우 +7
		//두가지 이상 해당되는 복장일 경우 +10, 하나도 해당 안되는 경우 +0

		switch (cnt) {
		case 0: //상의
			/*top.SetActive (true);*/
			stage_top ();
			break;
		case 1: //상의
			Debug.Log("stage : top");
			Invoke("stage_top2", 1f);
			break;

		case 2: //하의
			Debug.Log("stage : bottom");
			Invoke("stage_bottom", 1f);
			break;

		case 3: //스타킹
			Debug.Log("stage : stocking");
			Invoke("stage_stocking", 1f);
			break;

		case 4: //양말
			Debug.Log("stage : socks");
			Invoke("stage_socks", 1f);
			break;

		case 5: //머리끈
			Debug.Log("stage : hair_tie");
			Invoke("stage_hair_tie", 1f);
			break;

		case 6: //머리
			Debug.Log("stage : hair");
			Invoke("stage_hair", 1f);
			break;

		case 7: //겉옷
			Debug.Log("stage : outer");
			Invoke("stage_outer", 1f);
			break;

		case 8: //가방
			Debug.Log("stage : backpack");
			Invoke ("stage_backpack", 1f);
			break;
		} //end of switch

	}


	public void stage_top(){
		top.SetActive (true);
	}

	public void stage_top2(){
		top.SetActive (false);
		bottom.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result [0] = top1;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage1 blank1");
			show_play_result.result_tmp [0] = 1;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result [0] = top2;
			score += 3;
			season = 1; //춘추복
			bnt_tmp = false;
			Debug.Log ("stage1 blank2");
			show_play_result.result_tmp [0] = 2;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result [0] = top3;
			score += 2;
			season = 2; //동복
			bnt_tmp = false;
			Debug.Log ("stage1 blank3");
			show_play_result.result_tmp [0] = 3;
			top.SetActive (false);
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result [0] = top4;
			score += 7;
			season = 3; //하복
			bnt_tmp = false;
			Debug.Log ("stage1 blank4");
			show_play_result.result_tmp [0] = 4;
			top.SetActive (false);
		}
		Debug.Log ("score" + score);
	}

	public void stage_bottom(){
		bottom.SetActive(false);
		stocking.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[1] = bottom1;
			score += 10;
			bnt_tmp = false;
			Debug.Log ("stage2 blank1");
			show_play_result.result_tmp [1] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[1] = bottom2;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank2");
			show_play_result.result_tmp [1] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[1] = bottom3;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank3");
			show_play_result.result_tmp [1] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[1] = bottom4;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage2 blank4");
			show_play_result.result_tmp [1] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_stocking(){
		stocking.SetActive (false);
		socks.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[2] = stocking1;
			score += 3;
			bnt_tmp = false;
			Debug.Log ("stage3 blank1");
			show_play_result.result_tmp [2] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[2] = stocking2;
			score += 0;
			bnt_tmp = false;
			Debug.Log ("stage3 blank2");
			show_play_result.result_tmp [2] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[2] = stocking3;
			score += 2;
			bnt_tmp = false;
			Debug.Log ("stage3 blank3");
			show_play_result.result_tmp [2] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[2] = stocking4;
			score += 10;
			bnt_tmp = false;
			Debug.Log ("stage3 blank4");
			show_play_result.result_tmp [2] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_socks(){
		socks.SetActive (false);
		hair_tie.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[3] = socks1;
			score += 2;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[3] = socks2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[3] = socks3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[3] = socks4;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [3] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_hair_tie(){
		hair_tie.SetActive (false);
		hair.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[4] = hair_tie1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[4] = hair_tie2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[4] = hair_tie3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[4] = hair_tie4;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [4] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_hair(){
		hair.SetActive (false);
		outer.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[5] = hair1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[5] = hair2;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[5] = hair3;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[5] = hair4;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [5] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_outer(){
		outer.SetActive (false);
		backpack.SetActive (true);
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result[6] = outer1;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result[6] = outer2;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result[6] = outer3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result[6] = outer4;
			score += 2;
			bnt_tmp = false;
			show_play_result.result_tmp [6] = 4;
		}
		Debug.Log ("score" + score);
	}

	public void stage_backpack(){
		if (arrow_stop.arrow_x >= start_first_blk && arrow_stop.arrow_x <= end_first_blk && bnt_tmp == true) { //칸1
			play_result [7] = backpack1;
			score += 10;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 1;
		} else if (arrow_stop.arrow_x >= start_second_blk && arrow_stop.arrow_x <= end_second_blk && bnt_tmp == true) { //칸2
			play_result [7] = backpack2;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 2;
		} else if (arrow_stop.arrow_x >= start_third_blk && arrow_stop.arrow_x <= end_third_blk && bnt_tmp == true) { //칸3
			play_result [7] = backpack3;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 3;
		} else if (arrow_stop.arrow_x >= start_fourth_blk && arrow_stop.arrow_x <= end_fourth_blk && bnt_tmp == true) { //칸4
			play_result [7] = backpack4;
			score += 0;
			bnt_tmp = false;
			show_play_result.result_tmp [7] = 4;
		}
		pos.x = arrow_stop.arrow_x;
		transform.position = pos;
		Invoke ("", 1.5f);
		SceneManager.LoadScene (12);
		//Debug.Log ("score" + score);
		start.player_score = score;
		start.player_season_num = season;
		Invoke ("result", 1.5f);
	}


	public void result(){
		Debug.Log ("total score : " + start.player_score);
		Debug.Log("season : " + start.player_season_num);
		if (start.player_season_num == start.mission_num && start.player_score == 66 || start.player_score == 73) {
			Debug.Log ("atum success");
			SceneManager.LoadScene (3);
		} 
		else if (start.player_season_num == start.mission_num && start.player_score == 48) {
			Debug.Log ("winter success");
			SceneManager.LoadScene (3);
		}
		else if (start.player_season_num == start.mission_num && start.player_score == 77) {
			Debug.Log ("summer success");
			SceneManager.LoadScene (3);
		}
		else {
			Debug.Log ("faliure");
			SceneManager.LoadScene (4);
		}
	}

} //end of class
