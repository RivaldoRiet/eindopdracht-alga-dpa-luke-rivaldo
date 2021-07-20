using DPA.Components;
using DPA.Enum;
using DPA.Repository;
using System;

namespace DPA.Command
{
    public class RemoveAsteroidCommand : ICommand
    {
        public void Execute()
        {
            int asteroidCount = CelestialObjectRepository.Instance.GetAsteroidCount();
            if (asteroidCount > 0)
            {
                Random rand = new Random();
                int loops = rand.Next(asteroidCount);

                foreach (CelestialObject co in CelestialObjectRepository.Instance.GetCelestialObjectList())
                {
                    if (co.Type == CelestialObjectType.ASTEROID)
                    {
                        if (loops == 0)
                        {
                            CelestialObjectRepository.Instance.RemoveFromCelestialObjectList(co);
                            break;
                        }
                        else
                        {
                            loops--;
                        }
                    }
                }
            }
        }
    }
}
