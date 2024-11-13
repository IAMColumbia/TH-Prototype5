using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    private int _score;
    private float _spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0; 
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
    }

}
