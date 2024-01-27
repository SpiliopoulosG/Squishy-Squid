using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private bool gameOn = false;


    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameOn) {
                return;
            } 
        
            if (Time.timeScale == 1) {
                Pause();
            } else {
                Play();
            }
        }
    }


    private void Awake() {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;
    }

    public void Play() {
        gameOn = true;
        score = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i=0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore() {
        score ++;
        scoreText.text = score.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameOn = false;
        Pause();
    }
}
