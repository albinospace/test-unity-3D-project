using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    private Camera cam;

    void Start () {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}



    void OnGUI()
    {
        int size = 14;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size*2, size*2), "+");
    }

    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Reacting target = hitObject.GetComponent<Reacting>();
                if (target != null)
                {
                    target.React();
                }
                else
                {
                    StartCoroutine(Indicator(hit.point));
                }
                StartCoroutine(Indicator(hit.point));
            }
        }
	}

    private IEnumerator Indicator(Vector3 pos) 
    {
       GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
