using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float ThurstForce = 1f;
    Rigidbody2D rb;
    public float score = 0f;
    public float scoreMultiplier = 10f;
    public GameObject booster;
    public AudioSource audio;
    private float elapsedTime = 0f;
    public UIDocument uIDocument;
    private Label scoreText;
    public GameObject explotionEffects;
    private Button restartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uIDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uIDocument.rootVisualElement.Q<Button>("Restart_Button");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += Restartscene;  
    }   

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();
        
        
    }
    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score:    " + score;
    }
    void MovePlayer()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousepos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * ThurstForce);

        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            booster.SetActive(true);
            audio.Play();
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            booster.SetActive(false);
            audio.Pause();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explotionEffects, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
        
    }
    void Restartscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
