﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    [Range(0, 1)][SerializeField] float scrollingSpeed = 0.03f;
    [SerializeField] List<Texture> textures;

    Game game;
    Material material;
    Vector2 offset;

    // Start is called before the first frame update
    void Start() {
        material = gameObject.GetComponent<Renderer>().material;
        game = FindObjectOfType<Game>();
        offset = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update() {
        if (game.GetGameState() == Game.GameState.Playing || game.GetGameState() == Game.GameState.Menu) {
            offset = new Vector2(0, offset.y + scrollingSpeed * Time.deltaTime);
            material.mainTextureOffset = offset;
        }
    }

    //changes the texture on the background will use this later to transition in levels
    //private IEnumerator Test() {
    //    yield return new WaitForSeconds(3);
    //    material.mainTexture = textures[1];
    //}
}
