using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//������ǉ�
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController:MonoBehaviour
{
    //�{�^�������N���b�N�����Scene�uStory�v�֑J��
    public void ButtonClick()
    {
        SceneManager.LoadScene("Story");
    }
}