using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
using GoogleARCore.Examples.Common;
public class RoomSelectedSize : MonoBehaviour
{
    public int RoomSize;

    public Button RoomSizeBtn;

    public Canvas canv1;
    public GameObject canv2;

    public GameObject prefabWall;

    // Start is called before the first frame update
    void Start()
    {
        RoomSizeBtn.onClick.AddListener(RoomSizeFun);
    }

    void RoomSizeFun()
    {
        canv1.enabled = false;
        canv2.SetActive(false);


        // prefabWall.SetActive(true);
        // GameObject a = Instantiate(prefabWall, new Vector3(0,0,0), Quaternion.identity);
    }

    private void Update()
    {
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
        TrackableHitFlags.FeaturePointWithSurfaceNormal;
        GameObject ARObject;

        if (Frame.Raycast(transform.position.x, transform.position.y, raycastFilter, out hit))
        {
           
                if ((hit.Trackable is DetectedPlane) && Vector3.Dot(Camera.main.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) < 0)
                {
                    Debug.Log("Hit at back of the current DetectedPlane");
                }
                else
                {
                Vector3 position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, hit.Pose.position.z);
              //  Vector3 position = new Vector3(0, 0, 0);
                Quaternion rotation = new Quaternion(0f, 0f, 0f, 1f);
                    ARObject = Instantiate(prefabWall, hit.Pose.position, hit.Pose.rotation);
                    ARObject.transform.Rotate(-90, 0, 0, Space.Self);
                    var anchor = Session.CreateAnchor(new Pose(position, rotation));
                    ARObject.transform.parent = anchor.transform;
                }
        }
    }
}