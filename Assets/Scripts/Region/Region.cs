using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0414

public abstract class Region : MonoBehaviour {

    protected bool visited = false; //主角是否进入过该区域
    protected bool has_user = false; //主角当前是否在该区域
    protected HashSet<Vector2> block_list = new HashSet<Vector2>(); //区块位置
    protected MapBoundsController map_bounds;
    protected Vector2 pos = new Vector2();

    public HashSet<Vector2> blockList {
        get {
            return block_list;
        }
        set {
            block_list = value;
        }
    }
    public MapBoundsController mapBoundsController {
        get {
            return map_bounds;
        }
        set {
            map_bounds = value;
        }
    }

    [System.Serializable] 
    public struct RegionEvent {
        public Event e;
        public int power;
    }
    int d = 0;
    [Header("区域设定")]
    [SerializeField] [Tooltip("区域边界材质")] Material bound_material;
    [SerializeField] [Tooltip("区域边界粗细倍数")] float width_multiplier = 1;
    [SerializeField] [Tooltip("区域区块数量最大值")] int max_block = 3;
    [SerializeField] [Tooltip("区域区块数量靠近最大值的概率阈值")] float block_param = 0.5f;
    [SerializeField] [Tooltip("区域包含事件及权重")] RegionEvent[] region_events;

    public Material material {
        get {
            return bound_material;
        }
    }
    public float width {
        get {
            return width_multiplier;
        }
    }
    //获取权重
    public virtual int getPower(int x,int y,int depth,int seed) {
        return 0;
    }
    
    public void addBlock(int x,int y) {

        pos = new Vector2(x,y);
        block_list.Add(new Vector2(x,y));

        if (MapManager.main.regionGeneratedAt(x-1,y) && MapManager.main.regionAt(x-1,y).GetType() == this.GetType()) {
            block_list.UnionWith(MapManager.main.regionAt(x-1,y).blockList);
        }

        if (MapManager.main.regionGeneratedAt(x+1,y) && MapManager.main.regionAt(x+1,y).GetType() == this.GetType()) {
            block_list.UnionWith(MapManager.main.regionAt(x+1,y).blockList);
        }
        if (MapManager.main.regionGeneratedAt(x,y-1) && MapManager.main.regionAt(x,y-1).GetType() == this.GetType()) {
            block_list.UnionWith(MapManager.main.regionAt(x,y-1).blockList); 
        }
        if (MapManager.main.regionGeneratedAt(x,y+1) && MapManager.main.regionAt(x,y+1).GetType() == this.GetType()) {      
            block_list.UnionWith(MapManager.main.regionAt(x,y+1).blockList);
        }
        

        if (MapManager.main.regionGeneratedAt(x-1,y) && MapManager.main.regionAt(x-1,y).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x-1,y).blockList;
            foreach (Vector2 v in bl) {
                if(v == pos) continue;                          
                MapManager.main.regionAt(v).blockList = block_list;
            }
        }    
        if (MapManager.main.regionGeneratedAt(x+1,y) && MapManager.main.regionAt(x+1,y).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x+1,y).blockList;
            foreach (Vector2 v in bl) {
                if(v == pos) continue;                          
                MapManager.main.regionAt(v).blockList = block_list;
            }
        }
        if (MapManager.main.regionGeneratedAt(x,y-1) && MapManager.main.regionAt(x,y-1).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x,y-1).blockList;
            foreach (Vector2 v in bl) {
                if(v == pos) continue;                          
                MapManager.main.regionAt(v).blockList = block_list;
            }
        }
        if (MapManager.main.regionGeneratedAt(x,y+1) && MapManager.main.regionAt(x,y+1).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x,y+1).blockList;
            foreach (Vector2 v in bl) {
                if(v == pos) continue;    
                MapManager.main.regionAt(v).blockList = block_list;
            }
        }      
    }
    void Start () {

	}

    void Update() {
        if (map_bounds.inside(MainPlayer_Single.me.transform.position)) {
            visited = true;
            has_user = true;
        } else {
            has_user = false;
        }
    }
	
}
