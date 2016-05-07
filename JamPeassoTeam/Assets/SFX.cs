public static class SFX {
	private static System.Collections.Generic.Dictionary<string, UnityEngine.AudioClip> dictionary = new System.Collections.Generic.Dictionary<string, UnityEngine.AudioClip>();
	public static void play(string name, float volume = 0.5F) {
		if(!dictionary.ContainsKey(name))
			dictionary.Add(name,UnityEngine.Resources.Load<UnityEngine.AudioClip>("sfx/"+name));
		UnityEngine.Object.FindObjectOfType<UnityEngine.AudioSource>().PlayOneShot(dictionary[name],volume);
	}
}
