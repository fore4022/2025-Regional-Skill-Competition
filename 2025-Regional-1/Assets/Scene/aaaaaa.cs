using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaaaa : MonoBehaviour
{
    // Start is called before the first frame update

    public Material nn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SkinnedMeshRenderer ������Ʈ�� �����ɴϴ�
        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // ���� ��Ƽ���� �迭�� �����ؼ� �����ɴϴ� (����: ���� smr.materials[0] = xxx �̷��Դ� �ϸ� �ȵ˴ϴ�!)
            Material[] mats = smr.materials;

            // ���� ���, �� ��° ��Ƽ������ ���ο� ��Ƽ����� ��ü�ϰ� �ʹٸ�:
            mats[1] = nn; // newMaterial�� �ٲٰ� ���� Material�Դϴ�

            // ����� �迭�� �ٽ� �Ҵ��մϴ�
            smr.materials = mats;
        }

    }
}
