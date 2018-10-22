using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private float _timeRemaining;

    public float TimeRemaining
    {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }
    }

    private float maxTime = 2 * 60; // In seconds.

    private int maxHealth = 5;

    private bool isInvulnerable = false;

    private int totalCoinsInLevel;

    private bool gameOver = false;

    private int _numCoins;

    public int NumCoins 
    {
        get { return _numCoins; }
        set { _numCoins = value; }
    }

    private float _playerHealth;

    public float PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    private void OnEnable()
    {
        DamagePlayerEvent.OnDamagePlayer += DecrementPlayerHealth;
    }

    private void OnDisable()
    {
        DamagePlayerEvent.OnDamagePlayer -= DecrementPlayerHealth;
    }

    // Use this for initialization
    void Start()
    {
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;

        totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0)
        {
            Restart();
        }

        if (_numCoins == totalCoinsInLevel && !gameOver)
        {
            StartCoroutine (WonGame());
        }
    }

    private void DecrementPlayerHealth(GameObject player)
    {
        if (isInvulnerable)
        {
            return;
        }

        StartCoroutine(InvulnerableDelay ());

        PlayerHealth--;

        if (PlayerHealth <= 0)
        {
            //Restart Game
            Restart ();
        }
    }

    public void Restart()
    {
        {
            SceneManager.LoadScene("MainGame");
            TimeRemaining = maxTime;
            PlayerHealth = maxHealth;
        }
    }

    private IEnumerator WonGame()
    {
        gameOver = true;
        FindObjectOfType<UpdateUI>().wonGamePanel.SetActive(true);
        yield return new WaitForSeconds(3);
        GameManager.Instance.Restart();
    }

    private IEnumerator InvulnerableDelay()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
    }

    public float GetPlayerHealthPercentage()
    {
        return PlayerHealth / (float)maxHealth;
    }

}
