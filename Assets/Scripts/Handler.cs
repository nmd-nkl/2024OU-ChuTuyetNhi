using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Handler : MonoBehaviour
{
    #region Movement

    //public Rigidbody2D rb;
    //public Transform m_transform;
    //public float _speed = 0.7f;

    public GameObject gameObj;
    //public Rigidbody2D m_rigidbody2D;
    private void Start()
    {
        Copy();
        //Debug.Log(gameObj.transform.position);
        //Debug.Log(gameObj.transform.localPosition);
        //Debug.Log(gameObj.transform.parent.name);
    }
    private void Update()
    {
        //this.transform.position = this.transform.position + new Vector3(0.1f, 0);
        //MoveForwardObj();
        //LerpObj();
        //RigidBodyMove();
        Debug.Log("move");
    }
    void MoveForwardObj()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 0.1f);
    }
    void LerpObj()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, 0), 0.1f);
    }
    void RigidBodyMove()
    {
        //m_rigidbody2D.velocity = new Vector2(4, 7);
        //m_rigidbody2D.AddForce(new Vector2(4, 7));
    }
    void Copy()
    {
        GameObject obj = Instantiate(gameObj, transform);
    }
    #endregion
}
