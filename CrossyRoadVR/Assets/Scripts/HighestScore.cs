using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameScore score = GameObject.FindObjectOfType<GameScore>();
       Text scoreText= this.GetComponent<Text>();
       scoreText.text = "High Score  " + score.highestScore + " meters";

	}
	
	
}
