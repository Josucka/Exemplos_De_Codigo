using PacMan.Base;

namespace PacMan.Entidade
{
    public class Space : EntityBase
    {
        public override string name { get; set; } = "Space";
        public override char character { get; set; } = Constant.SpaceChar;

        public override void Update()
        {

        }
    }
}
