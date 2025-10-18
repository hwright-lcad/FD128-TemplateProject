using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        StartCoroutine(SceneLoadTimer(0));
    }
    public void StartGame()
    {
        StartCoroutine(SceneLoadTimer(0));
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    IEnumerator SceneLoadTimer(int scene)
    {
        float timer = 0f;
        float duration = 1f;
        while(timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            float lerp = timer / duration;

            blackScreen.color = Color.Lerp(Color.clear, Color.black, lerp);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.8f);
        SceneManager.LoadScene(scene);
    }
}
