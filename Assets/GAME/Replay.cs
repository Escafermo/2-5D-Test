using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {

    private const int bufferFrames = 300;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager gameManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.isRecording)
        {
            Record();
        } else
        {
            PlayBack();
        }
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames; //Int between 0 and 100
        float timeSinceStarted = Time.time;
        //print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(timeSinceStarted, transform.position, transform.rotation);
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames; //Int between 0 and 100
        //print("Reading frame " + frame);
        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;
    }
}


/// <summary>
/// A structure for storing time, rotation and position of Game Objects
/// </summary>
public struct MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float aTime, Vector3 aPos, Quaternion aRotation)
    {
        time = aTime;
        pos = aPos;
        rot = aRotation;
    }
}