using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

[System.Serializable]
public class SpriteFontBuilderWindow : EditorWindow {
	private GUIContent _iconMinus;

	private TextureImporter _spriteFonteImporter;
	private Vector2 _scrollView = Vector2.zero;

	private SpriteFontComponent _toBeRemovedEntry = null;
	private string _path = "Assets/External/Vortex Game Studios/SpriteFontBuilder/";

	// Space Lander ==> !"#%'()*+,-./0123456789:;<=>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~
	// NEHE ==>         !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRTSUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~
	// private string _fontOrder = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRTSUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

	private GameObject _setup;

	[MenuItem( "Window/Vortex Game Studios/Sprite Font Builder", false, 0 )]
	public static void ShowWindow() {
		EditorWindow spriteFontEditorWindow = EditorWindow.GetWindow( typeof( SpriteFontBuilderWindow ) );

		spriteFontEditorWindow.titleContent.text = "Sprite Font";
		spriteFontEditorWindow.titleContent.image = AssetDatabase.LoadAssetAtPath<Texture>( "Assets/External/Vortex Game Studios/SpriteFontBuilder/icon.png" );

		/*
		EditorWindow spriteFontEditorWindow = EditorWindow.GetWindow( typeof( SpriteFontBuilderWindow ) );
		PropertyInfo p = typeof( EditorWindow ).GetProperty( "cachedTitleContent", BindingFlags.Instance | BindingFlags.NonPublic );
		GUIContent spriteFontEditorContent = p.GetValue( spriteFontEditorWindow, null ) as GUIContent;

		spriteFontEditorContent.text = "Sprite Font";
		spriteFontEditorContent.image = AssetDatabase.LoadAssetAtPath<Texture>( "Assets/External/Vortex Game Studios/SpriteFontBuilder/icon.png" );
		spriteFontEditorContent.tooltip = "Sprite Font Builder";
		*/
	}

	// Use this for initialization
	void OnGUI() {
		GetPrefab();

		// Draw the scroll bar
		_scrollView = GUILayout.BeginScrollView( _scrollView, false, false );

		this.BeginWindows();

		this.EndWindows();

		// Get the minus button size
		foreach ( SpriteFontComponent font in _setup.GetComponents<SpriteFontComponent>() ) {
			// Draw the font component header
			//GUILayout.BeginVertical( "AS TextArea", GUILayout.Height( 5 ) );
			
			GUILayout.BeginVertical( EditorStyles.helpBox, GUILayout.Height( 5 ) );
			

			GUILayout.Space( 2 );
			GUILayout.BeginHorizontal();

			// Draw the foldout button with the font name
			font.enabled = EditorGUILayout.Foldout( font.enabled, font.name );

			// Draw the minus button
			if ( GUILayout.Button( _iconMinus, GUIStyle.none, GUILayout.Width( 20 ) ) ) {
				//Debug.Log( "destroy" );
				_toBeRemovedEntry = font;
			}
			GUILayout.EndHorizontal();

			// Draw the font component properties
			if ( font.enabled ) {
				// Font name
				font.name = EditorGUILayout.TextField( "Font Name", font.name );

				// Load the new Custom Font asset
				//font.font = EditorGUILayout.ObjectField( "Custom Font", font.font, typeof( Font ), false ) as Font;

				// Load the Sprite asset
				font.sprite = EditorGUILayout.ObjectField( "Sprite Font", font.sprite, typeof( Texture2D ), false ) as Texture2D;

				// Set the character order inside spritesheet
				EditorStyles.textField.wordWrap = true;
				GUILayout.Label( "Character Font Order" );
				font.characters = EditorGUILayout.TextArea( font.characters, GUILayout.Height( 60.0f ) );

				// Just show this button when the CSV file exist in the same sprite path
				if ( font.sprite != null ) {
					string path = GetPath( font.sprite, '.' );
					//Debug.Log( path );
					if ( AssetDatabase.LoadAssetAtPath<TextAsset>( path + "txt" ) ||
						 AssetDatabase.LoadAssetAtPath<TextAsset>( path + "fnt" ) ) {
						EditorGUILayout.HelpBox( "ShoeBox Created Sprite Sheet Found.", MessageType.Info );
					} else {
						EditorGUILayout.HelpBox( "Using User Created Sprite Sheet.", MessageType.Warning );
					}
				} else {
					EditorGUILayout.HelpBox( "No Sprite Selected.", MessageType.Error );
				}
			}

			// Draw the font component footer
			GUILayout.Space( 2 );
			GUILayout.EndVertical();
			GUILayout.Space( 2 );
		}
		
		// Add new font
		if ( GUILayout.Button( "Add New Sprite Font" ) ) {
			AddEntry();
		}

		// Build the font button
		GUI.backgroundColor = Color.green;
		if ( GUILayout.Button( "Build the Sprite Font...", GUILayout.Height( 50 ) ) ) {
			BuildFont();
		}

		GUI.backgroundColor = Color.white;

		GUILayout.Label( "Sprite Font Builder v.1.1.1", EditorStyles.miniBoldLabel );

		GUILayout.EndScrollView();

		if ( _toBeRemovedEntry != null ) {
			RemoveEntry();
		}
	}

	private void AddEntry() {
		SpriteFontComponent newFont = _setup.AddComponent<SpriteFontComponent>();
		newFont.name = "New Sprite Font";
	}

	private void RemoveEntry() {
		//MessageBox.show();

		GameObject.DestroyImmediate( _toBeRemovedEntry, true );
		_toBeRemovedEntry = null;
		this.Repaint();
	}

	private void SetPrefab() {
		
	}

	private void GetPrefab() {
		if ( _setup == null ) {
			_setup = AssetDatabase.LoadAssetAtPath<GameObject>( _path + "SpriteFontSetup.prefab" );

			if ( _setup == null ) {
				_setup = new GameObject( "SpriteFontSetup" );
				PrefabUtility.CreatePrefab( _path + "SpriteFontSetup.prefab", _setup );
				GameObject.DestroyImmediate( _setup );
				GetPrefab();
			}

			_iconMinus = new GUIContent( EditorGUIUtility.IconContent( "Toolbar Minus" ) );
		}
	}

	private string GetPath( Texture2D sprite, char separator = '/' ) {
		string path = "";
		string[] pathSplit = AssetDatabase.GetAssetPath( sprite ).Split( separator );
		for ( int x = 0; x < pathSplit.Length - 1; x++ ) {
			path += pathSplit[x] + separator.ToString();
		}

		return path;
	}

	private void BuildSprite( SpriteFontComponent font ) {
		string path = GetPath( font.sprite, '.' );
		string fnt;
		TextAsset fntIn = null;

		if ( AssetDatabase.LoadAssetAtPath<TextAsset>( path + "txt" ) ) {
			fntIn = AssetDatabase.LoadAssetAtPath<TextAsset>( path + "txt" );
		} else if ( AssetDatabase.LoadAssetAtPath<TextAsset>( path + "fnt" ) ) {
			fntIn = AssetDatabase.LoadAssetAtPath<TextAsset>( path + "fnt" );
		}

		if ( !fntIn ) {
			Debug.LogWarning( "Sprite Font Builder: " + font.name + " built using user created sprite sheet." );
			return;
		}

		fnt = fntIn.text;

		// Get the total of characters
		int totalChars = int.Parse( new Regex( "((chars count=)([0-9]*))" ).Match( fnt ).Value.Replace( "chars count=", "" ) );
		font.fontBase = int.Parse( new Regex( "((base=)([0-9]*))" ).Match( fnt ).Value.Replace( "base=", "" ) );
		_spriteFonteImporter = TextureImporter.GetAtPath( AssetDatabase.GetAssetPath( font.sprite ) ) as TextureImporter;

		// Reset the current sprite suff
		_spriteFonteImporter.spriteImportMode = SpriteImportMode.Single;
		_spriteFonteImporter.spritesheet = null;
		_spriteFonteImporter.SaveAndReimport();

		// And create a new one!
		_spriteFonteImporter.spriteImportMode = SpriteImportMode.Multiple;
		SpriteMetaData[] tSheet = new SpriteMetaData[totalChars];
		font.vector = new SpriteFontVector[totalChars];
		Match chars = new Regex( "((char )(.*))" ).Match( fnt );

		font.characters = "";

		int x = 0;
		while ( chars.Success ) {
			string l = new Regex( "((letter=\")(.*)(\"))" ).Match( chars.Value ).Value.Replace( "letter=\"", "" );
			l = l.Substring( 0, l.Length - 1 );
			font.characters += l;

			font.vector[x] = new SpriteFontVector();
			Rect rect = new Rect();

			rect.x = float.Parse( new Regex( "((x=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "x=", "" ) );
			rect.y = float.Parse( new Regex( "((y=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "y=", "" ) );
			rect.width = float.Parse( new Regex( "((width=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "width=", "" ) );
			rect.height = float.Parse( new Regex( "((height=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "height=", "" ) );

			rect.y = font.sprite.height - rect.y - rect.height;

			font.vector[x].x = (int)(rect.x);
			font.vector[x].y = (int)(rect.y);
			font.vector[x].width = (int)(rect.width);
			font.vector[x].height = (int)(rect.height);
			font.vector[x].xOffset = int.Parse( new Regex( "((xoffset=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "xoffset=", "" ) );
			font.vector[x].yOffset = int.Parse( new Regex( "((yoffset=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "yoffset=", "" ) );
			font.vector[x].xAdvance = int.Parse( new Regex( "((xadvance=)([0-9]*))" ).Match( chars.Value ).Value.Replace( "xadvance=", "" ) );

			SpriteMetaData tSpriteData = new SpriteMetaData();
			tSpriteData.name = font.name + "_" + x;
			tSpriteData.pivot = Vector2.zero;

			tSpriteData.rect = rect;
			
			tSheet[x] = tSpriteData;

			chars = chars.NextMatch();
			x++;
		}

		// Update and save the new sprite stuff
		_spriteFonteImporter.spritesheet = tSheet;
		_spriteFonteImporter.SaveAndReimport();
	}

	private void BuildFont() {
		foreach ( SpriteFontComponent font in _setup.GetComponents<SpriteFontComponent>() ) {
			// Check if we have a sprite
			if ( font.sprite == null ) {
				Debug.LogError( "Sprite Font Builder: " + font.name + " didn't have a sprite set." );
				continue;
			}

			// Get the the spritesheet path
			string path = GetPath( font.sprite );

			// Create the new font when need
			if ( font.font == null ) {							
				// Create the font
				font.font = new Font();
				AssetDatabase.CreateAsset( font.font, path + font.name + ".fontsettings" );
			}

			// Create the font material
			if ( font.font.material == null ) {
				font.font.material = new Material( Shader.Find( "UI/Default" ) );
				font.font.material.SetTexture( "_MainTex", font.sprite );
				AssetDatabase.CreateAsset( font.font.material, path + font.name + ".mat" );
			}

			// Try to build the spritesheet using a external file from the ShoeBox
			BuildSprite( font );

			// Get every sprite frames
			_spriteFonteImporter = TextureImporter.GetAtPath( AssetDatabase.GetAssetPath( font.sprite ) ) as TextureImporter;
			CharacterInfo[] tFonts = new CharacterInfo[font.characters.Length];

			// Build ou update the font
			for ( int x = 0; x < font.characters.Length; x++ ) {
				SpriteMetaData fontSprite = _spriteFonteImporter.spritesheet[x];
				CharacterInfo tFont = new CharacterInfo();
				tFont.index = ( int )( font.characters[x] );

				tFont.style = FontStyle.Normal;
				tFont.advance = Mathf.RoundToInt( fontSprite.rect.width );
				tFont.bearing = Mathf.RoundToInt( fontSprite.rect.height );
				tFont.glyphWidth = Mathf.RoundToInt( fontSprite.rect.width );
				tFont.glyphHeight = Mathf.RoundToInt( fontSprite.rect.height );
				tFont.size = 0;

				//tFont.vert = new Rect( -fontSprite.rect.width / 2, fontSprite.rect.height / 2,
				//					   fontSprite.rect.width / 2, -fontSprite.rect.height / 2 );
				if ( font.vector == null || font.vector.Length == 0 || font.vector[x] == null ) {
					tFont.minX = 0;
					tFont.maxX = Mathf.RoundToInt( fontSprite.rect.width );
					tFont.minY = Mathf.RoundToInt( -fontSprite.rect.height / 2.0f );
					tFont.maxY = Mathf.RoundToInt( fontSprite.rect.height / 2.0f );

					/*
					OBSOLETO
					tFont.vert = new Rect( 0, fontSprite.rect.height/2.0f,
											fontSprite.rect.width, -fontSprite.rect.height );
					*/
				} else {
					tFont.advance = font.vector[x].xAdvance;
					tFont.bearing = font.vector[ x ].yOffset;
					//tFont.glyphHeight = 64;


					tFont.minX = 0;
					tFont.maxX = Mathf.RoundToInt( font.vector[ x ].width );
					tFont.maxY = Mathf.RoundToInt( font.fontBase * 2.0f - font.vector[ x ].yOffset );
					tFont.minY = Mathf.RoundToInt( -font.vector[ x ].height + tFont.maxY );// -font.vector[ x ].height );

					/*
					OBSOLETO
					tFont.vert = new Rect( 0.0f, font.fontBase * 2 - font.vector[x].yOffset,
											font.vector[x].width, -font.vector[x].height );
					*/
				}

				tFont.uvTopLeft = new Vector2( ( fontSprite.rect.xMin / font.sprite.width ), ( fontSprite.rect.yMax / font.sprite.height ) );
				tFont.uvTopRight = new Vector2( ( fontSprite.rect.xMax / font.sprite.width ), ( fontSprite.rect.yMax / font.sprite.height ) );
				tFont.uvBottomLeft = new Vector2( ( fontSprite.rect.xMin / font.sprite.width ), ( fontSprite.rect.yMin/ font.sprite.height ) );
				tFont.uvBottomRight = new Vector2( ( fontSprite.rect.xMax / font.sprite.width ), ( fontSprite.rect.yMin / font.sprite.height ) );

				/*
				OBSOLETO
				tFont.uv = new Rect( fontSprite.rect.x / font.sprite.width,
									 fontSprite.rect.y / font.sprite.height,
									 fontSprite.rect.width / font.sprite.width,
									 fontSprite.rect.height / font.sprite.height );
				*/

					tFonts[ x] = tFont;
			}
			
			// Save the final font
			font.font.characterInfo = tFonts;

			EditorUtility.SetDirty( font );
			EditorUtility.SetDirty( font.sprite );
			EditorUtility.SetDirty( font.font );
			EditorUtility.SetDirty( font.font.material );

			AssetDatabase.SaveAssets();
			//AssetDatabase.
			//AssetDatabase.CreateAsset( font.font, path + font.name + ".fontsettings" );
		}
	}
}