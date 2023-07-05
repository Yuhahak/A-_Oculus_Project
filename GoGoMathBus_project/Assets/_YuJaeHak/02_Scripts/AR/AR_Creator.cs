using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Creator : MonoBehaviour
{
    public ARRaycastManager raycastManager; //AR����ĳ��Ʈ �Ŵ���
    public GameObject arPrefab; //AR������
    private GameObject arObject; //�����Ǵ� AR������Ʈ


    private void Update()
    {
        CreateARObject();
    }

    void CreateARObject() //��ġ�� �������� AR������Ʈ�� �����ϴ� �Լ�
    {
        //�޴��� ��ġ ������ 0������ Ŭ ��
        if(Input.touchCount > 0)
        {
            //���� ���� ��ġ�Ǵ� ��ġ ����(0��)�� touch�� ��ȯ�Ѵ�.
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                //������ AR������Ʈ�� ���� ��
                if (!arObject)
                {
                    //AR ����Ʈ Ŭ���� ����
                    var points = raycastManager.GetComponent<ARPointCloudManager>().trackables;
                    foreach (var pts in points)
                    {
                        pts.gameObject.SetActive(false);
                    }
                    raycastManager.GetComponent<ARPointCloudManager>().enabled = false;

                    //AR �÷��� ����
                    var planes = raycastManager.GetComponent<ARPlaneManager>().trackables;
                    foreach (var pls in planes)
                    {
                        pls.gameObject.SetActive(false);
                    }
                    raycastManager.GetComponent<ARPlaneManager>().enabled = false;

                    //AR�������� �����Ͽ� ù��° ��ġ ������ ��ġ�� ȸ�������� �ʱ�ȭ�Ѵ�.
                    arObject = Instantiate(arPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    //��ġ�� �������� ������ AR������Ʈ�� ���ġ�Ѵ�.
                    arObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
        }
    }

            
}



