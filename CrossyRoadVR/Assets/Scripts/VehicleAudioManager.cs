using UnityEngine;
using System.Collections;

public class VehicleAudioManager : MonoBehaviour {

    private CardboardAudioSource audio;
    private Player player;
    private bool isOnPlayAudio=false;
    public float HornsDistance = 5.0f;
    void OnEnable()
    {
        audio = GetComponent<CardboardAudioSource>();
        player = GameObject.Find("Player").GetComponent<Player>();
        isOnPlayAudio = false;
    }
	
	// Update is called once per frame
	void Update () {
        PlayCarHornAudio();
	}

    void PlayCarHornAudio()
    {
        //在前方
        bool isAhead = Vector3.Dot(this.transform.right, player.transform.position-this.transform.position ) > 0f;
        //在右方
        bool isOnRight = Vector3.Cross(this.transform.right, player.transform.position).y > 0;

        if (Vector3.Distance(this.transform.position, player.transform.position) <= HornsDistance && isAhead && isOnRight)
        {
            if (!isOnPlayAudio)
            {
                audio.Play();
                isOnPlayAudio = true;
            }
            
        }
    }
}
