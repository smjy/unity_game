using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	

	[Header("地图边界参数")]
	[Tooltip("正方形边长")] public float square_length = 500f; 
	[Tooltip("边界内缩边距")] public float square_indent = 1f;
	[Tooltip("默认边界材质")] public Material default_material;

	[Header("区域类型集合")]
	[Tooltip("所有可用区域类型集合")] public Region[] available_regions;
	[Tooltip("起始区域")] public Region start_region;
	[Tooltip("虚空区域")] public Region empty_region;
	
	[Header("区域生成算法")]
	[Tooltip("初始生成范围的网格矩形边长")] public int init_block_length = 5;
	[Tooltip("主机接近已生成区域边境该距离后开始补充生成")] public int continue_length_when_close = 2;
	[Tooltip("补充生成的圈数")] public int continue_block_length = 2;
	float real_length;

	public GameObject bound;
	public Transform bound_parent;
	public Transform region_parent;

	int seed = 123; //根据种子生成地图
	int x_seed = 1;
	int y_seed = 1000;
	Dictionary<Vector2,Region> Regions = new Dictionary<Vector2,Region>();
	
	//地图生成局部种子设定: 已知全局种子和区块的x,y，则该区块的区域类型局部种子为全局种子+x*x_seed+y*y_seed
	//区域类型设定: 已知x,y,四周区域类型，根据四周区域类型和深度depth生成权重 取权重最大者决定区域
	//生成顺序如下图
	// 8   1 → 2
	// ↑   ↑   ↓
	// 7   0   3
	// ↑       ↓
	// 6 ← 5 ← 4
	struct RectBounds {
		public float left,right,top,bottom;
	}
	public static MapManager main;
	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }

	void Start () {
		Random.InitState(seed);
		real_length = square_length - 2* square_indent;
		PriorRegions();
		GenerateMapWithinDepth(3);

	}

	public bool regionGeneratedAt(int x,int y) {
		return Regions.ContainsKey(new Vector2(x,y));
	}
	public Region regionAt(int x,int y) {
		return Regions[new Vector2(x,y)];
	}
	public Region regionAt(Vector2 v) {
		return Regions[v];
	}
	
	//某位置上下左右包含某一区域的数量
	public int surrounds(int x,int y,string region_name) {
		int s = 0;
		if (regionGeneratedAt(x+1,y) && regionAt(x+1,y).regionName == region_name) s++;
		if (regionGeneratedAt(x-1,y) && regionAt(x-1,y).regionName == region_name) s++;
		if (regionGeneratedAt(x,y+1) && regionAt(x,y+1).regionName == region_name) s++;
		if (regionGeneratedAt(x,y-1) && regionAt(x,y-1).regionName == region_name) s++;
		return s;
	}
	
	//边界生成
	MapBoundsController InstantiateBoundsAt(int x,int y,Material bound_material,float width_multiplier = 1f) {
		//原点为0,0 x从左向右 y从下向上	
		return InstantiateBounds(real_length,real_length,square_length*x-square_length/2+square_indent,square_length*y-square_length/2+square_indent,bound_material,width_multiplier);
	}
	MapBoundsController InstantiateBounds(RectBounds rb,Material bound_material,float width_multiplier = 1f) {
		return InstantiateBounds(rb.right-rb.left,rb.top-rb.bottom,rb.left,rb.bottom,bound_material,width_multiplier);
	}
	MapBoundsController InstantiateBounds(float width,float height, float startx,float starty,Material bound_material,float width_multiplier = 1f) {
		GameObject b = Instantiate(bound,bound_parent);
		MapBoundsController mbc = b.GetComponent<MapBoundsController>();
		mbc.Init(width,height,startx,starty,bound_material,width_multiplier);
		return mbc;
	}

	//预先决定的区域
	void PriorRegions() {
		GenerateMapAt(0,0,start_region);
	}
	//生成第depth环以内的区块
	void GenerateMapWithinDepth(int depth) {
		if (depth<1) return;
		for (int i=1;i<=depth;i++) GenerateMapOfDepth(i);
	}
	//生成第depth环的区块
	void GenerateMapOfDepth(int depth) {
		if (depth == 1) {
			GenerateMapAt(0,0,depth);
			return;
		}
		//int start = 4*depth*depth-12*depth+9;
		//int amount = 8*(depth-1);
		int x = 2 - depth;
		int y = depth - 1;
		while(true) {
			GenerateMapAt(x,y,depth);
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
	//生成第x,y位置的区块 计算其区域并赋予
	void GenerateMapAt(int x,int y,int depth) {
		
		if (regionGeneratedAt(x,y)) {
			//Debug.Log("地图已经在 ("+x+","+y+")位置生成!");
			return;
		}
		if (available_regions.Length == 0) {
			Debug.Log("请设置生成区域数组!");
			return;
		}
		int maxpower = -1;
		Region mr = empty_region;
		int region_seed = seed + x * x_seed + y * y_seed;
		foreach (Region region in available_regions) {
			int p = region.getPower(x,y,depth,region_seed);
			//Debug.Log(p);
			if (p>maxpower) mr = region;
		}
		Region r = Instantiate(mr,region_parent) as Region;
		r.addBlock(x,y);
		Regions.Add(new Vector2(x,y),r);
		MapBoundsController mbc = InstantiateBoundsAt(x,y,r.material,r.width);
		r.mapBoundsController = mbc;
	}
	//生成第x,y位置的区块并赋予其区域region
	void GenerateMapAt(int x,int y,Region region) {
		
		if (regionGeneratedAt(x,y)) {
			//Debug.Log("地图已经在 ("+x+","+y+")位置生成!");
			return;
		}
		Region r = Instantiate(region,region_parent) as Region;
		r.addBlock(x,y);		
		Regions.Add(new Vector2(x,y),r);
		MapBoundsController mbc = InstantiateBoundsAt(x,y,r.material,r.width);
		r.mapBoundsController = mbc;

	}



	// Update is called once per frame
	void Update () {
		
	}
}