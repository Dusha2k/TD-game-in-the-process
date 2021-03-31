using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one");
        }
        instance = this;
    }
    
    public GameObject buildEffect;

    private TurretBlueprint _turretToBuild;
    private Node _selectedNode;

    public NodeUI nodeUI;
    
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayersStats.Money >= _turretToBuild.cost; } }


    public void SelectNode(Node node)
    {
        if(_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        _selectedNode = node;
        _turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
