using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TMPro;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    public GameObject gameOverObject;
    private bool countdown;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10 * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, 0, speed);
        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        float vertMove = Input.GetAxisRaw("Vertical") * speed;
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                // unpausing
                Time.timeScale = 1;
                pauseObject.SetActive(false);
                gameOverObject.SetActive(false);
            }

            else
            {
                // pausing
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countdown = true;
            gameOverObject.SetActive(true);
        }

        if (countdown)
        {
            if (timer < 3)
            {
                // timer stuff
                timer += Time.deltaTime;
            }

            else
            {
                // Application.Quit()
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0, newZ);
        score++;
        scoreText.text = "Score: " + score;
        Debug.Log("Score is now: " + score);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Still in the trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exit the trigger");
    }
}
