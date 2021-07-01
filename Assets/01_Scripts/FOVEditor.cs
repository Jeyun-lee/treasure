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

        Handles.DrawWireDisc(fov.transform.position //������ǥ
                             , Vector3.up  //��� ����
                             , fov.viewRange);  //���� ������

        //��ä�� ���� ����
        Handles.DrawSolidArc(fov.transform.position//������ǥ
                            , Vector3.up //��� ����
                            , fromAnglePos //��ä�� ���� ��ǥ
                            , fov.viewAngle //��ä�� ����
                            , fov.viewRange); //��ä�� ������

        //�þ߰��� �ؽ�Ʈ�� ǥ��
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
