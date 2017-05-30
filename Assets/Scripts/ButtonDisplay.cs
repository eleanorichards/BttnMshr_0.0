using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonDisplay : MonoBehaviour {
    //timer bar object
    public Image timer_bar;

    //button display object
    public Image button_display;

    private attackManager p_attackManager;
    //buttons
    public Sprite _button_A;
    public Sprite _button_B;
    public Sprite _button_X;
    public Sprite _button_Y;

    public string current_button = "";

    public float max_time = 100.0f;

    private float cur_time = 0.0f;
    private float calc_time = 0.0f;


	// Use this for initialization
	void Start ()
    {
        p_attackManager = gameObject.GetComponent<attackManager>();
        cur_time = max_time;
        SetButtonSprite();
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        DecreaseTimer();
    }

    public void ResetTimer(int _consecutive_presses)
    {
       switch (_consecutive_presses)
        {
            case 1:
            cur_time = max_time;
                break;
            case 2:
                cur_time = max_time * 0.8f;
                break;
            case 3:
                cur_time = max_time * 0.7f;
                break;
            case 4:
                cur_time = max_time * 0.6f;
                break;
            case 5:
                cur_time = max_time * 0.5f;
                break;
            case 6:
                cur_time = max_time * 0.4f;
                break;
            case 7:
                cur_time = max_time * 0.3f;
                break;
            case 8:
                cur_time = max_time * 0.2f;
                break;
            case 9:
                cur_time = max_time * 0.15f;
                break;
            case 10:
                cur_time = max_time * 0.1f;
                break;
            default:
                cur_time = max_time;
                break;
        }
        SetButtonSprite();
    }


    void DecreaseTimer()
    {
        if(cur_time != 0)
        {
            cur_time--;
            calc_time = cur_time / max_time;
        }
        else
        {
            SetButtonSprite();
            p_attackManager.resetCombo();
            ResetTimer(0);
        }
        SetTime(calc_time);
    }


    void SetButtonSprite()
    {
        int num = UnityEngine.Random.Range(0, 4);

        switch(num)
        {
            case 0:
                button_display.sprite = _button_A;
                current_button = "A";
                break;
            case 1:
                button_display.sprite = _button_B;
                current_button = "B";
                break;
            case 2:
                button_display.sprite = _button_X;
                current_button = "X";
                break;
            case 3:
                button_display.sprite = _button_Y;
                current_button = "Y";
                break;
        }

    }


    void SetTime(float _timer_amount)
    {
        timer_bar.fillAmount = _timer_amount;
    }
}
