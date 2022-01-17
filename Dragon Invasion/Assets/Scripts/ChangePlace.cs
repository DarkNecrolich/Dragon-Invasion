using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePlace : MonoBehaviour
{
    public Vector2 destino;
    public int cena;
    public GameObject lvLoader;
    public string butt;

    void Awake()
    {
        lvLoader = GameObject.Find("Level Loader");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            if((butt == "Up" && Input.GetKey(KeyCode.UpArrow)) || (butt == "Down" && Input.GetKey(KeyCode.DownArrow)) || (butt == "Left" && Input.GetKey(KeyCode.LeftArrow)) || (butt == "Right" && Input.GetKey(KeyCode.RightArrow)))
            {
                lvLoader.GetComponent<LevelLoader>().LoadLevel(cena);
                Col.gameObject.transform.position = destino;
            }
            
           
        }
    }
}
