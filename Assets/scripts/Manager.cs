using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform camera;
    public Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < points.Length; i++)
            points[i].GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var i in points)
        {
            i.GetChild(0).transform.rotation = Quaternion.Slerp(i.GetChild(0).transform.rotation, camera.rotation, Time.deltaTime * 10);
        }
    }

    public void Log(string str)
    {
        string[] splitArray = str.Split(char.Parse("-"));
        var value = splitArray[1];

        int.TryParse(value, out int result);


        for (int i = 0; i < points.Length; i++)
        {
            if(i == result)
                points[i].GetComponent<Renderer>().enabled = true;
            else

                points[i].GetComponent<Renderer>().enabled = false;
        }

        var rot = Quaternion.Euler(points[result].rotation.eulerAngles.x, camera.transform.eulerAngles.y, points[result].rotation.eulerAngles.z);
        camera.parent.transform.SetPositionAndRotation(points[result].position, rot);
    }
}
