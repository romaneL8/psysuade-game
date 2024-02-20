using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    private TransitionFader _endTransitionPrefab;

    // initialize references
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    //private IEnumerator WinRoutine()
    //{
    //    TransitionFader.PlayTransition(_endTransitionPrefab);

    //    float fadeDelay = (_endTransitionPrefab != null) ?
    //        _endTransitionPrefab.Delay + _endTransitionPrefab.FadeOnDuration : 0f;

    //    yield return new WaitForSeconds(fadeDelay);
    //    WinScreen.Open();
    //}
}
