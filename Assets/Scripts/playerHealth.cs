using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

    public float player_health = 500;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DecrementHealth(float _attack_value)
    {
        player_health -= _attack_value;
        Debug.Log(player_health);
    }
}
