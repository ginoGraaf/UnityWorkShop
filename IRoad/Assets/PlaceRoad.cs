using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRoad : MonoBehaviour
{
    [SerializeField]
    GameObject FirstObj;
    [SerializeField]
    GameObject PlaceRoadPrefab;
    Vector3 LastObjectPos;
    [SerializeField]
    Vector3 NewPos;
    const int roadAmount= 100;

    List<GameObject> roadObj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        roadObj.Add(FirstObj);
        LastObjectPos = FirstObj.transform.position;
        StartCoroutine(BuildRoad());
    }
    private void Update()
    {
        DeleteFirstRoadObj();
    }

    void DeleteFirstRoadObj()
    {
        if(roadObj.Count>=roadAmount)
        {
            GameObject road = roadObj[0];
            roadObj.RemoveAt(0);
            Destroy(road);
        }
    }

    IEnumerator BuildRoad()
    {
        Vector3 setNewPos = new Vector3(LastObjectPos.x + NewPos.x, LastObjectPos.y + NewPos.y, LastObjectPos.z + NewPos.z);
        GameObject road = Instantiate(PlaceRoadPrefab) as GameObject;
        road.transform.position = setNewPos;
        LastObjectPos = road.transform.position;
        roadObj.Add(road);
        yield return new WaitForSeconds(2f);
        StartCoroutine(BuildRoad());
    }
}
