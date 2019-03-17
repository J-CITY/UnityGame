using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapCreator : MonoBehaviour
{
    public GameObject block;
    public GameObject coin;
    public GameObject finish;

    void Start()
    {
        string path = "Assets/lvl0.txt";

        StreamReader reader = new StreamReader(path);
        string lvlStr = reader.ReadToEnd();
        reader.Close();

        string[] words = lvlStr.Split(new char[] { '\n' });

        int i = 0;
        foreach (string w in words) {
            string[] param = w.Split(new char[] { ':' });

            GameObject b = Instantiate(block, new Vector3(Convert.ToInt32(param[0]) * 10.0f,
                Convert.ToInt32(param[1]) * 1.5f, Convert.ToInt32(param[2]) * 10.0f), Quaternion.identity);
            b.GetComponent<Block>().type = (Block.BlockType)Convert.ToInt32(param[3]);

            i++;
            if (i == words.Length)
            {
                GameObject temp = Instantiate(finish, new Vector3(Convert.ToInt32(param[0]) * 10.0f,
                    Convert.ToInt32(param[1]) * 1.5f + 1.5f, Convert.ToInt32(param[2]) * 10.0f), Quaternion.identity);
                temp.name = "FinishBlock";

            } else if (i != 1)
            {
                Instantiate(coin, new Vector3(Convert.ToInt32(param[0]) * 10.0f,
                Convert.ToInt32(param[1]) * 1.5f + 1.5f, Convert.ToInt32(param[2]) * 10.0f), Quaternion.identity);

            }
        }
    }
    
    void Update()
    {
        
    }
}
