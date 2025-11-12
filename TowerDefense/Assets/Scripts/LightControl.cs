using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制光源，随着时间的流逝对光源按一定速率旋转，实现白天黑夜的效果。
// 修改：启动时根据场景中当前 Directional Light 的朝向计算起始 timeOfDay（而不是固定从黑夜开始）。
public class LightControl : MonoBehaviour
{
    [Header("时间设置")]
    [Tooltip("完成一次昼夜循环所需的秒数（秒）。")]
    public float dayDuration = 120f; // 一天的长度（秒）

    [Tooltip("当前一天中时间的位置（0 到 1）。0 和 1 表示同一时刻）。")]
    [Range(0f, 1f)]
    public float timeOfDay = 0f; // 归一化时间（0..1）

    [Tooltip("是否自动推进时间。关闭后可以手动修改 timeOfDay。")]
    public bool autoAdvance = true;

    [Header("光照与颜色")]
    [Tooltip("用于缩放方向光强度的倍数（便于微调）。")]
    public float intensityMultiplier = 1f;

    [Tooltip("白天方向光颜色。")]
    public Color dayColor = Color.white;

    [Tooltip("夜晚方向光颜色。")]
    public Color nightColor = new Color(0.05f, 0.05f, 0.2f);

    // 缓存的 Light 组件引用
    private Light _light;

    // 启动时记录的 Y,Z 分量，用于保持场景中光源的水平方向（避免强制替换为固定 170）
    private float _initialY;
    private float _initialZ;

    void Start()
    {
        // 获取当前对象上的 Light（通常将该脚本挂在 Directional Light 上）
        _light = GetComponent<Light>();
        if (_light == null)
        {
            Debug.LogWarning("[LightControl] 未在此 GameObject 上找到 Light 组件，脚本将仅改变 Transform 旋转。");
        }

        // 读取当前 Transform 的朝向并据此计算起始 timeOfDay，
        // 使脚本启动时从场景中现有光源方向继续（而不是固定从夜间开始）。
        Vector3 euler = transform.eulerAngles;
        _initialY = euler.y;
        _initialZ = euler.z;

        // 反推 timeOfDay：在 Update 中我们使用 sunAngle = timeOfDay * 360 - 90
        // 所以 timeOfDay = (sunAngle + 90) / 360
        float sunAngle = euler.x; // Unity 的 Euler.x 范围为 [0,360)
        timeOfDay = Mathf.Repeat((sunAngle + 90f) / 360f, 1f);
    }

    void Update()
    {
        // 自动推进时间
        if (autoAdvance && dayDuration > 0f)
        {
            timeOfDay += Time.deltaTime / dayDuration;
            if (timeOfDay > 1f) timeOfDay -= 1f; // 循环回到 0..1
        }

        // 计算太阳（方向光）的角度。
        // 映射：timeOfDay = 0 -> -90°（午夜/日出前），timeOfDay = 0.5 -> 90°（正午）
        float sunAngle = timeOfDay * 360f - 90f;

        // 使用启动时记录的 Y,Z 分量保持场景中原有的水平朝向
        transform.rotation = Quaternion.Euler(sunAngle, _initialY, _initialZ);

        // 根据时间计算光强（0 在夜间，1 在中午），使用正弦曲线使过渡更自然
        float dayFactor = Mathf.Clamp01(Mathf.Sin(timeOfDay * Mathf.PI));
        float intensity = dayFactor * intensityMultiplier;

        // 应用到 Light（如果存在）
        if (_light != null)
        {
            _light.intensity = intensity;
            _light.color = Color.Lerp(nightColor, dayColor, dayFactor);
        }

        // 同步环境光颜色以增强白天/夜晚感（使用线性插值）
        RenderSettings.ambientLight = Color.Lerp(nightColor * 0.35f, dayColor * 0.6f, dayFactor);
    }
}
