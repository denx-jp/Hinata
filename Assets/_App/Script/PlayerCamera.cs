using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    public static GameObject Target;
    public static float Speed = 5.0f;
    public static float Distance;
    private GameObject CameraCenter;
    private Vector3 Direction;

    // Use this for initialization
    void Start()
    {
        Target = GameObject.Find("DefaultCameraCenter");
        CameraCenter = transform.root.gameObject;
        Direction = Vector3.Normalize(transform.position - CameraCenter.transform.position);
        Distance = Vector3.Distance(CameraCenter.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraCenter.transform.position = Vector3.Lerp(CameraCenter.transform.position, Target.transform.position, Time.deltaTime * Speed);
        transform.position = Vector3.Lerp(transform.position, CameraCenter.transform.position + Direction * Distance, Time.deltaTime * Speed);
    }
}
