using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI coinCount;
    private int _kill;
    private int _coin;
    
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
        UpdateUI();
    }

    private void Boomerang_OnEnemyDied()
    {
        _kill++;
        UpdateUI();
    }
    private void PlayerTriggerController_OnCoinCollected()
    {
        _coin++;
        UpdateUI();
    }
    

    private void UpdateUI()
    {
        killCount.text = _kill.ToString();
        coinCount.text = _coin.ToString();
    }
}
