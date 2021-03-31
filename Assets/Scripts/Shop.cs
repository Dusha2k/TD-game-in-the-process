using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret() 
    {
        Debug.Log("Standart");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
