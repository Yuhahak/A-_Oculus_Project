using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Creator : MonoBehaviour
{
    public ARRaycastManager raycastManager; //AR레이캐스트 매니저
    public GameObject arPrefab; //AR프리팹
    private GameObject arObject; //생성되는 AR오브젝트


    private void Update()
    {
        CreateARObject();
    }

    void CreateARObject() //터치한 지점에서 AR오브젝트를 생성하는 함수
    {
        //휴대폰 터치 개수가 0개보다 클 때
        if(Input.touchCount > 0)
        {
            //가장 먼저 터치되는 터치 정보(0번)을 touch에 반환한다.
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                //생성된 AR오브젝트가 없을 때
                if (!arObject)
                {
                    //AR 포인트 클라우드 숨김
                    var points = raycastManager.GetComponent<ARPointCloudManager>().trackables;
                    foreach (var pts in points)
                    {
                        pts.gameObject.SetActive(false);
                    }
                    raycastManager.GetComponent<ARPointCloudManager>().enabled = false;

                    //AR 플레인 숨김
                    var planes = raycastManager.GetComponent<ARPlaneManager>().trackables;
                    foreach (var pls in planes)
                    {
                        pls.gameObject.SetActive(false);
                    }
                    raycastManager.GetComponent<ARPlaneManager>().enabled = false;

                    //AR프래팹을 생성하여 첫번째 터치 지점의 위치와 회전값으로 초기화한다.
                    arObject = Instantiate(arPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    //터치한 지점으로 생성된 AR오브젝트를 재배치한다.
                    arObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
        }
    }

            
}



