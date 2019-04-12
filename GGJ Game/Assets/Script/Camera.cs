using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public Transform Trans_Target; 

    private float flo_MoveSpeed = 5;
    private float flo_TargeteMax;
    private float flo_TargeteMin;

    public void Awake()
    {
        Trans_Target = GameObject.Find("Cat").transform; 
    }

    public void Update()
    {
        Vector3 Vector3_Position = Trans_Target.position - this.transform.position;
        this.transform.position += new Vector3(Vector3_Position.x , Vector3_Position.y , 0); 
    }
}
