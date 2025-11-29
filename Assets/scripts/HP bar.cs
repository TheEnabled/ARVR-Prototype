using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbar : MonoBehaviour
{
    Player player;
    Slider slider;
    TextMeshProUGUI text;

    void Awake()
    {
        player = FindAnyObjectByType<Player>();
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void updateHpBar()
    {
        if(player == null || slider == null || text == null)
            return;

        slider.value = player.getCurrentHP() / player.getMaxHP();

        text.text = player.getCurrentHP().ToString("0") + "/" + player.getMaxHP().ToString("0");
    }

    void scaleSize()
    {
        float scale = Vector3.Distance(transform.position, Camera.main.transform.position) * 0.05f;
        transform.localScale = Vector3.one * scale;
    }

    void Update()
    {
        updateHpBar();
        scaleSize();
        transform.LookAt(Camera.main.transform);
    }
}
