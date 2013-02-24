using UnityEngine;
using System.Collections;

public class StartState : IState
{
    private MainGameManager parent;
    //�u�J�n�v�̕���
    private GameObject startWord;

    public int name { get { return (int)MainGameManager.STATENAME.Start; } }

    public StartState(MainGameManager manager)
    {
        parent = manager;
        parent.StartCoroutine(StartCount());

        startWord = Resources.Load("Objects/word/StartWord") as GameObject;
    }

    public int Update()
    {
        return (int)MainGameManager.STATENAME.Changeless;
    }

    /// <summary>
    /// �ŏ��̒�~���Ԃ̃R���[�`��
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

        parent.SetNextState(MainGameManager.STATENAME.Playing);

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