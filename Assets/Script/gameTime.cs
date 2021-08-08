using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTime : MonoBehaviour
{
    public TextMesh textMesh;
    public inWater inWater;
    public int ccss = 5;
    float time = 0;
    bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
            time += Time.deltaTime;
        string ts = time + "";
        ts = ts.IndexOf(".") < 0 ? ts + "s" : ts.Substring(0, ts.IndexOf(".") + 2) + "s";
        textMesh.text = ts;
    }
    private void OnCollisionEnter(Collision other) {
        if (inWater.suc >= ccss && other.collider.tag == "Player")
        {
            Debug.Log("YES");
            end = true;
        }
    }
}
