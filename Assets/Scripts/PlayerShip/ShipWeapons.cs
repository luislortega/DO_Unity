using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour {

    public Transform laserSalvo;
    public Transform[] shootPoints; //succesiune:  timp de 1 sec:  1-1 / 2-2 / 3 / 2-2/      1*= 0,1 / 2* = 2,3 / 3* = 4 

    GameObject reticle;
    GameObject outOfRangeWarning;

    int maxAttackRange = 8;

    [HideInInspector] public ShipMovement shipMovementScript;
     public Transform targetToShoot;

    void Awake()
    {
        shipMovementScript = GetComponent<ShipMovement>();
        reticle = Resources.Load("Misc/Reticle") as GameObject;
        outOfRangeWarning = Resources.Load("Misc/RangeWarning") as GameObject;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject.CompareTag("Alien") || hit.transform.gameObject.CompareTag("AI"))
                {
                    LockTarget(hit, hit.transform.position);
                }
            }
        }
        if(_shooting) CheckAttackRange();
    }
    
    #region Atacuri Laser
    [HideInInspector] public bool _shooting; //true daca nava trage cu lasere, false daca nu\\

    //Comuta atacul laser in cazul in care exista o tinta\\
    public void StartLaserAttack()
    {
        if (targetToShoot != null)
        {
            if (!OutOfRange())
            {
                StartCoroutine("LasersEffect");
                StartCoroutine("LaserDamageLoop");
                _shooting = true;
            }
            else
            {
                StopCoroutine("LaserDamageLoop");
                _shooting = true;
                StartCoroutine("OutOfRangeWarning");
            }
        }
    }

    //Opreste un atac laser asupra unei tinte\\
    public void StopLaserAttack()
    {
        StopCoroutine("LasersEffect");
        _shooting = false;
        StopCoroutine("LaserDamageLoop");
        StopCoroutine("OutOfRangeWarning");
    }

    //Corutina responsabila de efectele laser\\
    public IEnumerator LasersEffect()
    {
        while (true)
        {
            SpawnSalvo(shootPoints[0]);
            SpawnSalvo(shootPoints[1]);
            Utils.PlaySound(laserSalvo.name);

            yield return new WaitForSeconds(0.2f);

            SpawnSalvo(shootPoints[2]);
            SpawnSalvo(shootPoints[3]);
            Utils.PlaySound(laserSalvo.name);

            yield return new WaitForSeconds(0.2f);

            SpawnSalvo(shootPoints[4]);
            Utils.PlaySound(laserSalvo.name);

            yield return new WaitForSeconds(0.2f);

            SpawnSalvo(shootPoints[2]);
            SpawnSalvo(shootPoints[3]);
            Utils.PlaySound(laserSalvo.name);

            yield return new WaitForSeconds(0.4f);

        }
    }

    //Instantiere salve laser\\
    void SpawnSalvo(Transform cannonPos)
    {
        Transform spawnedSalvo;

        spawnedSalvo = Instantiate(laserSalvo, cannonPos.position, Quaternion.identity) as Transform;
        spawnedSalvo.GetComponent<LaserSalvo>().target = targetToShoot.position;
        spawnedSalvo.GetComponent<LaserSalvo>().distanceToTarget = Vector2.Distance(transform.position, targetToShoot.transform.position);
    }

    //Vefirica daca tinta e in raza de actiune si opreste/porneste laserele in dependenta de valoarea OutOfRange()\\
    bool _hasExitedRange = false;
    void CheckAttackRange()
    {
        if(OutOfRange()) 
        {
            if (!_hasExitedRange)
            {
                StopCoroutine("LasersEffect");
                StopCoroutine("LaserDamageLoop");
                StartCoroutine("OutOfRangeWarning");
                Utils.GameLog("Out of range!");
                _hasExitedRange = true;
            }
        }
        else
        {
            if (_hasExitedRange)
            {
                StartCoroutine("LasersEffect");
                StartCoroutine("LaserDamageLoop");
                StopCoroutine("OutOfRangeWarning");
                _hasExitedRange = false;
            }
        }
       
    }

    //Verifica daca tinta este in raza de actiune. "true" daca da, "false" daca nu\\
    bool OutOfRange()
    {
        if (targetToShoot != null)
        {
            if (Vector2.Distance(targetToShoot.position, transform.position) > maxAttackRange)
            {
                return true;
            }
            else return false;
        }
        else { return false; }
    }

    //Atentioneaza jucatorul despre distanta prea mare de tinta\\
    IEnumerator OutOfRangeWarning()
    {
        while (true)
        {
            Utils.PlaySound("out_of_range");
            SpawnRangeWarningSign();
            yield return new WaitForSeconds(0.3f);
            Utils.PlaySound("out_of_range");
            SpawnRangeWarningSign();
            yield return new WaitForSeconds(0.3f);
            Utils.PlaySound("out_of_range");
            SpawnRangeWarningSign();
            yield return new WaitForSeconds(1.5f);
        }
    }

    //Instantiere sprite de atentionare cu privire la raza de actiune\\
    void SpawnRangeWarningSign()
    {
        GameObject warningSprite;
        float angle = Mathf.Deg2Rad * Utils.AngleDiff(Vector3.right, targetToShoot.position - transform.position);
        float x = -Mathf.Cos(angle) * 5;
        float y = -Mathf.Sin(angle) * 5;

        warningSprite = Instantiate(outOfRangeWarning);
        warningSprite.transform.SetParent(gameObject.transform);
        warningSprite.transform.localPosition = new Vector3(x, y, 0);
        warningSprite.transform.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);

    }

    public IEnumerator LaserDamageLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            LaserDamage();
        }
    }

    void LaserDamage()
    {
        targetToShoot.GetComponent<IDamageable>().Damage(129000);
        if (targetToShoot.GetComponent<IDamageable>().Hull <= 0) { StopLaserAttack(); Destroy(GameObject.FindGameObjectWithTag("Reticle")); }
        }

    #endregion

    //Tinteste un obiect oarecare aplicand reticulul de tintire pe pozitia 'reticlePos'\\
    GameObject _gameobjectCurrentReticleIsOn;
    void LockTarget(RaycastHit targetRaycastInfo, Vector3 reticlePos)
    {
        GameObject instantiatedRet = GameObject.FindGameObjectWithTag("Reticle");

        if (!shipMovementScript._isMovingByMouseHold)
        {
            if (instantiatedRet == null)
            {
                instantiatedRet = Instantiate(reticle, reticlePos, Quaternion.identity) as GameObject;
                instantiatedRet.GetComponent<Reticle>().structure = targetToShoot.GetComponent<IDamageable>();
                _gameobjectCurrentReticleIsOn = targetRaycastInfo.transform.gameObject;
                targetToShoot = targetRaycastInfo.transform;
            }
            else
            {
                if (targetRaycastInfo.transform.gameObject != _gameobjectCurrentReticleIsOn)
                {
                    if (_shooting && targetRaycastInfo.transform.gameObject != _gameobjectCurrentReticleIsOn)
                    {
                        StopLaserAttack();
                    }
                    Destroy(instantiatedRet);
                    instantiatedRet = Instantiate(reticle, reticlePos, Quaternion.identity) as GameObject;
                    instantiatedRet.GetComponent<Reticle>().structure = targetToShoot.GetComponent<IDamageable>();
                    _gameobjectCurrentReticleIsOn = targetRaycastInfo.transform.gameObject;
                    targetToShoot = targetRaycastInfo.transform;
                }
            }
        }
    }
}
