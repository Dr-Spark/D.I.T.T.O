﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTemp : MonoBehaviour
{
    private GameObject sword;
    public string typeSword;

    private Player hero;

    private int facing;
    //2 = up (showing the back)
    //3 = left 
    //0  = down
    //1 = right

    void Start()
    {
        sword = transform.Find(typeSword).gameObject;
        hero = transform.parent.GetComponent<Player>();

        //Deactivate the sword
        sword.SetActive(false);
    }

    void Update()
    {

        if ((hero.h > 0 || hero.h < 0) && (hero.v < 0 || hero.v > 0))
        {
            if (hero.v > 0)
            {
                facing = 2;
            }
            else if (hero.v < 0)
            {
                facing = 0;
            }
        }
        else if ((hero.h > 0 || hero.h < 0) && hero.v == 0)
        {
            if (hero.h < 0)
            {
                facing = 3;
            }
            else if (hero.h > 0)
            {
                facing = 1;
            }
        }
        else if ((hero.v > 0 || hero.v < 0) && hero.h == 0)
        {
            if (hero.v > 0)
            {
                facing = 2;
            }
            else if (hero.v < 0)
            {
                facing = 0;
            }
        }


        transform.rotation = Quaternion.Euler(0, 0, 90 * facing);

        //transform.position = new Vector3(0, 0, 0);

        sword.SetActive(hero.mode == Player.eMode.attack && facing != 2);

        //1 = right = (0.2, -0.15)  (0.067, -0.05)
        //3 = left = (0.2, 0.15)  (0.1167, -0.05)
        //0 = down = (0, -0.35)  (0, -0.1167)
        //2 = up = (0, 0.035)  (0, 0.01167)

        if (facing == 1)
        {
            transform.position = new Vector3(0.3f, -0.18f, 0) + hero.transform.position;
        }
        else if (facing == 2)
        {
            transform.position = new Vector3(0, 0.06f, 0) + hero.transform.position;
        }
        else if (facing == 3)
        {
            transform.position = new Vector3(-0.3f, -0.13f - 0.05f, 0) + hero.transform.position;
        }
        else if (facing == 0)
        {
            transform.position = new Vector3(0, -0.42f, 0) + hero.transform.position;
        }

    }

}