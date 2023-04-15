using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public SkinnedMeshRenderer targetWeaponMesh;

    public GameObject armorParent;
    public GameObject[] meshesToHide;

    public Equipment[] currentEquipment;
    public SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
                onEquipmentChanged.Invoke(newItem, oldItem);
        }

        if (slotIndex == 0)
        {
            if (currentEquipment[slotIndex] != null)
            {
                armorParent.transform.Find(oldItem.name).gameObject.SetActive(false);
            }
            armorParent.transform.Find(newItem.name).gameObject.SetActive(true);
            currentEquipment[slotIndex] = newItem;
            currentMeshes[slotIndex] = newItem.mesh;

            foreach (var mesh in meshesToHide)
            {
                if (newItem.name == "Armor2" && mesh.name == "Hands")
                {
                    mesh.SetActive(true);
                    continue;
                }

                mesh.SetActive(false);
            }
            return;
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);

        if (newItem.prefab)
        {
            AttachToMesh(newItem.mesh, slotIndex);
        }
        if (slotIndex == 1)
        {
            newMesh.transform.parent = targetWeaponMesh.transform;
            newMesh.bones = targetWeaponMesh.bones;
            newMesh.rootBone = targetWeaponMesh.rootBone;
            newMesh.transform.position = targetWeaponMesh.transform.position;
            newMesh.transform.rotation = targetWeaponMesh.transform.rotation;
        }
        currentMeshes[slotIndex] = newMesh;
    }

    void AttachToMesh(SkinnedMeshRenderer mesh, int slotIndex)
    {
        if (currentMeshes[slotIndex] != null)
        {
            Destroy(currentMeshes[slotIndex].gameObject);
        }
    }
}

