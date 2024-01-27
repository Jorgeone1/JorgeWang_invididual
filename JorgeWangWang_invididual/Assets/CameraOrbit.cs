using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 angle= new Vector2(90 * Mathf.Deg2Rad,0);
    [SerializeField]private Transform follow;
    [SerializeField]private float distancia;
    [SerializeField] private Vector2 sensibility;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
           if(hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensibility.x;
        }
        float ver = Input.GetAxis("Mouse Y");
        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensibility.y;
            angle.y = Mathf.Clamp(angle.y,-80 * Mathf.Deg2Rad,80 * Mathf.Deg2Rad);
        }

    }
    private void LateUpdate()
    {
        Vector3 orbit = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );
        transform.position = follow.position + orbit * distancia;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    } 
}
