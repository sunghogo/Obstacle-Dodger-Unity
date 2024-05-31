using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float MovementSpeed {get; set;}
    public float RotationSpeed {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 30f;
        RotationSpeed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) Move(Vector3.forward);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) Move(Vector3.back);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) Rotate(new Vector3(0, -15, 0));
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) Rotate(new Vector3(0, 15, 0));
    }

    private void Move(Vector3 vector) {
        transform.Translate(vector * Time.deltaTime * MovementSpeed);
    }

    private void Rotate(Vector3 vector) {
        transform.Rotate(vector * Time.deltaTime * RotationSpeed);
    }
}   
