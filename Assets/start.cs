using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	public static int mission_num;
	public static int player_season_num;
	public static int player_score;

	void Start()
	{
	}

    public void Click()
    {
		Debug.Log ("click~~!~!");
		mission_num = Random.Range (1, 4);
		//1 : summer 2 : auttum 3 : winter
		//arrow_move.season = mission_num;
		Debug.Log (mission_num);
		if (mission_num == 1) {
			SceneManager.LoadScene ("mission_autumn");
		} else if (mission_num == 2) {
			SceneManager.LoadScene ("mission_winter");
		} else if (mission_num == 3) {
			SceneManager.LoadScene ("mission_summer");
		}
    }
}
