using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private Text coinsLabel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timerLabel.text = FormatTime (GameManager.Instance.TimeRemaining);
        coinsLabel.text = GameManager.Instance.NumCoins.ToString.ToString();
	}

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0} : {1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }
}
