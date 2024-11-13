using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    
    public TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    public bool isGameActive;
    private int _score;
    private float _spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0; 
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate); 
            int index = Random.Range(0, targets.Count); 
            Instantiate(targets[index]);
        }
    }

    /// <summary> 
    /// Updates the current score by adding the specified value and updates the score display text. 
    /// </summary>
    /// <param name="scoreToAdd">
    public void UpdateScore(int scoreToAdd) 
    { 
        _score += scoreToAdd; 
        _scoreText.text = "Score: " + _score; 
    }

    public void GameOver() 
    { 
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}
