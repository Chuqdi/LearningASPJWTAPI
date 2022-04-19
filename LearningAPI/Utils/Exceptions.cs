namespace LearningAPI.Utils
{
    public class Exceptions
    {
        public class SuperHeroNoFound: Exception
        {
            public SuperHeroNoFound(string message): base(message)
            {

            }
        }
    }
}
