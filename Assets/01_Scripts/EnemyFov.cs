using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    public float viewRange = 15.0f;
    public float viewAngle = 120.0f;
    new Rigidbody rigidbody;

    private Transform enemyTr;
    private Transform playerTr;
    private int playerLayer;
    private int obstacleLayer;
    private int layerMask;
    
    // Start is called before the first frame update
    void Start()
    {


        enemyTr = GetComponent<Transform>();
        //playerTr = GameObject.FindGameObjectWithTag("PLYAER").transform;

        playerLayer = LayerMask.NameToLayer("PLAYER");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        layerMask = 1 << playerLayer | 1 << obstacleLayer;
    }
    public Vector3 CirclePoint(float angle)
    {
        //���� ��ǥ�� �������� �����ϱ� ���� ���� Yȸ���� ���� 
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        //���� �ݰ� ���� �ȿ��� ĳ���� ����
        Collider[] cols = Physics.OverlapSphere(enemyTr.position
                                               , viewRange
                                               , 1 << playerLayer);

        //�迭 ���� 1�� �� ĳ���Ͱ� ���� ���� �ִٰ� �Ǵ�
        if(cols.Length ==1)
        {
            //���� ĳ�� ���� ���� ���� ���
            Vector3 dir = (playerTr.position - enemyTr.position).normalized;

            //�� �þ߰��� ���Դ��� �Ǵ�
            if(Vector3.Angle(enemyTr.forward, dir)<viewAngle *0.5f)
            {
                isTrace = true;
            }
        }

        return isTrace;
         
    }
    public bool isViewPlayer()
    {
        bool isView = false;
        RaycastHit hit;

        //���� ĳ�� ���� ���� ���� ���
        Vector3 dir = (playerTr.position - enemyTr.position).normalized;

        //����ĳ��Ʈ �����ؼ� ��ֹ� �ִ��� ���� �Ǵ�
        if(Physics.Raycast(enemyTr.position, dir, out hit, viewRange, layerMask))
        {
            isView = (hit.collider.CompareTag("PLAYER"));
        }
        return isView;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "PLAYER")
    //    {            
    //        Debug.Log("�浹");

    //        Destroy(collision.gameObject);

    //        gameResultOver.alpha = 1f;
    //        Time.timeScale = 0;
    //        gameResultOver.interactable = true;


    //    }

    //}
    // Update is called once per frame
    void Update()
    {
        ////rigidbody.velocity = Vector3.zero;
        ////rigidbody.angularVelocity = Vector3.zero;
    }
}
