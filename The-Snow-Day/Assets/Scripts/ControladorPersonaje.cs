using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    public float LongitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    private bool estoyEnSuelo;
    public Rigidbody2D rBjugador;

    //public Animator animator; a
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBjugador = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;
        //animator.SetFloat("movement", velocidadX * velocidad);

        //if (velocidadX > 0)
        //{

        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        //if (velocidadX < 0) { transform.localScale = new Vector3(1, 1, 1); }

        Vector3 position = transform.localPosition;

        transform.position = new Vector3(velocidadX + position.x, position.y, position.z);

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, capaSuelo);

        estoyEnSuelo = hit2D.collider != null;


        if (estoyEnSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rBjugador.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            Debug.Log("se presiono");
        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LongitudRaycast);
    }



}
