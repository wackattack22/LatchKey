using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public PlayerController player;

    int score;
    float time;
    int life;


	void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + PlayerController.lvlScore.ToString());
        GUI.Label(new Rect(110, 10, 100, 20), "Life: " + PlayerController.lifeCount.ToString());
        GUI.Label(new Rect(210, 10, 100, 20), "Time: " + Mathf.Floor(PlayerController.time).ToString());
    }
}
