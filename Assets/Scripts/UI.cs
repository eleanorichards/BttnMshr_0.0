using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    private Text score_text = null;

    private attackManager p_attack_manager;

    void Start () {
        score_text = GameObject.Find("HUD/Player1_Score").GetComponent<Text>();
        p_attack_manager = gameObject.GetComponent<attackManager>();
        //checking score text exists
        if(score_text)
        {
            score_text.text = "HI";
        }
        else
        {
            Debug.Log("text box not found");
        }

    }

    // Update is called once per frame
    void Update () {
        //Update score text each frame with player score
        score_text.text = p_attack_manager.GetAttackValue().ToString();
	}
}
