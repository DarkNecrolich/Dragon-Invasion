using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed = 2f;
    public Animator anim;
    public GameObject cam;
    public GameObject fireball;

    void Awake()
    {
        if (GameObject.FindWithTag("MainCamera") && GameObject.FindWithTag("MainCamera") != cam)
        {
            Destroy(cam);
        }

        if (GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player") != gameObject)
        {
            Destroy(gameObject);
        }
       
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(cam);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject fb;
            fb = Instantiate(fireball, new Vector2(transform.position.x, transform.position.y - 0.5f ), Quaternion.identity);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, -45);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, 45);
                }
                else
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, -135);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, 135);
                }
                else
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
               
            }
            else
            {

                if (transform.localScale.x == -1)
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                else if (transform.localScale.x == 1)
                {
                    fb.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }

        }

        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            rb.velocity = new Vector2(MoveSpeed * 0.6f * Input.GetAxisRaw("Horizontal"), MoveSpeed * 0.6f * Input.GetAxisRaw("Vertical"));
        }
        else
        {
            rb.velocity = new Vector2(MoveSpeed * Input.GetAxisRaw("Horizontal"), MoveSpeed * Input.GetAxisRaw("Vertical"));
        }
        

        if((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")))
        {
            anim.SetBool("Walking", true);
        }

        else if((Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            anim.SetBool("Walking", false);
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(-1,1);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }


    }
}
