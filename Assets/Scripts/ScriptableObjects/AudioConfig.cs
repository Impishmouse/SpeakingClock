﻿using System.Collections.Generic;
 using System.Linq;
 using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = nameof(AudioConfig), menuName = "ScriptableObjects/Audio/Config")]
	public class AudioConfig : ScriptableObjectSigletone<AudioConfig>
	{
		public List<AudioData> config;

		public AudioClip StartRing;
		
		public AudioClip Atmosphere;
		public AudioClip Clear;
		public AudioClip Clouds;
		public AudioClip Drizzle;
		public AudioClip Rain;
		public AudioClip Snow;
		public AudioClip Thunderstorm;

		public AudioData GetAudioByType(AudioData.AudioType audioType)
		{
			return config.Find( x => x.audioType == audioType);
		}


	}
}
