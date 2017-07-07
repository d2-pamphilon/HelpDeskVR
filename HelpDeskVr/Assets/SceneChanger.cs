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


    float speed = 10.0f;

	public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Leaderboard()
    {
        StartCoroutine(moveUp());
    }

    public void MainMenu()
    {
        StartCoroutine(moveDown());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator moveUp()
    {
        while (Vector3.Distance(leaderboard.transform.position, centerPoint.position) > 1.0f)
        {
            leaderboard.transform.position = Vector3.Lerp(leaderboard.transform.position, centerPoint.position, Time.deltaTime * speed);
            mainMenu.transform.position = Vector3.Lerp(mainMenu.transform.position, upPoint.position, Time.deltaTime * speed);
        }
        yield return null;
    }

    IEnumerator moveDown()
    {
        while (Vector3.Distance(mainMenu.transform.position, centerPoint.position) > 1.0f)
        {
            leaderboard.transform.position = Vector3.Lerp(leaderboard.transform.position, downPoint.position, Time.deltaTime * speed);
            mainMenu.transform.position = Vector3.Lerp(mainMenu.transform.position, downPoint.position, Time.deltaTime * speed);
        }
        yield return null;
    }


}
