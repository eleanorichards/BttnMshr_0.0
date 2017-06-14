using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
    string[] player_name;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 4; i++)
        {
            player_name[i] = Input.GetJoystickNames()[i];
            Debug.Log(player_name[i]);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
