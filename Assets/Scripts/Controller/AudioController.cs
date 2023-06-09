using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace Controllers
{
	public class AudioController : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField] private AudioSource musicSource;
#pragma warning restore 0649

		private List<AudioSource> audioSources;

		private Tweener musicTweener = null;

		private void Awake()
		{
			musicSource.volume = 0f;
			musicSource.loop = true;
			//musicSource.mute = !PlayerData.IsMusic;

			audioSources = new List<AudioSource>();

			for (var i = 0; i < 10; i++)
			{
				var source = gameObject.AddComponent<AudioSource>();
				source.enabled = false;
				audioSources.Add(source);
			}
		}

		#region Music

		public void ToggleMusic()
		{
			//PlayerData.IsMusic = !PlayerData.IsMusic;
			//musicSource.mute = !PlayerData.IsMusic;
		}

		public void PlayMusic(AudioClip clip, float? doVolumeTime = null)
		{
			var sameClipIsPLaying = musicSource.isPlaying && musicSource.clip == clip;

			if (!sameClipIsPLaying)
			{
				StopMusic();
			}

			if (clip == null)
			{
				return;
			}

			musicTweener?.Kill();

			if (musicSource.clip != clip)
			{
				musicSource.clip = clip;
			}

			if (!musicSource.isPlaying)
			{
				musicSource.Play();
			}

			if (doVolumeTime.HasValue)
			{
				musicTweener = DOVirtual.Float(musicSource.volume, 1f, doVolumeTime.Value,
						value => musicSource.volume = value)
					.SetUpdate(true);
			}
		}

		public void StopMusic(float? doVolumeTime = null)
		{
			if (doVolumeTime.HasValue && musicSource != null)
			{
				musicTweener?.Kill();
				musicTweener = DOVirtual
					.Float(musicSource.volume, 0f, doVolumeTime.Value, value => musicSource.volume = value)
					.SetUpdate(true);
			}
			else
			{
				musicSource.Stop();
			}
		}

		#endregion

		#region Sounds

		public void ToggleSounds()
		{
			//PlayerData.IsSound = !PlayerData.IsSound;
			
			audioSources.ForEach(s =>
			{
				if (s.enabled)
				{
					s.Stop();
					s.enabled = false;
				}
			});
		}

		public void PlaySound(AudioClip clip, TweenCallback callback = null)
		{
			var audioSource = GetFreeSource();

			audioSource.clip = clip;
			//audioSource.mute = !PlayerData.IsSound;
			
			if (clip != null)
			{
				audioSource.enabled = true;
				audioSource.Play();
				//DOVirtual.DelayedCall(audioSource.clip.length, () => audioSource.enabled = false);
				DOVirtual.DelayedCall(audioSource.clip.length, () =>
				{
					audioSource.enabled = false;
					callback?.Invoke();
				});
			}
		}

		private AudioSource GetFreeSource()
		{
			var source = audioSources.Find(s => !s.enabled);

			if (source != null)
			{
				return source;
			}
			
			source = gameObject.AddComponent<AudioSource>();
			source.enabled = false;
			audioSources.Add(source);

			return source;
		}

		#endregion
		
	}
}