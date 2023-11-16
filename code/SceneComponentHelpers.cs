namespace Sandbox;

public static class SceneComponentHelpers
{
    public static bool TryGetSandwindComponentParent<TComponent>(out GameObject gameObject) where TComponent : BaseComponent
    {
        var children = global::GameManager.ActiveScene.Scene.Children;
        var gameObjects = children.Where(x => x.GetComponent<TComponent>(deep: true) is not null).ToList();

        if (gameObjects.Count > 1)
        {
            Log.Error($"Only one {nameof(TComponent).ToTitleCase()} is allowed per scene.");

            gameObject = default;
            return false;
        }

        var comp = gameObjects.Select(x => x.GetComponent<TComponent>(deep: true)).FirstOrDefault();
        gameObject = comp?.GameObject;

        return gameObject is not null;
    }

    public static bool TryGetSandwindComponent<TComponent>(out TComponent component) where TComponent : BaseComponent
    {
        var go = TryGetSandwindComponentParent<TComponent>(out var gameObject);

        if (!go)
        {
            component = default;
            return false;
        }

        component = gameObject.GetComponent<TComponent>();
        return component is not null;
    }
}