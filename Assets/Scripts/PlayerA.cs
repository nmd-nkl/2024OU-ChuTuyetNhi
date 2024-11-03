using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
{
    #region Vong-Doi
    //Vong doi Obj
    private void Awake()
    {
        Debug.Log("Awake!");
        //Khi doi tuong duoc khoi tao
        //Nen khi Doi Tuong bi tat r enable lai thi ham nay KHONG duoc goi
    }
    private void OnEnable()
    {
        Debug.Log("Enable");
        //Khi doi tuong duoc kich hoat
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        //Chay Sau Awake()
        //Goi khi bat dau doi tuong
    }

    void Update() //Dua vao FPS may
    {
        //Debug.Log("Update");
        //Khi dc enable moi duoc Goi
        //Goi Lien Tuc Theo 1 khoang thoi gian (frame: time.deltatime)
    }
    private void FixedUpdate()
    { //0.02s
        Debug.Log(Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {

    }
    private void OnDisable()
    {
        Debug.Log("Disable");
        //khi bi tat di
    }

    #endregion
    #region Physics
    //Ca 2 deu phai co Collider
    //1 Trong 2 phai co Physics: Rigid
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        Debug.Log(other.gameObject.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }

    #endregion
}
