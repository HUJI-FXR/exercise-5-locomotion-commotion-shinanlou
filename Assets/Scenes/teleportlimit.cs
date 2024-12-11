using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportWithLimit : MonoBehaviour
{
    private int teleportCount = 0;  // מספר הפעמים שבוצע טלפורט
    public int maxTeleports = 3;    // המגבלה של 3 טלפורים

    private TeleportationProvider teleportationProvider;  // הפניה ל-TeleportationProvider

    void Start()
    {
        teleportationProvider = GetComponent<TeleportationProvider>();  // אם הסקריפט מחובר לאובייקט זה
    }

    void Update()
    {
        // אם עדיין יש לנו אפשרות טלפורט והכפתור נלחץ
        if (teleportCount < maxTeleports && Input.GetButtonDown("Teleport"))
        {
            teleportationProvider.enabled = true;  // אפשר את הטלפורט
            teleportCount++;  // עדכון מספר הטלפורים שבוצעו
        }
        else if (teleportCount >= maxTeleports)
        {
            teleportationProvider.enabled = false;  // השבת את הטלפורט אם עברנו את המגבלה
            Debug.Log("Teleport limit reached!");  // הצגת הודעה במידה והגעת למגבלה
        }
    }
}
