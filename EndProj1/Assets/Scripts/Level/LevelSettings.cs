using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSettings : MonoBehaviour
{

    public static LevelSettings Settings;

    public float Time { get;  private set; }
    public float BestTime { get;  private set; }
    public float CoinCount { get; private set; }

    private bool _pause;

    [SerializeField] private TextMeshProUGUI _textTime;
    [SerializeField] private TextMeshProUGUI _textCoinCount;
    public string TimeText => _textTime.text;
    public string CoinCountText => _textCoinCount.text;

    public List<IPause> Pauses = new List<IPause>();

    private void Awake()
    {
        StartCoroutine(Timer());
        if (!Settings)
            Settings = this;
    }

    public void TakeCoin(float count) 
    {
        if (count < 0)
        {
            Debug.LogError("SFS ERROR: value must be positive");
            return;
        }
        CoinCount += count;
        _textCoinCount.text = CoinCount.ToString();
    }

    public void StopTimer() 
    {
        StopCoroutine("Timer");
    }
    public void Pause() 
    {
        if(_pause)
        {
            PauseObjects(false);
            _pause = false;
        }
        else
        {
            PauseObjects(true);
            _pause = true;
        }
    }

    private void PauseObjects(bool isPause) 
    {
        foreach (IPause pauseObject in Pauses)
        {
            if (isPause)
                pauseObject.Pause();
            else
                pauseObject.Resume();
        }
    }

    private IEnumerator Timer() 
    {
        int minute = 00;
        int seconts = 00;
        while (true) 
        {
            yield return new WaitForSeconds(1);
            Time++;
            seconts++;
            _textTime.text = $"{minute}:{seconts}";
            if(seconts == 60)
            {
                minute++;
                seconts = 0;
            }

        }
    }


}
