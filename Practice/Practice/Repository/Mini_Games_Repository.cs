using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Practice.Repository
{
    public class Mini_Games_Repository : IMini_Games_Repository
    {
        public Mini_Games_Repository()
        {
            
        }

        public int Dice_Roll()
        {
            Random random = new Random();
            var result = random.Next(1,7);
            return result;
        }

        public string Toss()
        {
            string[] coin = {  "heads", "tails" };
            Random rnd = new Random();
            int index = rnd.Next(coin.Length);
            return coin[index];
        }
    }
}