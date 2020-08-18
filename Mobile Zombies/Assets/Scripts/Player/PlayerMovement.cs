using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool selected = false;

    public Vector3 newPosition;

    public float speed = 1.0f;

    private float startTimer;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        newPosition = hit.point;
                        journeyLength = Vector3.Distance(transform.position, newPosition);
                        moveToPosition(newPosition);
                    }
                    else
                    {
                        print("You can't mvoe there");
                    }
                        
                }


            }
        }
    }

    public void beenSelected()
    {
        selected = true;
        print("I have been selected");
    }

    private void moveToPosition(Vector3 finalPosition)
    {
        float distCovered;
        float fractionOfJourney;
        while (transform.position != finalPosition)
        {
            distCovered = (Time.time - startTimer) * speed;
            fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, finalPosition, fractionOfJourney);
        }
    }

}
