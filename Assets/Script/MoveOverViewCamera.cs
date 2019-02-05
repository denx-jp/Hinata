using UnityEngine;
using System.Collections;

public class MoveOverViewCamera : MonoBehaviour
{
    public GameObject camera;
    bool push_up = false;
    bool push_down = false;
    bool push_right = false;
    bool push_left = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (push_up)
        {
            MoveUp();
        }
        if (push_right)
        {
            MoveRight();
        }
        if (push_down)
        {
            MoveDown();
        }
        if (push_left)
        {
            MoveLeft();
        }

    }
    public void PushUp_Up()
    {
        push_up = true;
    }
    public void PushUp_Down()
    {
        push_up = false;
    }
    public void PushDown_Up()
    {
        push_down = true;
    }
    public void PushDown_Down()
    {
        push_down = false;
    }
    public void PushRight_Up()
    {
        push_right = true;
    }
    public void PushRight_Down()
    {
        push_right = false;
    }
    public void PushLeft_Up()
    {
        push_left = true;
    }
    public void PushLeft_Down()
    {
        push_left = false;
    }



    public void MoveUp()
    {
        Vector3 spd = camera.transform.position;
        spd.z += 1f;
        camera.transform.position = spd;
    }
    public void MoveDown()
    {
        Vector3 spd = camera.transform.position;
        spd.z -= 1f;
        camera.transform.position = spd;
    }
    public void MoveRight()
    {
        Vector3 spd = camera.transform.position;
        spd.x += 1f;
        camera.transform.position = spd;
    }
    public void MoveLeft()
    {
        Vector3 spd = camera.transform.position;
        spd.x -= 1f;
        camera.transform.position = spd;
    }
}
