using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI coinCount;
    private int _kill;
    private int _coin;
    private const string CoinCountKey = "CoinCount";
    private void OnEnable()
    {
        Boomerang.OnEnemyDied += Boomerang_OnEnemyDied;
        PlayerTriggerController.OnCoinCollected += PlayerTriggerController_OnCoinCollected;
    }
    
    private void OnDisable()
    {
        PlayerTriggerController.OnDied -= Boomerang_OnEnemyDied;
        PlayerTriggerController.OnCoinCollected -= PlayerTriggerController_OnCoinCollected;
    }

    private void Start()
    {
        _coin = PlayerPrefs.GetInt(CoinCountKey, 0);
    }

    private void Update()
    {
        UpdateUI();
    }

    private void Boomerang_OnEnemyDied()
    {
        _kill++;
    }
    private void PlayerTriggerController_OnCoinCollected()
    {
        _coin++;
        PlayerPrefs.SetInt(CoinCountKey, _coin);
        PlayerPrefs.Save();
    }
    

    private void UpdateUI()
    {
        killCount.text = _kill.ToString();
        coinCount.text = _coin.ToString();
    }
}
