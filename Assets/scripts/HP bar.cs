using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbar : MonoBehaviour
{
    [SerializeField] float ScaleAmount = 0.001f;
    [SerializeField] float yOffset = 1f;
    Entity entity;
    Slider slider;
    TextMeshProUGUI valueText;
    TextMeshProUGUI nameText;

    void Awake()
    {
        entity = FindAnyObjectByType<Entity>();
        slider = GetComponent<Slider>();
        valueText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        nameText = GetComponentsInChildren<TextMeshProUGUI>()[1];

        Vector3 pos = transform.position;
        pos.y += yOffset;
        transform.position = pos;
    }

    void updateHpBar()
    {
        if(entity == null || slider == null || valueText == null)
            return;

        slider.value = entity.getCurrentHP() / entity.getMaxHP();

        valueText.text = entity.getCurrentHP().ToString("0") + "/" + entity.getMaxHP().ToString("0");
        nameText.text = entity.getName();
    }

    void scaleSize()
    {
        float scale = Vector3.Distance(transform.position, Camera.main.transform.position) * ScaleAmount;
        transform.localScale = Vector3.one * scale;
    }

    void lookAtentity()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0); //it defaults looking away from the camera, so rotate it
    }

    void Update()
    {
        updateHpBar();
        scaleSize();
        lookAtentity();
    }
}
