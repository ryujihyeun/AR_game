using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;

    private Rigidbody rigid;
    public float jumpPower;

    private SystemManager systemManager = null;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        GameObject tmp = GameObject.Find("SystemManager");
        systemManager = tmp.GetComponent<SystemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.transform.forward * speed * Time.deltaTime, Space.World);

        if (-3.0f > gameObject.transform.position.y)
        {
            Destroy(gameObject);
            systemManager.numOut -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            Destroy(gameObject);
            systemManager.CountSuccessNum();
        }

        if(collision.gameObject.CompareTag("Pad"))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        if(collision.gameObject.CompareTag("Map"))
        {
            RaycastHit hitInfo;
            Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 0.04f);
            if ("Map" == hitInfo.collider.tag)
            {
                transform.rotation *= Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
