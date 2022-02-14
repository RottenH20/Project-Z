using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGhost : MonoBehaviour
{
    public GameObject fireball;
    private Animator animGhost;
    private Vector3 ghostLocation;  // Store temporary location of ghost and adjust for instantiate of fireball
    // Start is called before the first frame update
    void Start()
    {
        animGhost = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            buttonLPressed();
        }
    }

    public void buttonLPressed()
    {
        animGhost.Play("Base Layer.Ghost_Teleport_Exit", 0, 0);
    }

    public void ghostAnimationEnded()
    {
        transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 2.5f, Random.Range(-20.0f, 20.0f));
        ghostLocation = transform.position;
    }

    public void ghostInstatiateAttack()
    {
        ghostLocation.x += 2f;
        ghostLocation.y += 2.5f;
        Instantiate(fireball, ghostLocation, transform.rotation);
    }
}
