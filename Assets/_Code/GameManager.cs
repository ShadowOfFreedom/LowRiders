public class GameManager {
    public readonly PlayerInput input = new();

    static GameManager instance;

    public static GameManager Instance => instance ??= new GameManager();

    GameManager() => Init();

    void Init() => input.Player.Enable();
}
