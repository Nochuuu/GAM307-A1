using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI timerLabel;

    [SerializeField]
    private TextMeshProUGUI coinsLabel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timerLabel.text = FormatTime (GameManager.Instance.TimeRemaining);
        coinsLabel.text = GameManager.Instance.NumCoins.ToString();
	}

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0} : {1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }
}
