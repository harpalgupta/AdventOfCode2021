namespace AdventOfCode2021.Models
{
    public class LanternFish
    {
        public int DaysUntilSpawn;

        public LanternFish(int daysUntilNextSpawn = 6)
        {
            DaysUntilSpawn = daysUntilNextSpawn;
        }

        public void DayIncrement()
        {
            if (DaysUntilSpawn == 0)
            {
                DaysUntilSpawn = 6;
            }
            else
            {
                DaysUntilSpawn--;
            }
            
        }
    }
}