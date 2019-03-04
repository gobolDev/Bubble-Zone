using UnityEngine;
/// <summary>
/// Updates DataCtrl so that it provides the most recent data. This script is used in CampainMap Scene.
/// </summary>
public class RefreshCtrl : MonoBehaviour
{
	private void Awake ()
    {
        DataCtrl.instance.RefreshData();
	}
}
