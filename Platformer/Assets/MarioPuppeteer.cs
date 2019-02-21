using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPuppeteer : MonoBehaviour 
{
    [HideInInspector] public bool derecha = true;
    [HideInInspector] public bool salto = true;

    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;

    public int Fuerza = 10;
    public int Velocidad = 1;
    public Transform Colision;

    private bool alPiso = false;
    private Rigidbody2D rb;
    public static bool muerte = false;

    private int direction;
    private float posX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;

        direction = 1;
        posX = transform.position.x;
    }

    void Update()
    {
        Vector3 escala = new Vector2(1, 1);

        if (Input.GetKey(KeyCode.Return))
            transform.localScale += escala * 2 * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.005f)
            Saltar();

        if (transform.position.x < posX)
        {
            if (direction == -1)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
                direction = -1;
            }
        }
        else
        {
            if (direction == -1)
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
                direction = 1;
            }


        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (moveHorizontal, 0);
        rb.AddForce (movement * Velocidad);
        
    }

    private void Saltar()
    {
        rb.AddForce(Vector2.up * Fuerza, ForceMode2D.Impulse);
    }
    
    public void ChaoChaoBambino()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Whoreny")
        {
            muerte = true;
            GetDownNow();
        }


        if (collision.gameObject.tag == "ComAtmeBro")
        {
            if (muerte)
            {
                Destroy(collision.gameObject);
                collision.gameObject.GetComponent<ShotBro>().Estrellita();
            }
        }

    }

    void GetDownNow()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }

    }


}
