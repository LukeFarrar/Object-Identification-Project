using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSounds : MonoBehaviour
{
    AudioSource impactSound = null;
    AudioSource rollingSound = null;

    bool rolling = false;
    // Start is called before the first frame update
    void Start()
    {
        //Add an AudioSource component and set up some defaults
        impactSound = gameObject.AddComponent<AudioSource>();
        impactSound.playOnAwake = false;
        impactSound.spatialize = true;
        impactSound.spatialBlend = 1.0f;
        impactSound.dopplerLevel = 0.0f;
        impactSound.rolloffMode = AudioRolloffMode.Logarithmic;
        impactSound.maxDistance = 20f;

        rollingSound = gameObject.AddComponent<AudioSource>();
        rollingSound.playOnAwake = false;
        rollingSound.spatialize = true;
        rollingSound.spatialBlend = 1.0f;
        rollingSound.dopplerLevel = 0.0f;
        rollingSound.rolloffMode = AudioRolloffMode.Logarithmic;
        rollingSound.maxDistance = 20f;
        rollingSound.loop = true;

        //Load the sphere sounds from the resources folder
        impactSound.clip = Resources.Load<AudioClip>("impact");
        rollingSound.clip = Resources.Load<AudioClip>("rolling");
    }

    //Occurs when this object starts colliding with another object
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= 0.1f)
        {
            impactSound.Play();
        }
    }

    //Occurs each frame that this object continues to collide with another object
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rigid = gameObject.GetComponent<Rigidbody>();

        //Play a rolling sound if the sphere is rolling fast enough.
        if (!rolling && rigid.velocity.magnitude >= 0.01f)
        {
            rolling = true;
            rollingSound.Play();
        }

        //Stop the rolling sound if the rolling slows down.
        else if (rolling && rigid.velocity.magnitude < 0.01f)
        {
            rolling = false;
            rollingSound.Stop();
        }
    }

    //Occurs when this object stops colliding with another object
    private void OnCollisionExit(Collision collision)
    {
        //Stop the rolling sound if the object falls off and stops colliding.
        if(rolling)
        {
            rolling = false;
            impactSound.Stop();
            rollingSound.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
