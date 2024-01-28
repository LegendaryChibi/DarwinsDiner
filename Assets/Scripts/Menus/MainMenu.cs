using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{


    [SerializeField] private GameObject panel;

    public void PlayGame()
    {
        //SceneManager.LoadScene("MultiMouse");
    }

    public void PlayCredits()
    {
        panel.SetActive(!panel.gameObject.active);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
