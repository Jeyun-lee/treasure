using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyFov))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyFov fov = (EnemyFov)target;

        Vector3 fromAnglePos = fov.CirclePoint(-fov.viewAngle * 0.5f);

        Handles.color = new Color(1,1,1,0.2f);

        Handles.DrawWireDisc(fov.transform.position //원점좌표
                             , Vector3.up  //노멀 벡터
                             , fov.viewRange);  //원의 반지름

        //부채꼴 색상 지정
        Handles.DrawSolidArc(fov.transform.position//원점좌표
                            , Vector3.up //노멀 벡터
                            , fromAnglePos //부채꼴 시작 좌표
                            , fov.viewAngle //부채꼴 각도
                            , fov.viewRange); //부채꼴 반지름

        //시야각의 텍스트를 표시
        Handles.Label(fov.transform.position + (fov.transform.forward * 2.0f)
                                               , fov.viewRange.ToString());


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
