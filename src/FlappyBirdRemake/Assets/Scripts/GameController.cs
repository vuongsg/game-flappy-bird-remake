using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameScene;
    public GameObject startPanel;
    public GameObject helpPanel;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI bestPointText;
    public bool isPlaying;

    private int point;
    private bool isAnyPanelEnabled;
    private static int maxPoint = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        isPlaying = false;
        point = 0;
        bestPointText.text = "Best: " + maxPoint;
        UpdatePointText();

        Show(false, true, false);
        isAnyPanelEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnyPanelEnabled)
            return;

		if (Input.GetKey(KeyCode.F1))
        {
            Time.timeScale = 0f;
            Show(false, false, true);
        }
    }

    private void Show(bool showGameScene, bool showStartPanel, bool showHelpPanel)
    {
        gameScene.SetActive(showGameScene);
        startPanel.SetActive(showStartPanel);
        helpPanel.SetActive(showHelpPanel);
    }

    public void StartButton_Click()
    {
        StartGame();
    }

    private void StartGame()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Show(true, false, false);
        isAnyPanelEnabled = false;
        Time.timeScale = 1f;
        isPlaying = true;
    }

    public void GetPoint()
    {
        point++;
        UpdatePointText();
    }

    public void EndGame()
    {
		Time.timeScale = 0f;
        isPlaying = false;
		maxPoint = Mathf.Max(maxPoint, point);
        StartCoroutine(DoWait());
    }

    private IEnumerator DoWait()
    {
        yield return new WaitForSecondsRealtime(4);
        RestartGame();
	}

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void HelpButton_Click()
    {
        Show(false, false, true);
        isAnyPanelEnabled = true;
    }

    public void BackFromHelpPanel()
    {
        if (isPlaying)
        {
            Show(true, false, false);
            isAnyPanelEnabled = false;
            Time.timeScale = 1f;
        }
        else
        {
            Show(false, true, false);
            startPanel.SetActive(true);
            isAnyPanelEnabled = true;
        }
    }

    private void UpdatePointText()
    {
		pointText.text = "Point: " + point;
	}

	public void QuitButton_Click()
	{
#if UNITY_STANDALONE
		Application.Quit();
#endif
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
