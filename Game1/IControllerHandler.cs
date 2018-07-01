namespace Game1
{
    public interface IControllerHandler
    {
        bool MovingDown { get; set; }
        bool MovingUp { get; set; }
        bool MovingRight { get; set; }
        bool MovingLeft { get; set; }
    }
}