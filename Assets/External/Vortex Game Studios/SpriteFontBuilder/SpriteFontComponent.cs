using UnityEngine;
using System.Collections;

public class SpriteFontVector {
	public int x = 0;
	public int y = 0;
	public int width = 0;
	public int height = 0;
	public int xOffset = 0;
	public int yOffset = 0;
	public int xAdvance = 0;
}

public class SpriteFontComponent : MonoBehaviour {
	new public string name = "";
	public Texture2D sprite = null;

	public int fontBase = 0;
	public Font font = null;
	
	public string characters = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRTSUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

	public SpriteFontVector[] vector;
}
