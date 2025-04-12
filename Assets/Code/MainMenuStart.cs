using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuStart : MonoBehaviour
{
    void Start()
    {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
