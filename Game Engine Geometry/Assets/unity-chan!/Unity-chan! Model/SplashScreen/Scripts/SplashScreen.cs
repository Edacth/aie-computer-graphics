#pragma warning disable 0618
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	[ExecuteInEditMode]
	public class SplashScreen : MonoBehaviour
	{
		void NextLevel ()
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
#pragma warning restore 0618