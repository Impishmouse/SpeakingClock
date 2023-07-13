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
		
		public AudioData GetAudioByType(AudioData.AudioType audioType)
		{
			return config.Find( x => x.audioType == audioType);
		}


	}
}
