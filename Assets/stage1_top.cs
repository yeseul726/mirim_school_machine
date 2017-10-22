using UnityEngine;
using System.Collections;

public class stage1_top : MonoBehaviour {

	//public int []full_score = new int[9]; //0방은 null, index를 1부터 사용하기 위해 9개 방 잡아줌
	//public int []full_score = {null, 8, 7, 6}; //0방은 null, index를 1부터 사용하기 위해 4개 방 잡아줌, 1: 동복(8) 2: 춘추복(7) 3: 하복(6)
	public int score = 0;
	public float start_first_blk = -6.92f, end_first_blk = -3.89f;
	public float start_second_blk = -3.9f, end_second_blk = -0.01f;
	public float start_third_blk = 0, end_third_blk = 3.87f;
	public float start_fourth_blk = 3.88f, end_fourth_blk = 6.92f;
	public int season = 0;
	public GameObject arrow, top, bottom, stocking, socks, hair_tie, hair, outer, backpack;

	// Use this for initialization
	void Start () {
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
		
		switch (arrow_move.stage) {
		case 1:
			top.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 0;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) { //칸2
				score += 3;
				season = 1; //춘추복
			} else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) { //칸3
				score += 2;
				season = 2; //동복
			} else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) { //칸4
				score += 4;
				season = 3; //하복
			}
			break;
		case 2:
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			top.SetActive (false);
			bottom.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 5;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 0;
			else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 0;
			else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 0;
			break;
		case 3: //춘추복, 동복일 경우에만 setActive(true)Invoke ("Update", 2);
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			bottom.SetActive (false);
			stocking.SetActive (true);
			if (season == 1 || season == 3) {
				if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 3;
				else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 0;
				else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 2;
				else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 0;
			}
			break;
		case 4:
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			stocking.SetActive (false);
			socks.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 2;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 0;
			else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 0;
			else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 5;
			break;
		case 5:
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			socks.SetActive (false);
			hair_tie.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 0;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 0;
			else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 0;
			else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 5;
			break;
		case 6:
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			hair_tie.SetActive (false);
			hair.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 0;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 5;
			else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 5;
			else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 0;
			break;
		case 7: //동복일 경우에만 setActive(true)
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			hair.SetActive (false);
			outer.SetActive (true);
			if (season == 2) {
				if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
				score += 0;
				else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
				score += 0;
				else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
				score += 0;
				else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
				score += 2;
			}
			break;
		case 8:
			arrow_move.pos.x = arrow_move.pos_min;
			arrow_move.pos.y = -1.72f;
			arrow.transform.position = arrow_move.pos;
			outer.SetActive (false);
			backpack.SetActive (true);
			if (move_stop.arrow_x >= start_first_blk && move_stop.arrow_x <= end_first_blk) //칸1
			score += 5;
			else if (move_stop.arrow_x >= start_second_blk && move_stop.arrow_x <= end_second_blk) //칸2
			score += 0;
			else if (move_stop.arrow_x >= start_third_blk && move_stop.arrow_x <= end_third_blk) //칸3
			score += 0;
			else if (move_stop.arrow_x >= start_fourth_blk && move_stop.arrow_x <= end_fourth_blk) //칸4
			score += 0;
			break;
		} //end of switch

		switch (score) {
		case 28: //동복 성공
			break;
		case 29: //하복 성공
			break;
		case 31: //춘추복 성공
			break;
		}
	} //end of update

} //end of class
