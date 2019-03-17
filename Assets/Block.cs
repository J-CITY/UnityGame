using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    public enum BlockType { Simple = 0, Rotate, MoveUpDown, MoveLeftRight, MoveFrontBack};

    public BlockType type = BlockType.Simple;

    float moveDir = 10.0f;
    const float dist = 1.0f;
    float moveSpeed = 10.0f;
    float sX, sY, sZ;
    
    void Start()
    {
        sX = transform.position.x;
        sY = transform.position.y;
        sZ = transform.position.z;
    }
    
    void Update()
    {
        float dt = Time.deltaTime;
        if (type == BlockType.Rotate)
        {
            transform.Rotate(new Vector3(dt* moveSpeed, 0.0f, 0.0f));
        } else if (type == BlockType.MoveUpDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+moveDir*dt * moveSpeed/100.0f, transform.position.z);
            if ((moveDir > 0 && transform.position.y > dist+sY) || (moveDir < 0 && transform.position.y < -dist + sY))
            {
                moveDir *= -1.0f;
            }
        }
        else if (type == BlockType.MoveLeftRight)
        {

        }
        else if (type == BlockType.MoveFrontBack)
        {

        }
    }
}
