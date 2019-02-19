using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPuppeteer : MonoBehaviour 
{
    [HideInInspector] public bool derecha = true;
    [HideInInspector] public bool salto = true;

    public int Fuerza = 10;
    public int Velocidad = 1;
    public Transform Colision;

    private bool alPiso = false;
    private Rigidbody2D rb;
    private bool muerte = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 escala = new Vector2(1,1);

        if (Input.GetKey(KeyCode.Return))
            transform.localScale += escala * 2 * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.005f)
            Saltar();
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bing") 
        {
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Obstaculo>().Monedita();
        }
    }
}
