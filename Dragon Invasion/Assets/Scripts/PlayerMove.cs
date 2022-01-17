using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed = 2f;
    public Animator anim;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        rb.velocity = new Vector2(MoveSpeed * Input.GetAxisRaw("Horizontal"), MoveSpeed * Input.GetAxisRaw("Vertical"));
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
