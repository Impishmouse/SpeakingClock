﻿using System.Collections.Generic;
 using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = nameof(AudioConfig), menuName = "ScriptableObjects/Audio/Config")]
	public class AudioConfig : ScriptableObjectSigletone<AudioConfig>
	{
		public List<AudioData> config;

		public AudioClip One;
		public AudioClip Two;
		public AudioClip Three;
		public AudioClip Fore;
		public AudioClip Five;
		public AudioClip Six;
		public AudioClip Seven;
		public AudioClip Eight;
		public AudioClip Nine;
		public AudioClip Ten;
		public AudioClip Eleven;
		public AudioClip Twelve;
		public AudioClip Thirteen;
		public AudioClip Fourteen;
		public AudioClip Fiveteen;
		public AudioClip Sixteen;
		public AudioClip Seventeen;
		public AudioClip Eighteen;
		public AudioClip Nineteen;
		
		public AudioClip Twenty;
		public AudioClip TwentyOne;
		public AudioClip TwentySecond;
		public AudioClip TwentyThird;
		public AudioClip TwentyFourth;
		public AudioClip ThirtyMsinutes;
		public AudioClip StartRing;
		
		
		public AudioClip Atmosphere;
		public AudioClip Clear;
		public AudioClip Clouds;
		public AudioClip Drizzle;
		public AudioClip Rain;
		public AudioClip Snow;
		public AudioClip Thunderstorm;
		
		
		
		
	}
}
