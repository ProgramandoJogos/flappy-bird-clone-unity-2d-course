using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rb2D;
    public float JumpForce;
    public AudioSource JumpAudioSource;
    public AudioSource DieAudioSource;
    public AudioSource ScoreAudioSource;
    private InputAction Jump;
    private GameController GameController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jump = InputSystem.actions.FindAction("Jump");
        GameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Jump.triggered)
        {
            Rb2D.linearVelocity = Vector2.zero;
            Rb2D.AddForce(Vector2.up * JumpForce);
            JumpAudioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!enabled)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            GameController.OnPlayerDie();
            DieAudioSource.Play();
            return;
        }


        if (collision.gameObject.CompareTag("Pipe"))
        {
            GameController.OnPlayerDie();
            DieAudioSource.Play();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Score"))
        {
            GameController.OnPlayerScore();
            ScoreAudioSource.Play();
            return;
        }
    }

}
