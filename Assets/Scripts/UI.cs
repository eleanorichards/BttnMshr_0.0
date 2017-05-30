using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    private Text score_text = null;

    private attackManager p_attack_manager;
	// Use this for initialization
	void Start () {
        score_text = gameObject.GetComponentInChildren<Text>();
        p_attack_manager = gameObject.GetComponent<attackManager>();

    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(p_attack_manager.attack_value.ToString());
        score_text.text = p_attack_manager.GetAttackValue().ToString();
	}
}
