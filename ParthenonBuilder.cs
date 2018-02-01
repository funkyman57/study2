using System.Linq;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour {

    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public float FloorWidth = 5.0f;
    public float FloorDepth = 10.0f;
    public float FloorHeight = 0.25f;
    public float PillarRadius = 0.2f;
    public float PillarHeight = 2.0f;
    public float PillarCountWidth = 6.0f;
    public float PillarCountDepth = 10.0f;
    public float RoofHeight = 1.0f;
    public Material FloorMaterial;
    public Material PillarMaterial;
    public Material RoofMaterial;
    public float k = 0.95f;

    void Start () {
        Debug.Log("Start()");
    }

    [ContextMenu("Parthenon Build")]
    void Build()
    {

        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }

        var newGameObject = Instantiate(cubePrefab, transform);
        var tr = newGameObject.transform;
        tr.localPosition = new Vector3(0, 0, 0);
        tr.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);

        var newGameObject2 = Instantiate(cubePrefab, transform);
        var tr2 = newGameObject2.transform;
        tr2.localPosition = new Vector3(0, FloorHeight, 0);
        tr2.localScale = new Vector3(FloorWidth*k, FloorHeight, FloorDepth*k);

        var newGameObject3 = Instantiate(cubePrefab, transform);
        var tr3 = newGameObject3.transform;
        tr3.localPosition = new Vector3(0, FloorHeight*2, 0);
        tr3.localScale = new Vector3(FloorWidth*k*k, FloorHeight*2, FloorDepth*k*k);

        var newGameObject4 = Instantiate(cubePrefab, transform);
        var tr4 = newGameObject4.transform;
        tr4.localPosition = new Vector3(0, FloorHeight*2+PillarHeight, 0);
        tr4.localScale = new Vector3(FloorWidth*k*k, RoofHeight, FloorDepth*k*k);

        float FirstWidth = FloorWidth*0.95f*0.95f / 2 * k * k - 0.2f;
        float FirstDepth = FloorDepth*0.95f*0.95f / 2 * k * k - 0.2f;
        float WidthSize = (FloorWidth * 0.95f * 0.95f - 0.4f) / 6;
        float DepthSize = (FloorDepth * 0.95f * 0.95f - 0.4f) / 10;

        for (int i=0; i < 10; i++)
        {
            var newGameObjecti = Instantiate(cylinderPrefab, transform);
            var tri = newGameObjecti.transform;
            tri.localPosition = new Vector3(FirstWidth, FloorHeight*3, FirstDepth);
            tri.localScale = new Vector3(PillarRadius, PillarHeight, PillarRadius);
            FirstWidth = FirstWidth + WidthSize;
            FirstDepth = FirstWidth + DepthSize;

        }
        // 첫번째 왼쪽 오른쪽 pillar  = width/2 * k * k -0.2 의 위치!
        // 가로 각 기둥사이의 간격 : width*k*k-0.2-0.2 한것의 6으로 나눈값
        // 세로 각 기둥사이의 간격 : depth*k*k-0.2-0.2 한것의 10으로 나눈값
        // 반복문 2번으로 하여서 위치는 +, - 로 반대편2줄을 한꺼번에 작성하는것으로
        // 세로 20개 우선 작성
        // 가로 8개 다음 작성

    }

    void Update () {
		
	}
}
