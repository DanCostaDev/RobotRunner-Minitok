using UnityEngine;

public class LaserTowerController : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    private LaserModes laserMode;

    public void SetLasers()
    {
        foreach(GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
        RandomizeLaser();
        switch (laserMode)
        {
            case LaserModes.PuloCurto:
                lasers[0].SetActive(true);
                break;
            case LaserModes.PuloMedio:
                lasers[0].SetActive(true);
                lasers[1].SetActive(true);
                break;
            case LaserModes.PuloLongo:
                lasers[0].SetActive(true);
                lasers[1].SetActive(true);
                lasers[2].SetActive(true);
                break;
            case LaserModes.NaoPular:
                lasers[3].SetActive(true);
                lasers[4].SetActive(true);
                break;
            case LaserModes.PuloCurtoComTeto:
                lasers[0].SetActive(true);
                lasers[5].SetActive(true);
                lasers[6].SetActive(true);
                break;
            case LaserModes.PuloMedioComTeto:
                lasers[0].SetActive(true);
                lasers[1].SetActive(true);
                lasers[5].SetActive(true);
                lasers[6].SetActive(true);
                break;
            case LaserModes.PuloLongoComTeto:
                lasers[0].SetActive(true);
                lasers[1].SetActive(true);
                lasers[2].SetActive(true);
                lasers[5].SetActive(true);
                lasers[6].SetActive(true);
                break;
        }
    }
    private void RandomizeLaser()
    {
        int mode = Random.Range(0, 6);
        switch (mode)
        {
            case 0:
                laserMode = LaserModes.PuloCurto; break;
            case 1:
                laserMode = LaserModes.PuloMedio; break;
            case 2:
                laserMode = LaserModes.PuloLongo; break;
            case 3:
                laserMode = LaserModes.NaoPular; break;
            case 4:
                laserMode = LaserModes.PuloCurtoComTeto; break;
            case 5:
                laserMode = LaserModes.PuloMedioComTeto; break;
            case 6:
                laserMode = LaserModes.PuloLongoComTeto; break;
        }
    }

    private enum LaserModes
    {
        PuloCurto,
        PuloMedio,
        PuloLongo,
        NaoPular,
        PuloCurtoComTeto,
        PuloMedioComTeto,
        PuloLongoComTeto
    }
}
