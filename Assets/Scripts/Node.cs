using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded;


    private Renderer _rend;
    private Color _startColor;

    private BuildManager _buildManager;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        if (!_buildManager.CanBuild)
            return;

        BuildTurret(_buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayersStats.Money < blueprint.cost)
        {
            Debug.Log("No money for upgrade that");
            return;
        }

        PlayersStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Build");
    }

    public void UpgradeTurret()
    {
        if (PlayersStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("No money for upgrade that");
            return;
        }

        PlayersStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Build");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;
        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }
        else
        {
            _rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
