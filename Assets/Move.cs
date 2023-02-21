using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    public int onGround=0;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    private bool countdown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        onGround = 0;
        countdown = false;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        float speed = .05f;

        float horizMove = Input.GetAxisRaw("Horizontal") * speed; 
        float vertMove = Input.GetAxisRaw("Vertical") * speed; 
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("space");
            if (Time.timeScale == 0) { 
                Time.timeScale = 1;
                pauseObject.SetActive(false);
                Debug.Log("reach");
            } else { 
                Time.timeScale = 0; 
                pauseObject.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countdown= true;
        }
        if(countdown)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, onGround, newZ);
        score++; 
        Debug.Log("Score is now: " + score);
        scoreText.text = "Score: " + score;
    }
}
