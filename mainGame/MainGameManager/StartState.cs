using UnityEngine;
using System.Collections;

public partial class MainGameManager : MonoBehaviour
{
    protected class StartState : IState
    {
        private MainGameManager parent;
        //「開始」の文字
        private GameObject startWord;

        public int name { get { return (int)STATENAME.Start; } }

        public StartState(MainGameManager manager)
        {
            parent = manager;
            parent.StartCoroutine(StartCount());

            startWord = Resources.Load("Objects/word/StartWord") as GameObject;
        }

        public int Update()
        {
            return (int)STATENAME.Changeless;
        }

        /// <summary>
        /// 最初の停止時間のコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartCount()
        {
            MainGameParameter.instance.Pause = true;


            yield return new WaitForSeconds(1);

            var coopys = CreateWord();
            SoundManager.Play(SoundManager.gameStart);
            yield return new WaitForSeconds(1);

            GameObject.Destroy(coopys);

            parent.SetNextState(STATENAME.Playing);

            MainGameParameter.instance.Pause = false;
        }

        private GameObject CreateWord()
        {
            var word = GameObject.Instantiate(startWord) as GameObject;
            word.transform.parent = GameObject.Find("WindowPanel").transform;
            word.transform.localScale = Vector3.one;
            return word;
        }
    }
}
