using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float initialSpeed = 10;
    public float boxSpeed = 5;
    private Rigidbody2D _compRigidbody2D;
    public int directionX;
    public int directionY;
    public int puntuacion = 0;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip sonidoPasos;
    public AudioClip sonidoRecibirDano;
    public int life = 3;
    private UIManager uiManager;
    public Color damageColor = Color.red; 

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateHearts(life);
    }

    void Update()
    {
        Debug.Log(life);
        bool isMoving = false;

        if (Input.GetKey(KeyCode.D))
        {
            directionX = 1;
            animator.SetFloat("MoveX", directionX);
            animator.SetFloat("MoveY", directionY);
            animator.SetBool("Moving", true);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            directionX = -1;
            animator.SetFloat("MoveX", directionX);
            animator.SetFloat("MoveY", directionY);
            animator.SetBool("Moving", true);
            isMoving = true;
        }
        else
        {
            directionX = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            directionY = 1;
            animator.SetFloat("MoveY", directionY);
            animator.SetFloat("MoveX", directionX);
            animator.SetBool("Moving", true);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            directionY = -1;
            animator.SetFloat("MoveY", directionY);
            animator.SetFloat("MoveX", directionX);
            animator.SetBool("Moving", true);
            isMoving = true;
        }
        else
        {
            directionY = 0;
        }

        if (directionX == 0 && directionY == 0)
        {
            animator.SetBool("Moving", false);
        }

        if (isMoving)
        {
            if (!audioSource.isPlaying || audioSource.clip != sonidoPasos)
            {
                audioSource.clip = sonidoPasos;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip == sonidoPasos)
            {
                audioSource.Stop();
                audioSource.clip = null;
                audioSource.loop = false;
            }
        }

        if (puntuacion >= 3)
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(initialSpeed * directionX, initialSpeed * directionY);
    }

    public void RecibirDano(int cantidad)
    {
        life -= cantidad;
        StartCoroutine(DamageEffectCoroutine());
        if (sonidoRecibirDano != null)
        {
            audioSource.PlayOneShot(sonidoRecibirDano);
        }

        uiManager.UpdateHearts(life);

        if (life <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene("Nivel2");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BOX")
        {
            initialSpeed = boxSpeed;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BOX" || collision.gameObject.tag == "Wall")
        {
            initialSpeed = 10f;
        }
    }
    public void ApplyDamageEffect()
    {
        StartCoroutine(DamageEffectCoroutine());
    }

    IEnumerator DamageEffectCoroutine()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }
}
