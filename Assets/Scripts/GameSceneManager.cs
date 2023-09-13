using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
	#region Unity Fields
	public Camera mainCamera;
	public Text scoreText;
	public Text gameOverText;
	public PlayerController player;
	#endregion Unity Fields

	#region Fields
	private int score;
	private float gameTimer;
	private bool gameOver;
	#endregion Fields

	#region Methods
	public void Start ()
	{
		Time.timeScale = 1;

		player.OnHitGoomba += OnHitGoomba;
		player.OnHitSpike += OnGameOver;
		player.OnHitOrb += OnGameWin;

        scoreText.enabled = true;
        gameOverText.enabled = false;
        
	}

	public void Update ()
	{
		// Stick camera to player
		mainCamera.transform.position = new Vector3
		(
			Mathf.Lerp(mainCamera.transform.position.x, player.transform.position.x, Time.deltaTime * 10),
			Mathf.Lerp(mainCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 10),
			mainCamera.transform.position.z
		);

		if (gameOver)
		{
			if (Input.GetKeyDown("r"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			return;
		}

		gameTimer += Time.deltaTime;

		scoreText.text = "Time: " + Mathf.Floor(gameTimer);

		if (player.transform.position.y < -10) OnGameOver();
	}

	private void OnHitGoomba ()
	{
		this.score += 100;
	}

	private void OnGameOver ()
	{
		gameOver = true;

		scoreText.enabled = false;
		gameOverText.enabled = true;

		gameOverText.text = "Game over!\nTime: " + Mathf.Floor(gameTimer) + "\nPress R to restart";

		Time.timeScale = 0;
	}

	private void OnGameWin ()
	{
		gameOver = true;

		scoreText.enabled = false;
		gameOverText.enabled = true;

		gameOverText.text = "You win!\nTime: " + Mathf.Floor(gameTimer) + "\nPress R to restart";

		Time.timeScale = 0;
	}
	#endregion Methods
}