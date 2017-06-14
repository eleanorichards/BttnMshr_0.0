using UnityEngine;
using System.Collections;
using System;

public class attackManager : MonoBehaviour {

    private ButtonDisplay p_button_display = null;
    
    public string button_pressed = "";
    public string input_string;

    private int consecutive_presses = 0;
    public float attack_value = 0;

	// Use this for initialization
	void Start () {
        p_button_display = gameObject.GetComponent<ButtonDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
        if (getKeyPressed())
        {
            button_pressed = p_button_display.current_button;
            processInput();
        } 
    }


    private bool getKeyPressed()
    {
        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            input_string = "A";
            return true;
        }
       else  if (Input.GetKeyDown("joystick 1 button 1"))
        {
            input_string = "B";
            return true;
        }
        else if (Input.GetKeyDown("joystick 1 button 2"))
        {
            input_string = "X";
            return true;
        }
        else if (Input.GetKeyDown("joystick 1 button 3"))
        {
            input_string = "Y";
            return true;
        }
       
        else
        {
            return false;
        }
    }


    void processInput()
    {
        getKeyPressed();
        if (input_string == button_pressed)
        {
            consecutive_presses++;
            p_button_display.ResetTimer(consecutive_presses);
        }
        else
        {
            consecutive_presses = 0;
            p_button_display.ResetTimer(consecutive_presses);
        }
        Debug.Log(consecutive_presses);
    }


    public float GetAttackValue()
    {
        switch(consecutive_presses)
        {
            case 0:
                attack_value = 5;
                break;
            case 1:
                attack_value = 10;
                break;
            case 2:
                attack_value = 20;
                break;
            case 3:
                attack_value = 35;
                break;
            case 4:
                attack_value = 50;
                break;
            case 5:
                attack_value = 70;
                break;
            case 6:
                attack_value = 90;
                break;
            case 7:
                attack_value = 110;
                break;
            case 8:
                attack_value = 130;
                break;
            case 9:
                attack_value = 140;
                break;
            case 10:
                attack_value = 160;
                break;
            default:
                attack_value = 0;
                break;
        }
        return attack_value;
    }


    public void resetCombo()
    {
        consecutive_presses = 0;
    }


    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            if (getKeyPressed())
            {
                Debug.Log("Attacked");
                col.gameObject.SendMessage("DecrementHealth", GetAttackValue());
            }
        }
    }
}
