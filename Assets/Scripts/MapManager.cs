using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	//地图边界样式
	public const int BOUND_NORMAL = 1;

	[Header("地图边界参数")]
	[Tooltip("正方形边长")] public float square_length = 500f; 
	[Tooltip("边界内缩边距")] public float square_indent = 1f;

	[Header("区域类型集合")]
	public Region[] regions;
	float real_length;

	[Header("区域生成算法")]
	[Tooltip("初始生成范围的网格矩形边长")] public int init_block_length = 5;
	[Tooltip("主机接近已生成区域边境该距离后开始补充生成")] public int continue_length_when_close = 2;
	[Tooltip("补充生成的圈数")] public int continue_block_length = 2;
	
	public GameObject bound;
	public Transform bound_parent;
	
	int seed = 123; //根据种子生成地图
	int x_seed = 1;
	int y_seed = 1000;
	//地图生成局部种子设定: 已知全局种子和区块的x,y，则该区块的区域类型局部种子为全局种子+x*x_seed+y*y_seed
	//区域类型设定: 已知x,y,四周区域类型，根据四周区域类型和深度depth生成权重 取权重最大者决定区域
	//生成顺序如下图
	// 8   1 → 2
	// ↑   ↑   ↓
	// 7   0   3
	// ↑       ↓
	// 6 ← 5 ← 4
	Random.State rs;
	struct RectBounds {
		public float left,right,top,bottom;
	}

	RectBounds[] rectBounds;
	void Start () {
		Random.InitState(seed);
		rs = Random.state;
		real_length = square_length - 2* square_indent;
		InstantiateBoundsAt(0,0,BOUND_NORMAL);
		GenerateMapOfDepth(2);
	}
	//预先决定的区域
	void PriorRegions() {

	}
	
	//边界生成
	void InstantiateBoundsAt(int x,int y,int boundtype = BOUND_NORMAL) {
		//原点为0,0 x从左向右 y从下向上
		
		InstantiateBounds(real_length,real_length,square_length*x-square_length/2+square_indent,square_length*y-square_length/2+square_indent);
	}
	void InstantiateBounds(RectBounds rb,int boundtype = BOUND_NORMAL) {
		InstantiateBounds(rb.right-rb.left,rb.top-rb.bottom,rb.left,rb.bottom,boundtype);
	}
	void InstantiateBounds(float width,float height, float startx,float starty,int boundtype = BOUND_NORMAL) {
		Random.state = rs;
		GameObject b = Instantiate(bound,bound_parent);
		b.GetComponent<MapBoundsController>().Init(width,height,startx,starty,boundtype);
		rs = Random.state;
	}

	//生成第depth环的区块
	void GenerateMapOfDepth(int depth) {
		if (depth == 1) {

			return;
		}
		//int start = 4*depth*depth-12*depth+9;
		//int amount = 8*(depth-1);
		int x = 2 - depth;
		int y = depth - 1;
		while(true) {
			GenerateMapAt(x,y);
			//Debug.Log(x.ToString()+" "+y.ToString());
			if (y == depth-1) {
				if (x == 1-depth) break;
				if (x<depth-1) x++;
				else y--;
			} else if (x == depth-1) {
				if (y>1-depth) y--;
				else x--;
			} else if (y == 1-depth) {
				if (x>1-depth) x--;
				else y++;
			} else y++;
			if (y == depth) break;
		}
		
	}
	// 2 0 1 3 -1 2 4 -2 3
	void GenerateMapAt(int x,int y) {
		//TODO:生成地图
		InstantiateBoundsAt(x,y,BOUND_NORMAL);
	}



	// Update is called once per frame
	void Update () {
		
	}
}
