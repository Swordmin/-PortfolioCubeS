using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{

    [SerializeField] private TMP_InputField _field;

    public void OpenClose(GameObject panel)
    {
        panel.SetActive(panel.activeSelf ? false : true);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GetBlockCountInStart() 
    {
        WorldSettings.startCubeCount = Convert.ToInt32(_field.text);
    }

}
