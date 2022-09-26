using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetAnotherSlotMachineGame
{
    public partial class Form1 : Form
    {
        public double PlayerMoney;
        public double PlayerBet;

        public Form1()
        {
            InitializeComponent();
            PlayerMoney = 100.00;
            PlayerBet = .50;
            RefreshScreen();
        }

        public void RefreshScreen()
        {
            Lbl_PlayerMoney.Text = PlayerMoney.ToString("0.00");
        }

        private void Btn_Spin_Click(object sender, EventArgs e)
        {
            if((PlayerMoney - (3 * PlayerBet)) >= 0)
            {
                var slotSpin = new SlotSpin();

                var spinWin = slotSpin.Spin();

                PlayerMoney = (PlayerMoney - (3 * PlayerBet)) + (spinWin * (PlayerBet / 2));

                Lbl_SpinResult.Text = (spinWin * (PlayerBet / 2)).ToString("0.00");

                
                UpdateReels(spinWin);
                RefreshScreen();
            }
            else
            {
                MessageBox.Show("Out of Money");
            }
            
        }

        private void UpdateReels(int spinWin)
        {
            switch(spinWin)
            {
                case 0:
                    {
                        RandomLossWheels();
                        break;
                    }
                case 2:
                    {
                        ReelA.Image = Properties.Resources.one_bar;
                        ReelB.Image = Properties.Resources.cherry;
                        ReelC.Image = null;
                        break;
                    }
                case 5:
                    {
                        ReelA.Image = Properties.Resources.one_bar;
                        ReelB.Image = Properties.Resources.cherry;
                        ReelC.Image = Properties.Resources.cherry;
                        break;
                    }
                case 10:
                    {
                        ReelA.Image = Properties.Resources.one_bar;
                        ReelB.Image = Properties.Resources.one_bar;
                        ReelC.Image = Properties.Resources.one_bar;
                        break;
                    }
                case 20:
                    {
                        ReelA.Image = Properties.Resources.cherry;
                        ReelB.Image = Properties.Resources.cherry;
                        ReelC.Image = Properties.Resources.cherry;
                        break;
                    }
                case 25:
                    {
                        ReelA.Image = Properties.Resources.one_bar;
                        ReelB.Image = Properties.Resources.one_bar;
                        ReelC.Image = Properties.Resources.two_diamond;
                        break;
                    }
                case 40:
                    {
                        ReelA.Image = Properties.Resources.two_bar;
                        ReelB.Image = Properties.Resources.two_bar;
                        ReelC.Image = Properties.Resources.two_bar;
                        break;
                    }
                case 50:
                    {
                        ReelA.Image = Properties.Resources.two_bar;
                        ReelB.Image = Properties.Resources.two_bar;
                        ReelC.Image = Properties.Resources.two_diamond;
                        break;
                    }
                case 80:
                    {
                        ReelA.Image = Properties.Resources.three_bar;
                        ReelB.Image = Properties.Resources.three_bar;
                        ReelC.Image = Properties.Resources.three_bar;
                        break;
                    }
                case 100:
                    {
                        ReelA.Image = Properties.Resources.three_bar;
                        ReelB.Image = Properties.Resources.three_bar;
                        ReelC.Image = Properties.Resources.three_diamond;
                        break;
                    }
                case 160:
                    {
                        ReelA.Image = Properties.Resources.seven;
                        ReelB.Image = Properties.Resources.seven;
                        ReelC.Image = Properties.Resources.seven;
                        break;
                    }
                case 320:
                    {
                        ReelA.Image = Properties.Resources.two_diamond;
                        ReelB.Image = Properties.Resources.two_diamond;
                        ReelC.Image = Properties.Resources.two_diamond;
                        break;
                    }
                case 800:
                    {
                        ReelA.Image = Properties.Resources.three_diamond;
                        ReelB.Image = Properties.Resources.three_diamond;
                        ReelC.Image = Properties.Resources.three_diamond;
                        break;
                    }
            }

            RandomReel(TopLeftReel);
            Thread.Sleep(50);
            RandomReel(TopCenterReel);
            Thread.Sleep(150);
            RandomReel(TopRightReel);
            Thread.Sleep(50);
            RandomReel(BottomLeftReel);
            Thread.Sleep(150);
            RandomReel(BottomCenterReel);
            Thread.Sleep(50);
            RandomReel(BottomRightReel);
            Thread.Sleep(150);
        }

        private void RandomReel(PictureBox reel, bool lossMode = false)
        {
            var NumberSettings = new FieldOptionsInteger()
            {
                Max = 7,
                Min = 0,
                Seed = DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour
            };
        

        
            switch(RandomizerFactory.GetRandomizer(NumberSettings).Generate().Value)
            {
                case 0:
                    {
                        reel.Image = null;
                        break;
                    }
                case 1:
                    {
                        reel.Image = Properties.Resources.one_bar;
                        break;
                    }
                case 2:
                    {
                        reel.Image = Properties.Resources.two_bar;
                        break;
                    }
                case 3:
                    {
                        reel.Image = Properties.Resources.three_bar;
                        break;
                    }
                case 4:
                    {
                        if(!lossMode)
                        {
                            reel.Image = Properties.Resources.cherry;
                        }
                        else
                        {
                            reel.Image = null;
                        }
                        break;
                    }
                case 5:
                    {
                        reel.Image = Properties.Resources.seven;
                        break;
                    }
                case 6:
                    {
                        if (!lossMode)
                        {
                            reel.Image = Properties.Resources.two_diamond;
                        }
                        else
                        {
                            reel.Image = null;
                        }
                        break;
                    }
                case 7:
                    {
                        if (!lossMode)
                        {
                            reel.Image = Properties.Resources.three_diamond;
                        }
                        else
                        {
                            reel.Image = null;
                        }
                        break;
                    }
            }

            
        }

        private void RandomLossWheels()
        {
            var NumberSettings = new FieldOptionsInteger()
            {
                Max = 6,
                Min = 0,
                Seed = DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour
            };



            switch (RandomizerFactory.GetRandomizer(NumberSettings).Generate().Value)
            {
                case 0:
                    {
                        ReelA.Image = null;
                        ReelB.Image = null;
                        ReelC.Image = null;
                        break;
                    }
                case 1:
                    {
                        ReelA.Image = null;
                        RandomReel(ReelB, true);
                        ReelC.Image = null;
                        break;
                    }
                case 2:
                    {
                        ReelA.Image = null;
                        RandomReel(ReelB, true);
                        RandomReel(ReelC, true);
                        break;
                    }
                case 3:
                    {
                        ReelC.Image = null;
                        RandomReel(ReelB, true);
                        RandomReel(ReelA, true);
                        break;
                    }
                case 4:
                    {
                        ReelB.Image = null;
                        RandomReel(ReelA, true);
                        RandomReel(ReelC, true);
                        break;
                    }
                case 5:
                    {
                        ReelB.Image = null;
                        RandomReel(ReelA, true);
                        ReelC.Image = null;
                        break;
                    }
                case 6:
                    {
                        ReelA.Image = null;
                        RandomReel(ReelC, true);
                        ReelB.Image = null;
                        break;
                    }                
            }


        }

    }
}
