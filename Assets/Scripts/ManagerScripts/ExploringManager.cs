using System.Collections;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace ManagerScripts
{
    public class ExploringManager : MonoBehaviour
    {
        [SerializeField] private SoEnemy startingEnemy;
        [SerializeField] private SoEnemy rightEnemy;
        [SerializeField] private SoEnemy leftEnemy;
        [SerializeField] private DungeonManager dungeonManager;
        [SerializeField] private SwipeControl swipe;
        public bool waitingForNextCombat;

        private void Start()
        {
            dungeonManager.NextCombat(startingEnemy);
            swipe.SwipeToTheLeft += LeftCombat;
            swipe.SwipeToTheRight += RightCombat;
            dungeonManager.WinTheCombat += start5secondCourutine;
        }

        public void LeftCombat()
        {
            if(waitingForNextCombat)
                dungeonManager.NextCombat(leftEnemy);
            waitingForNextCombat = false;
        }

        public void RightCombat()
        {
            if(waitingForNextCombat)
                dungeonManager.NextCombat(rightEnemy);
            waitingForNextCombat = false;
        }

        void start5secondCourutine()
        {
            StartCoroutine(Waitfor5secodns());
        }
        IEnumerator Waitfor5secodns()
        {
            yield return new WaitForSeconds(5);
            waitingForNextCombat = true;
        }
    }
}
