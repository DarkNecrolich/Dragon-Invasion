using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed = 2f;
    public Animator anim;
    public GameObject cam;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
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
