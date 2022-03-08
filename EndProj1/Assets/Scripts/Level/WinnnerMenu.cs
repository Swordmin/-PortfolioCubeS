using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnnerMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _coinCountText;
    [SerializeField] private Animator _animator;

    public void Show() 
    {
        LevelSettings.Settings.StopTimer();
        LevelSettings.Settings.Pause();
        _animator.Play("Show"); 
        _timerText.text = LevelSettings.Settings.TimeText;
        _coinCountText.text = LevelSettings.Settings.CoinCount.ToString();
    }



}
