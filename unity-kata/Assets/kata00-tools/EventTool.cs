using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventTool
{
    /// <summary>
    /// 添加事件触发回调
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="eventTriggerType"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public static bool TryAddEventCallback(EventTrigger trigger, EventTriggerType eventTriggerType, UnityAction<BaseEventData> callback)
    {
        if (trigger == null)
        {
            return false;
        }

        UnityAction<BaseEventData> action = new UnityAction<BaseEventData>(callback);

        EventTrigger.Entry entry = new EventTrigger.Entry();
        //指定事件触发的类型
        entry.eventID = EventTriggerType.PointerClick;
        //指定事件触发的方法
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        //初始化EventTrigger.Entry容器
        if (trigger.triggers == null)
        {
            trigger.triggers = new List<EventTrigger.Entry>();
        }
        trigger.triggers.Add(entry);
        return true;
    }
}
