using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public Text NameText;
    public Text BestScoreText; 

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;
    public static int bestScore;
    public string userName;

    // Start is called before the first frame update
    void Start()
    {
        userName = GameManager.Instance.playerName;
        NameText.text = $"Player: {userName}";
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        CheckBestPlayer(); 
        GameOverText.SetActive(true);
    }

    private int GetScore()
    {
        int endingScore = m_Points;
        return endingScore;
    }


    // compare the current score to the previous score (bestscore) loaded (if any) 
    // if the current score is greater than the previous score
    // then have the currentscore become the best score 
    // otherwise leave the previous score as the best score
    public void CheckBestPlayer()
    {
        // IF PLAYER BEATS HIGH SCORE, SAVE THEIR NAME
        // DEFAULT VALUE OF INSTANCE IS 0
        if (m_Points > GameManager.Instance.bestScore)
        {
            GameManager.Instance.bestScore = GetScore();
            GameManager.Instance.bestPlayer = GameManager.Instance.playerName;

            GameManager.Instance.SaveBest(GameManager.Instance.bestPlayer, GameManager.Instance.bestScore);

            BestScoreText.text = $"Best Score: {GameManager.Instance.bestScore}";
            Debug.Log("New High Score: " + GameManager.Instance.bestScore);
        }
    }
}