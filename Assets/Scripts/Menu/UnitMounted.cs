using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMounted : MonoBehaviour
{
    public GameObject[] place = new GameObject[5];
    public static List<GameObject> mountingUnit = new List<GameObject>();

    public static bool isMounting;

    List<GameObject> units = new List<GameObject>();

    public GameObject warningSpace; // 공간 부족 메시지

    public GameObject warningInUse; // 중복 장착 메시지
    public static GameObject inUse; 

    private void OnEnable()
    {
        isMounting = false;
        inUse = warningInUse;
    }
    
    public void Mounting(GameObject unit)
    {
        mountingUnit.Add(unit);
        isMounting = true;
    } 

    public void SetMounting()
    {
        if (isMounting)
        {
            if (mountingUnit.Count > 5)
            {
                isMounting = false;
                GameObject ui = GameObject.Find("UI");
                Instantiate(warningSpace, ui.transform);
                mountingUnit.RemoveAt(5);
                return;
            }
            units.RemoveRange(0, units.Count);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < place[i].transform.childCount; j++)
                {
                    Destroy(place[i].transform.GetChild(j).gameObject);
                }
            }

            for (int i = 0; i < mountingUnit.Count; i++)
            {
                units.Add(Instantiate(mountingUnit[i], place[i].transform)); 
                RectTransform unitTr = units[i].GetComponent<RectTransform>();
                unitTr.sizeDelta = new Vector2(200, 200);
                unitTr.localPosition = new Vector2(0, 0);
            }
            isMounting = false;
        }
        
    }
    void Update()
    {
        SetMounting();
    }
}
