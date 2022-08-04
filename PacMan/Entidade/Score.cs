using PacMan.Base;

namespace PacMan.Entidade
{
    public class Score : EntityBase
    {
        public override string name { get; set; } = "Score";
        public override char character { get; set; } = Constant.ScoreChar;

        public override void Update()
        {

        }
    }
}
