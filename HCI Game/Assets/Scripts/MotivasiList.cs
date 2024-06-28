using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotivasiList : MonoBehaviour
{
    public TMP_Text displayText;
    private string[] texts = 
    {
        "Kegagalan adalah Kesempatan untuk memulai lagi dengan lebih cerdas\nHenry Ford",
        "Kesuksesan adalah kemampuan untuk berpindah dari satu kegagalan ke kegagalan berikutnya tanpa kehilangan antusiasme\nWinston Churchill",
        "Jangan biarkan kegagalan kemarin menguasai mimpi-mimpi hari ini\nJohn Wooden",
        "Kegagalan adalah bumbu yang memberikan rasa pada kesuksesan\nTruman Capote",
        "Orang yang tidak pernah membuat kesalahan tidak pernah mencoba sesuatu yang baru\nAlbert Einstein"
    };

    private int currentTextIndex = 0;

    void Start()
    {
        currentTextIndex = PlayerPrefs.GetInt("LastTextIndex", 0);

        int newIndex;
        do
        {
            newIndex = Random.Range(0, texts.Length);
        } while (newIndex == currentTextIndex);

        displayText.text = texts[newIndex];

        PlayerPrefs.SetInt("LastTextIndex", newIndex);
    }
}
