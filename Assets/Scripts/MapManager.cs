using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    //地图边界样式
    public const int BOUND_NORMAL = 1;

    //地图类型





    public float square_length = 500f; //正方形边长
    public float square_indent = 1f; //边界内缩边距

    float real_length;

    public GameObject bound;
    public Transform bound_parent;

    int seed = 123; //根据种子生成地图
    Random.State rs;
    struct RectBounds
    {
        public float left, right, top, bottom;
    }

    RectBounds[] rectBounds;
    void Start()
    {
        Random.InitState(seed);
        rs = Random.state;
        real_length = square_length - 2 * square_indent;
        InstantiateDepth(0, 0, BOUND_NORMAL);
        InstantiateDepth(0, 1, BOUND_NORMAL);

    }
    void InstantiateDepth(int x, int y, int boundtype = BOUND_NORMAL)
    {
        //原点为0,0 x从左向右 y从下向上

        InstantiateBounds(real_length, real_length, square_length * x - square_length / 2 + square_indent, square_length * y - square_length / 2 + square_indent);
    }
    void InstantiateBounds(RectBounds rb, int boundtype = BOUND_NORMAL)
    {
        InstantiateBounds(rb.right - rb.left, rb.top - rb.bottom, rb.left, rb.bottom, boundtype);
    }
    void InstantiateBounds(float width, float height, float startx, float starty, int boundtype = BOUND_NORMAL)
    {
        Random.state = rs;
        GameObject b = Instantiate(bound, bound_parent);
        b.GetComponent<MapBoundsController>().Init(width, height, startx, starty, boundtype);
        rs = Random.state;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
