using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Invector;
using Invector.ItemManager;
public class vAmmoListData : ScriptableObject
{
    public List<vItemListData> itemListDatas;
    [HideInInspector]
    public List<vAmmo> ammos = new List<vAmmo>();  
}
