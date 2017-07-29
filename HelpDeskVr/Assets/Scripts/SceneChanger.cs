using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    [SerializeField]
    GameObject leaderboard;
    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    Transform upPoint;
    [SerializeField]
    Transform centerPoint;
    [SerializeField]
    Transform downPoint;

    bool leaderboardActive;
    public float speed = 0.001f;

    public void Update()
    {
        if (leaderboardActive)
        {
            leaderboard.SetActive(true);
            if (Vector3.Distance(mainMenu.transform.position, upPoint.position) < 1.0f)
            {
                mainMenu.SetActive(false);
            }
        }
        if (!leaderboardActive)
        {
            if (mainMenu)
            {
                mainMenu.SetActive(true);
                if (Vector3.Distance(leaderboard.transform.position, downPoint.position) < 1.0f)
                {
                    leaderboard.SetActive(false);
                }
            }
        }

        if (leaderboardActive && (Vector3.Distance(leaderboard.transform.position, centerPoint.position) > 1.0f))
        {
            leaderboard.transform.position = Vector3.Lerp(leaderboard.transform.position, centerPoint.position, Time.deltaTime * speed);
            mainMenu.transform.position = Vector3.Lerp(mainMenu.transform.position, upPoint.position, Time.deltaTime * speed);
        }
        else if (!leaderboardActive && (Vector3.Distance(mainMenu.transform.position, centerPoint.position) > 1.0f))
        {

            leaderboard.transform.position = Vector3.Lerp(leaderboard.transform.position, downPoint.position, Time.deltaTime * speed);
            mainMenu.transform.position = Vector3.Lerp(mainMenu.transform.position, centerPoint.position, Time.deltaTime * speed);
        }
    }

	public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
        //StartCoroutine(ChangeSceneCoroutine(index));
    }

    IEnumerator ChangeSceneCoroutine(int index)
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        
        yield return null;
    }

    public void Leaderboard()
    {
        leaderboardActive = true;
    }

    public void MainMenu()
    {
        leaderboardActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
