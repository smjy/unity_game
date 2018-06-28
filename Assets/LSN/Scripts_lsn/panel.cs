using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class panel : MonoBehaviour {
    
    private List<item_block> blocks;
    public List<item> weapons;
    public item_block block;
    public Sprite s;
    int num=0;
	// Use this for initialization
	void Start () {
        weapons = new List<item>();
        blocks = new List<item_block>();


        item_block[] m = FindObjectsOfType<item_block>();
        item[] ng = FindObjectsOfType<item>();
        for(int i=0;i<3;i++)
        {
            weapons.Add(ng[i]);
        }
        for (int i = 0; i < 3; i++)
        {

            blocks.Add(m[i]);
            blocks[i].setNum(i);

            // Transform temp = parent;
            //temp.SetPositionAndRotation(new Vector3(0, 0, 0), temp.rotation);

            // Instantiate<Button>(btn, new Vector3(parent.position.x + 10 + i * 50, parent.position.y + 10 + i * 50, parent.position.z), parent.rotation);
            /* weapons.Add(Instantiate<item_block>(block, parent));
             weapons[j+(i*6)].transform.Translate(60 * j, 60*i, 0.0f);*/

        }
       
        for (int i = 0; i < weapons.Count; i++)
        {

            blocks[i].setBlockImage(weapons[i].sprite);
            Debug.Log("123");

        }

        
    }

    // Update is called once per frame
    void Update () {
       
		
	}
    public void addItem(item i)
    {
        //满了
        //弹出背包满了 社么也不做 return;
        //判断可堆叠
        //如果可以
        //操作某一个itemBlock
        //itemBLock.loadImage (item.image)
        weapons.Add(i);
        blocks[weapons.Count].setBlockImage(i.sprite);

    }

    public void useItem(item i)
    {
        //i.use();
    }
    public void deleteItem(int i)
    {
        //weapons[i].setBlockImage(null);
        weapons.RemoveAt(i);
        weapons.Sort();
    }
}
