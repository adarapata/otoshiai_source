using UnityEngine;
using System.Collections;

public class MapChipAnimationController : IAnimationController
{
    private const string MAPCHIP = "mapchip";

    public UISprite sprite
    {
        get;
        set;
    }

    public AnimationParameter parameter
    {
        get;
        set;
    }

    public MapChipAnimationController(UISprite targetSprite)
    {
        sprite = targetSprite;
        var list = targetSprite.atlas.GetListOfSprites();
        parameter = new AnimationParameter(list);
        parameter.pattern = MAPCHIP;
    }

    public void ChangeFrame(bool isLoop)
    {
        sprite.spriteName = parameter.NextFrame(false);
    }

    /// <summary>
    /// �}�b�v�`�b�v�ɂ̓p�^�[���������̂ŉ������Ȃ�
    /// </summary>
    /// <param name="patternName"></param>
    /// <returns></returns>
    public bool ChangePattern(string patternName)
    {
        return true;
    }
}