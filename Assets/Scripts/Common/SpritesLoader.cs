using System.Collections.Generic;
using UnityEngine;

public class SpritesLoader: MonoBehaviour
{
    public string route;

    public Dictionary<string, Sprite> Sprites
    {
        get {
            if (this._sprites.Count == 0)
            {
                LoadSprites();
            }
            return this._sprites;
        }
    }

    private readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

    private void LoadSprites()
    {
        var sprites = Resources.LoadAll<Sprite>(route);
        foreach (var sprite in sprites)
        {
            _sprites.Add(sprite.name, sprite);
        }
    }
}
