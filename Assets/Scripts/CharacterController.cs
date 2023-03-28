using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform rayStart;

    private Animator anim;

    private Rigidbody rb;
    private bool walkingRight = true;

    private GameManager GM;

    public GameObject crystalEffect;

    public float OriginalSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GM = FindObjectOfType<GameManager>();
        OriginalSpeed = anim.speed;
    }

    private void FixedUpdate()
    {
        if (!GM.GameStarted)
            return;
        else
            anim.SetTrigger("gameStarted");

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime * (GM.Score/25f + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.InputDetected() && GM.GameStarted)
            Switch();

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
            anim.SetTrigger("IsFalling");
        else
            anim.SetTrigger("NotFalling");

        if(transform.position.y < -2)
        {
            GM.EndGame();
            GameManager.firstSpace = true;
        }
    }

    private void Switch()
    {
        if (!GameManager.firstSpace)
        {
            walkingRight = !walkingRight;

            if (walkingRight)
                transform.rotation = Quaternion.Euler(0, 45, 0);
            else
                transform.rotation = Quaternion.Euler(0, -45, 0);
        }

        else
            GameManager.firstSpace = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            GM.IncreaseScore();
            GameObject g = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);
            anim.speed += GM.Score / 25f;
        }
    }
}
