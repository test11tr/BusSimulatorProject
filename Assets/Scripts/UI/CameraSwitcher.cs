using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;
    private void Start()
    {
        ChangeCam1();
    }
    public void ChangeCam1()
    {
        currentView = views[0];
    }

    public void ChangeCam2()
    {
        currentView = views[1];
    }
    public void ChangeCam3()
    {
        currentView = views[2];
    }
    public void ChangeCam4()
    {
        currentView = views[3];
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
        transform.eulerAngles = currentAngle;
    }
}
