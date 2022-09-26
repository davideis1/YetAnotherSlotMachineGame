using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherSlotMachineGame
{
    internal class SlotSpin
    {
        private readonly FieldOptionsInteger NumberSettings;

        public SlotSpin()
        {
            NumberSettings = new FieldOptionsInteger()
            {
                Max = 225569,
                Min = 100000,
                Seed = DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour
            };
        }

        public int Spin()
        {
            var randomNumber = RandomizerFactory.GetRandomizer(NumberSettings);

            return GetWin(randomNumber.Generate().Value);
        }

        private int GetWin(int number)
        {
            if (100000 <= number && number <= 100010)
            {
                return 800;
            }
            if (100011 <= number && number <= 100100)
            {
                return 320;
            }
            if (100101 <= number && number <= 100589)
            {
                return 160;
            }
            if (100590 <= number && number <= 102089)
            {
                return 100;
            }
            if (102090 <= number && number <= 104089)
            {
                return 80;
            }
            if (104090 <= number && number <= 107589)
            {
                return 50;
            }
            if (107590 <= number && number <= 111339)
            {
                return 40;
            }
            if (111340 <= number && number <= 115439)
            {
                return 25;
            }
            if (115440 <= number && number <= 119669)
            {
                return 20;
            }
            if (119670 <= number && number <= 124369)
            {
                return 10;
            }
            if (124370 <= number && number <= 129569)
            {
                return 5;
            }
            if (129570 <= number && number <= 135569)
            {
                return 2;
            }
            if (135570 <= number && number <= 225569)
            {
                
                return 0;
            }

            return -1;

        }
    }
}
