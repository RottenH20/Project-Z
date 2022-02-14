using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCrystal : MonoBehaviour
{
    public Animator animCrystal;
    // Start is called before the first frame update
    void Start()
    {
        animCrystal = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            buttonPPressed();
        }
    }

    public void buttonPPressed()
    {
        animCrystal.Play("Base Layer.Crystal_Knight_Attack_Right", 0, 0);
    }

    public void crystalKnightAnimationEnded()
    {
        transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
    }
}
