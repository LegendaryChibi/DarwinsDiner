using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private VideoPlayer vp;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private AudioSource music;

    private void OnEnable()
    {
        mainUI.SetActive(true);
        music.Play();
        credits.SetActive(false);
        cutscene.SetActive(false);
    }

    private void Start()
    {
        //vp.loopPointReached += CheckOver;
    }

    public void PlayGame()
    {
        cutscene.SetActive(true);
        mainUI.SetActive(false);
        vp.loopPointReached += CheckOver;
        music.Pause();
    }

    public void PlayCredits()
    {
        credits.SetActive(!credits.active);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void CheckOver(VideoPlayer videoPlayer)
    {
        cutscene.SetActive(false);
        SceneManager.LoadScene("MultiMouse");

    }
}
