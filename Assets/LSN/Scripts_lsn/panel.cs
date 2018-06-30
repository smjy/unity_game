using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class panel : MonoBehaviour
{
    [HideInInspector]
    public List<item_block> blocks;
    public List<item> weapons;
    // public item_block block;
    //public Sprite s;
    int weaponsnum = 0;
    int fullblocks = 0;
    // Use this for initialization
    public void initial_panel()
    {
        weapons = new List<item>();
        blocks = new List<item_block>();


        //item_block[] m = FindObjectsOfType<item_block>();
        for (int i = 0; i <24; i++)
        {
            blocks.Add(transform.Find("item_block" + i).GetComponent<item_block>());
            //Debug.Log(blocks[i].name);
            blocks[i].initial();
        }
     
        item[] ng = FindObjectsOfType<item>();
        weaponsnum = ng.Length;
        for (int i = 0; i < ng.Length; i++)
        {
            weapons.Add(ng[i]);

        }
        Debug.Log(weaponsnum);
        initial();
       
    }

    // Update is called once per frame
    void Update()
    {


    }
    void initial()
    {
        Debug.Log("weapons count:"+weapons.Count);
        fullblocks = 0;
       
        foreach (item T in weapons)
        {
            Debug.Log(T.name);
            if (!T.stackable)
            {
                if (fullblocks < 24)
                {
                   
                    blocks[fullblocks].setBlockImage(T.sprite);   
                    blocks[fullblocks].setName(T.name);
                    blocks[fullblocks].setNum(1);
                    fullblocks++;      
                }
                else
                {
                    Debug.Log("背包已满");
                }
            }
            else
            {
                int n = findItem(T);
                if (n == -1)
                {
                    if (fullblocks < 24)
                    {       
                        blocks[fullblocks].setBlockImage(T.sprite);
                        blocks[fullblocks].setName(T.name);
                        blocks[fullblocks].setNum(1);
                        fullblocks++;                 
                    }
                    else
                    {
                        Debug.Log("背包已满");
                    }
                }
                else
                {
                   
                    int temp = blocks[n].getnum();
                    temp++;
                    blocks[n].setNum(temp);
                   

                }
            }
            // Transform temp = parent;
            //temp.SetPositionAndRotation(new Vector3(0, 0, 0), temp.rotation);

            // Instantiate<Button>(btn, new Vector3(parent.position.x + 10 + i * 50, parent.position.y + 10 + i * 50, parent.position.z), parent.rotation);
            /* weapons.Add(Instantiate<item_block>(block, parent));
             weapons[j+(i*6)].transform.Translate(60 * j, 60*i, 0.0f);*/

        }
    }
    public void addItem(item i)
    {
        //满了
        //弹出背包满了 社么也不做 return;
        //判断可堆叠
        //如果可以
        //操作某一个itemBlock
        //itemBLock.loadImage (item.image)
        if (!i.stackable)
        {
            if (fullblocks < 30)
            {
                weapons.Add(i);
                blocks[fullblocks].setBlockImage(i.sprite);
              
                blocks[fullblocks].setName(i.name);
                blocks[fullblocks].setNum(1);
                weaponsnum++;
                fullblocks++;
            }
            else
            {
                Debug.Log("背包已满");
            }
        }
        else
        {
            int n = findItem(i);
            if (n==-1)
            {
                if (fullblocks < 30)
                {
                    weapons.Add(i);
                    blocks[fullblocks].setBlockImage(i.sprite);
                    blocks[fullblocks].setName(i.name);
                    blocks[fullblocks].setNum(1);
                    weaponsnum++;
                    fullblocks++;
                }
                else
                {
                    Debug.Log("背包已满");
                }
            }
            else
            {
                int temp = blocks[n].getnum();
                temp++;
                weapons.Add(i);
                blocks[n].setNum(temp);
                weaponsnum++;
            }
        }
    }
    public int findItem(item i)
    {
        int ret = -1;
        int j = 0;
       while(j<fullblocks)
        {
             if(blocks[j].NAME==i.name)
            {
                ret = j;
            }
             if(j!=-1)
            {
                break;
            }
        }
        return ret;
    }
    public int findweapons(string name)
    {
        int ret = -1;
        for(int i = 0;i<weaponsnum;i++)
        {
            if(weapons[i].name==name)
            {
                ret = i;
            }
        }
        return ret;

    }
    public void useItem(item i)
    {
        //i.use();
    }
    public bool IsNull(int i)
    {
        return blocks[i].isNull;
    }
    public void deleteItem(int i)
    {
        Debug.Log(i);
        //weapons[i].setBlockImage(null);
        int num = blocks[i].getnum();
        Debug.Log(num);
        if (num>1)
        {
            int n = findweapons(blocks[i].NAME);
            weapons.RemoveAt(n);
            weaponsnum--;
            blocks[i].setNum(0);
            for (int j = 0; j < 23; j++)
            {
                blocks[j].setNum(0);
            }
            initial();
        }
        else
        {
            int n = findweapons(blocks[i].NAME);
            weapons.RemoveAt(n);
            weaponsnum--;
            blocks[i].setNum(0);
            for (int j = 0; j < 24; j++)
            {
                blocks[j].setNum(0);
            }
            initial();
        }
       

    }
}
