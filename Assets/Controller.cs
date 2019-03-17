using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class GameParams
{
    public static string text { get; set; }
    public static int count { get; set; }
}

public class Controller : MonoBehaviour
{
    private Rigidbody rb;

    public int count = 0;
    public Text countText;
    public bool isDead = false;
    public bool isWin = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countText.text = "Count: " + count.ToString();
    }
    
    float fullJump = 0.0f;
    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);

        fullJump = 0.0f;
        if (jump)
        {
            if (!isJump && !isDJump)
            {
                isJump = true;
                fullJump = 450.0f;
            }
            else if (isJump && !isDJump)
            {
                isDJump = true;
                fullJump = 250.0f;
            }
        }
    }
    public GameObject cam;
    bool isJump = false;
    bool isDJump = false;
    float speed = 15.0f;
    void FixedUpdate()
    {

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 newRight = Vector3.Cross(Vector3.up, cam.transform.forward);
        Vector3 newForward = Vector3.Cross(newRight, Vector3.up);
        Vector3 _movement = (newRight * moveH) + (newForward * moveV);

        Vector3 movement = new Vector3(
            _movement.x * speed, 
            fullJump,
            _movement.z * speed);

        rb.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();
        }

        //Debug.Log(collision.gameObject.CompareTag("Coin").ToString());
        isJump = false;
        isDJump = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "LevelWorld")
        {
            isDead = true;

            GameParams.text = "YOU LOSE!";
            GameParams.count = count;
            SceneManager.LoadScene("Menu");
        }

        if (collision.gameObject.name == "FinishBlock")
        {
            isWin = true;
            GameParams.text = "YOU WIN!";
            GameParams.count = count;
            SceneManager.LoadScene("Menu");
        }
    }
}
