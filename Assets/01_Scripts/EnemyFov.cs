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
        //로컬 좌표계 기준으로 설정하기 위해 적의 Y회전값 더함 
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        //추적 반경 범위 안에서 캐릭터 추출
        Collider[] cols = Physics.OverlapSphere(enemyTr.position
                                               , viewRange
                                               , 1 << playerLayer);

        //배열 개수 1일 때 캐릭터가 범위 내에 있다고 판단
        if(cols.Length ==1)
        {
            //적과 캐릭 사이 방향 벡터 계산
            Vector3 dir = (playerTr.position - enemyTr.position).normalized;

            //적 시야각에 들어왔는지 판단
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

        //적과 캐릭 사이 방향 벡터 계산
        Vector3 dir = (playerTr.position - enemyTr.position).normalized;

        //레이캐스트 투시해서 장애물 있는지 여부 판단
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
    //        Debug.Log("충돌");

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
