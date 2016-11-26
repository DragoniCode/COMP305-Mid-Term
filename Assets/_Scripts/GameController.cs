using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;

    // PRIVATE 
    private int _missesValue;
    private int _scoreValue;

    //Properties
    public int MissesValue
    {
        get
        {
            return this._missesValue;
        }

        set
        {
            this._missesValue = value;
            if (this._missesValue <= 0)
            {
                this._endGame();
            }
            else {
                this.Misses.text = "Hull Point: " + this._missesValue + "/5";
            }
        }
    }
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            if (this._scoreValue >= 100)
            {
                this._endGame();
            }
            else
            {
                this.Score.text = "Score: " + this._scoreValue + "/100";
            }
        }
    }

    [Header("UI Objects")]
    public Text Misses;
    public Text Score;
    public Text GameOver;
    public Text FinalScore;
    public Button RestartButton;


    // Use this for initialization
    void Start () {
		this._GenerateEnemies ();
        //reactivate/reset objects
        this.MissesValue = 5;
        this.ScoreValue = 0;
        this.enemy.SetActive(true);
        this.GameOver.gameObject.SetActive(false);
        this.FinalScore.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //Restart button function
    public void RestartButton_Click()
    {
        //reloads scene
        SceneManager.LoadScene("Main");
    }
    // generate Clouds
    private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    private void _endGame()
    {
        // all these need to be set to this state at game end for end instance
        this.GameOver.gameObject.SetActive(true);
        Debug.Log(this.ScoreValue);
        this.FinalScore.text = "Final Score: " + this.ScoreValue;
        this.FinalScore.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.Score.gameObject.SetActive(false);
        this.Misses.gameObject.SetActive(false);
        this.enemy.SetActive(false);
    }
}
