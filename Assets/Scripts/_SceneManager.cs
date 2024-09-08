using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class _SceneManager : MonoBehaviour
{
    //フェイド実装可能
    private string _sceneName;
    [SerializeField]float taime;

    public void Load(string sceneName)
    {
        _sceneName = sceneName;
        Invoke("LoadScene", taime);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
