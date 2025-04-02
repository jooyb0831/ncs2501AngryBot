using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCBullet : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000f);
        //일정 시간이 지난 후에 총알을 삭제
        Destroy(this.gameObject, 3.0f);    
    }

    void OnCollisionEnter(Collision collision)
    {
        //충돌 지점 추출
        var contact = collision.GetContact(0);
        //충돌 지점에 스파크 이펙트 생성
        var obj = Instantiate(effect, contact.point, Quaternion.LookRotation(-contact.normal));

        Destroy(obj, 2.0f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
