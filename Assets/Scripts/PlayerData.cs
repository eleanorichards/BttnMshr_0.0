using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string[] player_name = Input.GetJoystickNames();

        for (int i = 0; i < player_name.Length; i++)
        {
            Debug.Log(player_name[i]);
            player_name[i] = Input.GetJoystickNames()[i];
        }  

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
