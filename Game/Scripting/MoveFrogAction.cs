using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveFrogAction : Action
    {
        public MoveFrogAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            Body body = frog.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();
            int y = position.GetY();

            position = position.Add(velocity);
            // velocity = velocity.Accelerate(Constants.FROG_JUMP_ACCELERATION);

            // body.SetVelocity(velocity);
            body.SetPosition(position);       
        }
    }
}