using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", 1.0f);
        }
        else if (translation < 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", -1.0f);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
