using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0414

public abstract class Region : MonoBehaviour {

    protected bool _visited = false; //主角是否进入过该区域
    protected bool _hasUser = false; //主角当前是否在该区域
    protected HashSet<Vector2> _blockList = new HashSet<Vector2>(); //区块位置
    protected MapBoundsController _mapBoundsController;
    protected Vector2 _pos = new Vector2();
    protected GameObject obj_effects;
    protected GameObject obj_events;
        
    public HashSet<Vector2> blockList {
        get {
            return _blockList;
        }
        set {
            _blockList = value;
        }
    }
    public MapBoundsController mapBoundsController {
        get {
            return _mapBoundsController;
        }
        set {
            _mapBoundsController = value;
        }
    }
    public bool visited {
        get {
            return _visited;
        }
        set {
            _visited = value;
        }
    }
    public bool has_user {
        get {
            return _hasUser;
        }
        set {
            _hasUser = value;
        }
    }
    public Vector2 pos {
        get {
            return _pos;
        }
    }

    [System.Serializable] 
    public struct RegionEvent {
        public Event e;
        public int power;
    }
    //RegionEffect 每个Region生成以下effectGenerator各一
    [System.Serializable] 
    public struct RegionEffect {
        public EffectGenerator eg;
    }
    int d = 0;
    [Header("区域设定")]
    [SerializeField] [Tooltip("区域的唯一标志名")] string region_name = "default";
    [SerializeField] [Tooltip("区域边界材质")] Material bound_material;
    [SerializeField] [Tooltip("区域边界粗细倍数")] float width_multiplier = 1;
    [SerializeField] [Tooltip("区域区块数量最大值(0为不限制)")] int max_block = 3;
    //[SerializeField] [Tooltip("区域区块数量靠近最大值的概率阈值")] float max_block_param = 0.5f; //弃用，因为逻辑冲突
    [SerializeField] [Tooltip("区域包含事件及权重")] RegionEvent[] region_events;
    [SerializeField] [Tooltip("区域包含事件最大值")] int max_events = 20;

    [SerializeField] [Tooltip("区域包含背景特效及权重")] RegionEffect[] region_effects;
    [SerializeField] [Tooltip("区域包含背景特效最大值")] int max_effects = 20;


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
    public string regionName {
        get {
            return region_name;
        }
    }
    protected bool fullSurrounding(int x,int y) {
        if (MapManager.main.regionGeneratedAt(x-1,y) && MapManager.main.regionAt(x-1,y).GetType() == this.GetType() && MapManager.main.regionAt(x-1,y).full()) {
            return true;
        }
        if (MapManager.main.regionGeneratedAt(x+1,y) && MapManager.main.regionAt(x+1,y).GetType() == this.GetType() && MapManager.main.regionAt(x+1,y).full()) {
            return true;
        }
        if (MapManager.main.regionGeneratedAt(x,y-1) && MapManager.main.regionAt(x,y-1).GetType() == this.GetType() && MapManager.main.regionAt(x,y-1).full()) {
            return true;
        }
        if (MapManager.main.regionGeneratedAt(x,y+1) && MapManager.main.regionAt(x,y+1).GetType() == this.GetType() && MapManager.main.regionAt(x,y+1).full()) {      
            return true;
        }

        return false;
    }

   
    //是否已达到最大连续区块数量
    public bool full() {
        // Debug.Log(this.GetType().ToString());
        // Debug.Log(max_block+" "+_blockList.Count);
        if (max_block == 0) return false;
        return max_block == _blockList.Count;
    }
    //设定该区域存在的区块位置
    public void addBlock(int x,int y) {

        _pos = new Vector2(x,y);
        _blockList.Add(new Vector2(x,y));

        if (MapManager.main.regionGeneratedAt(x-1,y) && MapManager.main.regionAt(x-1,y).GetType() == this.GetType()) {
            _blockList.UnionWith(MapManager.main.regionAt(x-1,y).blockList);
        }
        if (MapManager.main.regionGeneratedAt(x+1,y) && MapManager.main.regionAt(x+1,y).GetType() == this.GetType()) {
            _blockList.UnionWith(MapManager.main.regionAt(x+1,y).blockList);
        }
        if (MapManager.main.regionGeneratedAt(x,y-1) && MapManager.main.regionAt(x,y-1).GetType() == this.GetType()) {
            _blockList.UnionWith(MapManager.main.regionAt(x,y-1).blockList); 
        }
        if (MapManager.main.regionGeneratedAt(x,y+1) && MapManager.main.regionAt(x,y+1).GetType() == this.GetType()) {      
            _blockList.UnionWith(MapManager.main.regionAt(x,y+1).blockList);
        }
        

        if (MapManager.main.regionGeneratedAt(x-1,y) && MapManager.main.regionAt(x-1,y).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x-1,y).blockList;
            foreach (Vector2 v in bl) {
                if(v == _pos) continue;                          
                MapManager.main.regionAt(v).blockList = _blockList;
            }
        }    
        if (MapManager.main.regionGeneratedAt(x+1,y) && MapManager.main.regionAt(x+1,y).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x+1,y).blockList;
            foreach (Vector2 v in bl) {
                if(v == _pos) continue;                          
                MapManager.main.regionAt(v).blockList = _blockList;
            }
        }
        if (MapManager.main.regionGeneratedAt(x,y-1) && MapManager.main.regionAt(x,y-1).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x,y-1).blockList;
            foreach (Vector2 v in bl) {
                if(v == _pos) continue;                          
                MapManager.main.regionAt(v).blockList = _blockList;
            }
        }
        if (MapManager.main.regionGeneratedAt(x,y+1) && MapManager.main.regionAt(x,y+1).GetType() == this.GetType()) {
            HashSet<Vector2> bl = MapManager.main.regionAt(x,y+1).blockList;
            foreach (Vector2 v in bl) {
                if(v == _pos) continue;    
                MapManager.main.regionAt(v).blockList = _blockList;
            }
        }      
    }
    
    protected virtual void Start () {

        //生成子空物体
        obj_effects =  new GameObject("RegionEffects");
        obj_effects.transform.SetParent(transform);
        obj_events = new GameObject("RegionEvents");
        obj_events.transform.SetParent(transform);

        

        generateEffects();
        generateEvents();
        
	}
    //玩家进入时触发

    public void enter() {

    }
    protected void generateEvents() {

    }
    protected void generateEffects() {
        //初始化区域特效
        //OPTIMIZE:现在只生成一个
        foreach(RegionEffect re in region_effects) {
            generateEffect(re);
        }
    }
    protected void generateEffect(RegionEffect re) {
        EffectGenerator eg = Instantiate(re.eg,obj_effects.transform);
        eg.setRegion(this);
        //eg.init(this,_mapBoundsController.left,_mapBoundsController.right,_mapBoundsController.top,_mapBoundsController.bottom);
    }
    void Update() {

  
    }

    //----------虚函数部分-------------------

     //获取权重,若为-1则绝对不会生成
    public virtual int getPower(int x,int y,int depth,int seed) {
        
        return 0;
    }
	
}
