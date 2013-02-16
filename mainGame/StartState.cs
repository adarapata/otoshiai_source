using UnityEngine;
using System.Collections;

public class StartState : IState
{
    private MainGameManager parent;
    //�u�J�n�v�̕���
    private GameObject startWord;
    public StartState(MainGameManager manager)
    {
        parent = manager;
        parent.StartCoroutine(StartCount());

        startWord = Resources.Load("Objects/word/StartWord") as GameObject;
    }

    public System.Type Update()
    {
        return null;
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

        parent.SetNextState(typeof(PlayingState));

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
