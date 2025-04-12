using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float score;
    public float levelSpeed = 3f;

    [SerializeField]private GameObject player;
    [SerializeField]private GameObject playerDead;
    [SerializeField]private GameObject tutorialScreen;
    [SerializeField]private GameObject scoreScreen;
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private Button restartButton;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField]private TextMeshProUGUI finalScoreText;

    [SerializeField]private float speedIncreaseRate;

    private bool gameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //DontDestroyOnLoad(gameObject);

        restartButton.onClick.AddListener(Restart);
    }

    private void Start()
    {
        tutorialScreen.SetActive(true);
        scoreScreen.SetActive(true);
    }

    private void Update()
    {
        if(!gameOver)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }

        if(levelSpeed > -22f && !gameOver)
        {
            levelSpeed -= Time.deltaTime * speedIncreaseRate;
        }
    }

    public void GameOver()
    {
        player.SetActive(false);
        playerDead.transform.position = player.transform.position;
        playerDead.SetActive(true);
        levelSpeed = 0f;
        gameOver = true;
        finalScoreText.text = ((int)score).ToString();
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
