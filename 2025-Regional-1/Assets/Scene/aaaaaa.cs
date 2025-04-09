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
        // SkinnedMeshRenderer 컴포넌트를 가져옵니다
        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 현재 머티리얼 배열을 복사해서 가져옵니다 (주의: 직접 smr.materials[0] = xxx 이렇게는 하면 안됩니다!)
            Material[] mats = smr.materials;

            // 예를 들어, 두 번째 머티리얼을 새로운 머티리얼로 교체하고 싶다면:
            mats[1] = nn; // newMaterial은 바꾸고 싶은 Material입니다

            // 변경된 배열을 다시 할당합니다
            smr.materials = mats;
        }

    }
}
