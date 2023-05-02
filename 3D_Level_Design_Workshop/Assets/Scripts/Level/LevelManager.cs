using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    private Vector3 spawnPoint;
    [SerializeField]
    int coinScore = 0;

    // ~ Coin List ~
    private List<TriggerObject> coinList = new List<TriggerObject>(); 

    [SerializeField]
    TMP_Text coinScoreText;
    [SerializeField]
    TMP_Text levelDoneCoinScoreText;

    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitLevel();
    }

    public void SubscribeTriggerObject(TriggerObject _to)
    {
        if(_to.GetTriggerObjType == E_TriggerObjectType.Coin)
        {
            if (!coinList.Contains(_to))
                coinList.Add(_to);
        }
        UpdateUICoinScore();
    }


    public void InitLevel()
    {
        
    }

    public void LevelDone()
    {
        Debug.Log("Level Done!");
        UpdateLevelDoneUICoinScore();
    }

    public void CollectCoin()
    {
        coinScore++;
        UpdateUICoinScore();
    }

    private void UpdateUICoinScore()
    {
        coinScoreText.text = coinScore + " / " + coinList.Count;
    }

    private void UpdateLevelDoneUICoinScore()
    {
        levelDoneCoinScoreText.text = coinScore + " / " + coinList.Count;
    }


    private void LoadNextLevel()
    {

    }
}
