using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRunning : MonoBehaviour
{
    public float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    IEnumerator Animate() {
        while (true) {
            MoveForward();
            yield return new WaitForSeconds(3);
            ChangeDirection();
            yield return new WaitForSeconds(1);
        }
    }

    void MoveForward() {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }

    void ChangeDirection() {
        transform.localRotation *= Quaternion.Euler(0, 180, 0);
    }
}
