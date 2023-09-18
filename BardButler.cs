using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007F3 RID: 2035
public class BardButler
{
	// Token: 0x1700094C RID: 2380
	// (get) Token: 0x06003449 RID: 13385 RVA: 0x000409FB File Offset: 0x0003EBFB
	public static BardButler Instance
	{
		get
		{
			if (BardButler._instance == null)
			{
				BardButler._instance = new BardButler();
			}
			return BardButler._instance;
		}
	}

	// Token: 0x0600344A RID: 13386 RVA: 0x000FFC44 File Offset: 0x000FDE44
	public void DrawGUI()
	{
		GUIStyle guistyle = new GUIStyle(GUI.skin.label)
		{
			fontSize = (int)BardButler.ConvertHeight(20f, false)
		};
		if (this.sortedTrackerList.Count > 0)
		{
			Rect rect = new Rect(BardButler.START_X, BardButler.ConvertHeight(140f, true), BardButler.WIDTH, BardButler.LINE_HEIGHT * (float)(2 + this.sortedTrackerList.Count) + BardButler.PADDING);
			GUI.Box(rect, (this.showDPS ? "DPS" : "HPS") + " Tracker", new GUIStyle(GUI.skin.box)
			{
				fontSize = (int)BardButler.ConvertHeight(20f, false),
				fontStyle = FontStyle.Bold
			});
			rect.x = BardButler.START_X + BardButler.PADDING;
			rect.y += BardButler.PADDING;
			rect.width = BardButler.ConvertWidth(80f, false);
			rect.height = BardButler.LINE_HEIGHT;
			GUI.Label(rect, this.myTracker.CombatFlag ? string.Format("({0:0.0})", Time.realtimeSinceStartup - this.myTracker.combatStartTime) : "-", new GUIStyle(guistyle)
			{
				alignment = TextAnchor.UpperLeft
			});
			rect.x = BardButler.START_X + BardButler.WIDTH - BardButler.PADDING - BardButler.ConvertWidth(100f, false);
			rect.width = BardButler.ConvertWidth(100f, false);
			rect.height = BardButler.LINE_HEIGHT;
			if (GUI.Button(rect, "Constant: " + (this.constantUpdate ? "on" : "off")))
			{
				this.constantUpdate = !this.constantUpdate;
			}
			rect.y += BardButler.LINE_HEIGHT;
			if (GUI.Button(rect, "Show " + (this.showDPS ? "HPS" : "DPS")))
			{
				this.showDPS = !this.showDPS;
				this.SortTrackers();
			}
			rect.x = BardButler.NAME_X;
			rect.width = BardButler.NAME_W;
			GUI.Label(rect, "Name", new GUIStyle(guistyle)
			{
				alignment = TextAnchor.MiddleRight
			});
			rect.x = BardButler.MAX_X;
			rect.width = BardButler.MAX_W;
			GUI.Label(rect, "Total", new GUIStyle(guistyle)
			{
				alignment = TextAnchor.MiddleCenter
			});
			rect.x = BardButler.DPS_X;
			rect.width = BardButler.DPS_W;
			GUI.Label(rect, this.showDPS ? "DPS" : "HPS", new GUIStyle(guistyle)
			{
				alignment = TextAnchor.MiddleLeft
			});
			rect.x = BardButler.START_X + BardButler.PADDING;
			foreach (BardButler.DamageTracker damageTracker in this.sortedTrackerList)
			{
				rect = damageTracker.DrawTracker(rect, this.sortedTrackerList[0].GetActiveStat(this.showDPS, this.constantUpdate), this.showDPS, this.constantUpdate);
			}
		}
		GUI.contentColor = Color.white;
		bool flag = this.xpList.Count > 0;
		Rect rect2 = new Rect(BardButler.PADDING * 2f, (float)Screen.height - BardButler.CHAT_HEIGHT - ((float)(flag ? 5 : 3) * BardButler.LINE_HEIGHT + BardButler.PADDING), BardButler.ConvertWidth(300f, false), (float)(flag ? 5 : 3) * BardButler.LINE_HEIGHT + BardButler.PADDING);
		GUI.Box(rect2, "Other Stats:", new GUIStyle(GUI.skin.box)
		{
			fontSize = (int)BardButler.ConvertHeight(40f, false),
			alignment = TextAnchor.UpperRight,
			fontStyle = FontStyle.Bold
		});
		Rect rect3 = rect2;
		rect3.height = BardButler.LINE_HEIGHT;
		rect3.width = BardButler.ConvertWidth(60f, false);
		rect3.x += BardButler.PADDING;
		rect3.y += BardButler.PADDING;
		if (GUI.Button(rect3, this.currentSize.ToString()))
		{
			int num = (int)this.currentSize;
			num++;
			num %= 3;
			this.currentSize = (BardButler.Size)num;
		}
		rect2.x += BardButler.PADDING;
		rect2.y += BardButler.LINE_HEIGHT * 1.5f;
		rect2.height = BardButler.LINE_HEIGHT;
		rect2.width -= 2f * BardButler.PADDING;
		GUI.Label(rect2, string.Format("Movespeed: {0:0.0}", this.CurrentMoveSpeed), new GUIStyle(guistyle)
		{
			alignment = TextAnchor.MiddleCenter
		});
		if (flag)
		{
			if (Time.realtimeSinceStartup - this.xpList[0].Item1 > this.XP_TIMER && !this.ProcessXPList())
			{
				return;
			}
			rect2.y += BardButler.LINE_HEIGHT;
			rect2.width /= 2f;
			GUI.Label(rect2, "XP / 10m", new GUIStyle(guistyle)
			{
				fontSize = (int)BardButler.ConvertHeight(20f, false),
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.LowerCenter
			});
			rect2.y += BardButler.LINE_HEIGHT;
			GUI.Label(rect2, this.processedXP, new GUIStyle(guistyle)
			{
				fontSize = (int)BardButler.ConvertHeight(30f, false),
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.MiddleCenter
			});
			rect2.x += rect2.width;
			rect2.y -= BardButler.LINE_HEIGHT / 2f;
			if (GUI.Button(rect2, "Clear XP"))
			{
				this.ClearXP();
			}
		}
	}

	// Token: 0x0600344B RID: 13387 RVA: 0x00040A13 File Offset: 0x0003EC13
	public void RegisterXP(float incomingXp)
	{
		this.xpList.Add(new ValueTuple<float, float>(Time.realtimeSinceStartup, incomingXp));
		this.ProcessXPList();
	}

	// Token: 0x0600344C RID: 13388 RVA: 0x00100224 File Offset: 0x000FE424
	public bool ProcessXPList()
	{
		this.xpTotal = 0f;
		for (int i = this.xpList.Count - 1; i >= 0; i--)
		{
			ValueTuple<float, float> valueTuple = this.xpList[i];
			if (Time.realtimeSinceStartup - valueTuple.Item1 >= this.XP_TIMER)
			{
				this.xpList.RemoveAt(i);
			}
			else
			{
				this.xpTotal += valueTuple.Item2;
			}
		}
		if (this.xpList.Count == 0)
		{
			return false;
		}
		this.oldestXP = Time.realtimeSinceStartup - this.xpList[0].Item1;
		this.processedXP = string.Format("{0:0.0}", this.xpTotal / (Mathf.Max(this.oldestXP, 1f) / this.XP_TIMER));
		return true;
	}

	// Token: 0x0600344D RID: 13389 RVA: 0x00040A32 File Offset: 0x0003EC32
	public void UpdateShownMovespeed(float movespeed)
	{
		this.CurrentMoveSpeed = movespeed;
	}

	// Token: 0x0600344E RID: 13390 RVA: 0x00040A3B File Offset: 0x0003EC3B
	private void ClearXP()
	{
		this.xpList.Clear();
		this.xpTotal = 0f;
	}

	// Token: 0x1700094D RID: 2381
	// (get) Token: 0x0600344F RID: 13391 RVA: 0x00040A53 File Offset: 0x0003EC53
	public static float LINE_HEIGHT
	{
		get
		{
			return BardButler.ConvertHeight(30f, false);
		}
	}

	// Token: 0x1700094E RID: 2382
	// (get) Token: 0x06003450 RID: 13392 RVA: 0x00040A60 File Offset: 0x0003EC60
	public static float PADDING
	{
		get
		{
			return BardButler.ConvertWidth(5f, false);
		}
	}

	// Token: 0x1700094F RID: 2383
	// (get) Token: 0x06003451 RID: 13393 RVA: 0x00040A6D File Offset: 0x0003EC6D
	public static float WIDTH
	{
		get
		{
			return BardButler.ConvertWidth(400f, false);
		}
	}

	// Token: 0x17000950 RID: 2384
	// (get) Token: 0x06003452 RID: 13394 RVA: 0x00040A7A File Offset: 0x0003EC7A
	public static float BOX_HEIGHT
	{
		get
		{
			return BardButler.ConvertHeight(140f, false);
		}
	}

	// Token: 0x17000951 RID: 2385
	// (get) Token: 0x06003453 RID: 13395 RVA: 0x00040A87 File Offset: 0x0003EC87
	public static float MINIMAP_WIDTH
	{
		get
		{
			return BardButler.ConvertWidth(300f, true);
		}
	}

	// Token: 0x06003454 RID: 13396 RVA: 0x00040A94 File Offset: 0x0003EC94
	public void RegisterDamage(LivingEntity source, float amount)
	{
		if (Global.MyPlayer == source || Global.MyPlayer.Party.Members.Contains(source.UID))
		{
			this.AddTracker(source.UID).RegisterDamage(amount);
			this.SortTrackers();
		}
	}

	// Token: 0x06003455 RID: 13397 RVA: 0x00040AD2 File Offset: 0x0003ECD2
	public void RegisterHealing(int sourceUID, float amount)
	{
		if (sourceUID == Global.MyPlayerUID || Global.MyPlayer.Party.Members.Contains(sourceUID))
		{
			this.AddTracker(sourceUID).RegisterHealing(amount);
			this.SortTrackers();
		}
	}

	// Token: 0x17000952 RID: 2386
	// (get) Token: 0x06003456 RID: 13398 RVA: 0x001002F8 File Offset: 0x000FE4F8
	public static Texture2D BlankTex
	{
		get
		{
			if (BardButler._blankTex == null)
			{
				Color[] array = new Color[(int)BardButler.WIDTH * (int)BardButler.LINE_HEIGHT];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Color.white;
				}
				BardButler._blankTex = new Texture2D((int)BardButler.LINE_HEIGHT, (int)BardButler.WIDTH);
				BardButler._blankTex.SetPixels(array);
				BardButler._blankTex.Apply();
			}
			return BardButler._blankTex;
		}
	}

	// Token: 0x17000953 RID: 2387
	// (get) Token: 0x06003457 RID: 13399 RVA: 0x00040B06 File Offset: 0x0003ED06
	public static float START_X
	{
		get
		{
			return (float)Screen.width - BardButler.MINIMAP_WIDTH - BardButler.WIDTH - BardButler.PADDING;
		}
	}

	// Token: 0x17000954 RID: 2388
	// (get) Token: 0x06003458 RID: 13400 RVA: 0x00040B20 File Offset: 0x0003ED20
	public static float NAME_X
	{
		get
		{
			return BardButler.START_X + BardButler.PADDING;
		}
	}

	// Token: 0x17000955 RID: 2389
	// (get) Token: 0x06003459 RID: 13401 RVA: 0x00040B2D File Offset: 0x0003ED2D
	public static float NAME_W
	{
		get
		{
			return BardButler.ConvertWidth(80f, false);
		}
	}

	// Token: 0x17000956 RID: 2390
	// (get) Token: 0x0600345A RID: 13402 RVA: 0x00040B3A File Offset: 0x0003ED3A
	public static float MAX_X
	{
		get
		{
			return BardButler.NAME_X + BardButler.NAME_W + BardButler.PADDING;
		}
	}

	// Token: 0x17000957 RID: 2391
	// (get) Token: 0x0600345B RID: 13403 RVA: 0x00040B4D File Offset: 0x0003ED4D
	public static float MAX_W
	{
		get
		{
			return BardButler.ConvertWidth(60f, false);
		}
	}

	// Token: 0x17000958 RID: 2392
	// (get) Token: 0x0600345C RID: 13404 RVA: 0x00040B5A File Offset: 0x0003ED5A
	public static float DPS_X
	{
		get
		{
			return BardButler.MAX_X + BardButler.MAX_W + BardButler.PADDING;
		}
	}

	// Token: 0x17000959 RID: 2393
	// (get) Token: 0x0600345D RID: 13405 RVA: 0x00040B6D File Offset: 0x0003ED6D
	public static float DPS_W
	{
		get
		{
			return BardButler.START_X + BardButler.WIDTH - BardButler.PADDING - BardButler.DPS_X;
		}
	}

	// Token: 0x0600345E RID: 13406 RVA: 0x00100370 File Offset: 0x000FE570
	private BardButler.DamageTracker AddTracker(int sourceUID)
	{
		BardButler.DamageTracker damageTracker;
		if (!this.TrackerDict.TryGetValue(sourceUID, out damageTracker))
		{
			damageTracker = new BardButler.DamageTracker(sourceUID);
			if (sourceUID == Global.MyPlayerUID)
			{
				this.myTracker = damageTracker;
			}
			this.TrackerDict.Add(sourceUID, damageTracker);
		}
		return damageTracker;
	}

	// Token: 0x0600345F RID: 13407 RVA: 0x001003B4 File Offset: 0x000FE5B4
	private void SortTrackers()
	{
		foreach (KeyValuePair<int, BardButler.DamageTracker> keyValuePair in this.TrackerDict)
		{
			if (keyValuePair.Key != Global.MyPlayerUID && !Global.MyPlayer.Party.Members.Contains(keyValuePair.Key))
			{
				this.TrackerDict.Remove(keyValuePair.Key);
			}
		}
		if (this.TrackerDict != null && this.TrackerDict.Count != 0)
		{
			this.sortedTrackerList.Clear();
			this.sortedTrackerList.AddRange(this.TrackerDict.Values);
			this.sortedTrackerList.Sort((BardButler.DamageTracker v1, BardButler.DamageTracker v2) => (v1.CombatFlag ? v1.GetActiveStat(this.showDPS, this.constantUpdate) : 0f).CompareTo(v2.CombatFlag ? v2.GetActiveStat(this.showDPS, this.constantUpdate) : 0f));
			this.sortedTrackerList.Reverse();
		}
	}

	// Token: 0x06003460 RID: 13408 RVA: 0x00100498 File Offset: 0x000FE698
	private static float GetSizeFactor()
	{
		switch (BardButler.Instance.currentSize)
		{
		case BardButler.Size.Normal:
			return 1f;
		case BardButler.Size.Large:
			return 1.15f;
		case BardButler.Size.XLarge:
			return 1.3f;
		default:
			return 1f;
		}
	}

	// Token: 0x06003461 RID: 13409 RVA: 0x001004DC File Offset: 0x000FE6DC
	public static float ConvertHeight(float height, bool layout = false)
	{
		if (layout)
		{
			return (float)Screen.height / 1440f * height * (ClientSettings.LocalSettings.UiSettings.UIScale / 100f);
		}
		return (float)Screen.height / 1440f * height * (ClientSettings.LocalSettings.UiSettings.UIScale / 100f) * BardButler.GetSizeFactor();
	}

	// Token: 0x06003462 RID: 13410 RVA: 0x0010053C File Offset: 0x000FE73C
	public static float ConvertWidth(float width, bool layout = false)
	{
		if (layout)
		{
			return (float)Screen.width / 2560f * width * (ClientSettings.LocalSettings.UiSettings.UIScale / 100f);
		}
		return (float)Screen.height / 1440f * width * (ClientSettings.LocalSettings.UiSettings.UIScale / 100f) * BardButler.GetSizeFactor();
	}

	// Token: 0x1700095A RID: 2394
	// (get) Token: 0x06003463 RID: 13411 RVA: 0x00040B86 File Offset: 0x0003ED86
	public static float CHAT_HEIGHT
	{
		get
		{
			return BardButler.ConvertHeight(350f, true);
		}
	}

	// Token: 0x04002D2B RID: 11563
	private static BardButler _instance;

	// Token: 0x04002D2C RID: 11564
	private float xpTotal;

	// Token: 0x04002D2D RID: 11565
	private List<ValueTuple<float, float>> xpList = new List<ValueTuple<float, float>>();

	// Token: 0x04002D2E RID: 11566
	private float oldestXP;

	// Token: 0x04002D2F RID: 11567
	private float XP_TIMER = 600f;

	// Token: 0x04002D30 RID: 11568
	private float CurrentMoveSpeed = 1f;

	// Token: 0x04002D31 RID: 11569
	private string processedXP;

	// Token: 0x04002D32 RID: 11570
	private Dictionary<int, BardButler.DamageTracker> TrackerDict = new Dictionary<int, BardButler.DamageTracker>();

	// Token: 0x04002D33 RID: 11571
	private List<BardButler.DamageTracker> sortedTrackerList = new List<BardButler.DamageTracker>();

	// Token: 0x04002D34 RID: 11572
	private static Texture2D _blankTex;

	// Token: 0x04002D35 RID: 11573
	private bool constantUpdate;

	// Token: 0x04002D36 RID: 11574
	private BardButler.DamageTracker myTracker;

	// Token: 0x04002D37 RID: 11575
	private bool showDPS = true;

	// Token: 0x04002D38 RID: 11576
	private BardButler.Size currentSize;

	// Token: 0x020007F4 RID: 2036
	private class DamageTracker
	{
		// Token: 0x06003466 RID: 13414 RVA: 0x00100648 File Offset: 0x000FE848
		public void RegisterDamage(float incomingDamage)
		{
			if (this.CombatCheck())
			{
				this.DamageTotal.Item1 = this.DamageTotal.Item1 + incomingDamage;
				this.DamageTotal.Item2 = Time.realtimeSinceStartup;
				this.staleDPS = this.DamageTotal.Item1 / Mathf.Max(this.DamageTotal.Item2 - this.combatStartTime, 1f);
			}
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x001006B4 File Offset: 0x000FE8B4
		public void RegisterHealing(float incomingHeals)
		{
			if (this.CombatCheck())
			{
				this.HealingTotal.Item1 = this.HealingTotal.Item1 + incomingHeals;
				this.HealingTotal.Item2 = Time.realtimeSinceStartup;
				this.staleHPS = this.HealingTotal.Item1 / Mathf.Max(this.HealingTotal.Item2 - this.combatStartTime, 1f);
			}
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x00100720 File Offset: 0x000FE920
		public DamageTracker(int playerUID)
		{
			this.myPlayerUID = playerUID;
			this.myEntity = (LivingEntity)EntityManager.GetEntity(playerUID);
			this.combatStartTime = Time.realtimeSinceStartup;
			this.DamageTotal = new ValueTuple<float, float>(0f, this.combatStartTime);
			this.HealingTotal = new ValueTuple<float, float>(0f, this.combatStartTime);
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x00100798 File Offset: 0x000FE998
		public Rect DrawTracker(Rect startingRect, float highestStat, bool showDPS, bool constantUpdate)
		{
			GUIStyle guistyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = (int)BardButler.ConvertHeight(15f, false)
			};
			Rect rect = startingRect;
			rect.height = BardButler.LINE_HEIGHT;
			rect.width = BardButler.NAME_W;
			rect.x = BardButler.NAME_X;
			rect.y += BardButler.LINE_HEIGHT;
			GUI.color = (this.myEntity.InCombat ? Color.white : new Color(0.5f, 0.5f, 0.5f));
			GUI.Label(rect, this.myEntity.Name, new GUIStyle(guistyle)
			{
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.MiddleRight
			});
			rect.x = BardButler.MAX_X;
			rect.width = BardButler.MAX_W;
			GUI.Label(rect, string.Format("{0:0}", (showDPS ? this.DamageTotal : this.HealingTotal).Item1), new GUIStyle(guistyle)
			{
				alignment = TextAnchor.MiddleCenter
			});
			float num = (this.myEntity.InCombat ? Mathf.Min(1f, this.GetActiveStat(showDPS, constantUpdate) / highestStat) : 0f);
			rect.width = num * BardButler.DPS_W;
			rect.x = BardButler.DPS_X;
			rect.height = BardButler.LINE_HEIGHT * 0.7f;
			rect.y += BardButler.LINE_HEIGHT * 0.15f;
			GUI.DrawTexture(rect, BardButler.BlankTex, ScaleMode.StretchToFill, false, 1f, this.myEntity.InCombat ? Color.Lerp(Color.white, Color.green, num) : new Color(0.5f, 0.5f, 0.5f), 0f, 0f);
			rect.y -= BardButler.LINE_HEIGHT * 0.15f;
			rect.height = BardButler.LINE_HEIGHT;
			rect.width = BardButler.DPS_W;
			rect.x += BardButler.PADDING;
			GUI.color = (this.myEntity.InCombat ? Color.black : Color.white);
			GUI.Label(rect, string.Format("{0:0.0} {1}", this.GetActiveStat(showDPS, constantUpdate), this.myEntity.InCombat ? "" : "Out Of Combat"), new GUIStyle(guistyle)
			{
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.MiddleLeft
			});
			GUI.color = Color.white;
			if (this.CombatFlag)
			{
				if (!this.myEntity.InCombat)
				{
					this.CombatFlag = false;
				}
				else
				{
					this.mostRecentTime = Time.realtimeSinceStartup;
				}
			}
			return rect;
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x00100A44 File Offset: 0x000FEC44
		public float GetActiveStat(bool showDPS, bool constant)
		{
			if (constant)
			{
				return (showDPS ? this.DamageTotal.Item1 : this.HealingTotal.Item1) / Mathf.Max(this.mostRecentTime - this.combatStartTime, 1f);
			}
			if (!showDPS)
			{
				return this.staleHPS;
			}
			return this.staleDPS;
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x00100A98 File Offset: 0x000FEC98
		private bool CombatCheck()
		{
			if (!this.CombatFlag && this.myEntity.InCombat)
			{
				this.CombatFlag = true;
				this.combatStartTime = Time.realtimeSinceStartup;
				this.HealingTotal = new ValueTuple<float, float>(0f, this.combatStartTime);
				this.DamageTotal = new ValueTuple<float, float>(0f, this.combatStartTime);
			}
			return this.CombatFlag;
		}

		// Token: 0x04002D39 RID: 11577
		private ValueTuple<float, float> DamageTotal;

		// Token: 0x04002D3A RID: 11578
		private ValueTuple<float, float> HealingTotal;

		// Token: 0x04002D3B RID: 11579
		public float combatStartTime;

		// Token: 0x04002D3C RID: 11580
		private float mostRecentTime;

		// Token: 0x04002D3D RID: 11581
		private Color DPSColor = Color.white;

		// Token: 0x04002D3E RID: 11582
		private Color HPSColor = Color.white;

		// Token: 0x04002D3F RID: 11583
		private int myPlayerUID;

		// Token: 0x04002D40 RID: 11584
		private LivingEntity myEntity;

		// Token: 0x04002D41 RID: 11585
		private float staleDPS;

		// Token: 0x04002D42 RID: 11586
		private float staleHPS;

		// Token: 0x04002D43 RID: 11587
		public bool CombatFlag;
	}

	// Token: 0x020007F5 RID: 2037
	private enum Size
	{
		// Token: 0x04002D45 RID: 11589
		Normal,
		// Token: 0x04002D46 RID: 11590
		Large,
		// Token: 0x04002D47 RID: 11591
		XLarge
	}
}
