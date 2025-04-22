using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        Image[] card_Image = new Image[42];
        Image[] Player1_Image = new Image[17];
        Image[] Player2_Image = new Image[16];
        Image[] Player3_Image = new Image[16];
        Image[] Player4_Image = new Image[16];

        string[] list = new string[42];
        string[] AllCard = new string[144];

        string[] Player1 = new string[17];
        string[] Player2 = new string[16];
        string[] Player3 = new string[16];
        string[] Player4 = new string[16];

        int StartGetCard = 0, flower = 0;

        public Form1()
        {
            InitializeComponent();            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            card_Image[0] = Image.FromFile("image/Character/1wan.png");
            card_Image[1] = Image.FromFile("image/Character/2wan.png");
            card_Image[2] = Image.FromFile("image/Character/3wan.png");
            card_Image[3] = Image.FromFile("image/Character/4wan.png");
            card_Image[4] = Image.FromFile("image/Character/5wan.png");
            card_Image[5] = Image.FromFile("image/Character/6wan.png");
            card_Image[6] = Image.FromFile("image/Character/7wan.png");
            card_Image[7] = Image.FromFile("image/Character/8wan.png");
            card_Image[8] = Image.FromFile("image/Character/9wan.png");
            card_Image[9] = Image.FromFile("image/Dot/Dots1.png");
            card_Image[10] = Image.FromFile("image/Dot/Dots2.png");            
            card_Image[11] = Image.FromFile("image/Dot/Dots3.png");
            card_Image[12] = Image.FromFile("image/Dot/Dots4.png");
            card_Image[13] = Image.FromFile("image/Dot/Dots5.png");
            card_Image[14] = Image.FromFile("image/Dot/Dots6.png");
            card_Image[15] = Image.FromFile("image/Dot/Dots7.png");
            card_Image[16] = Image.FromFile("image/Dot/Dots8.png");
            card_Image[17] = Image.FromFile("image/Dot/Dots9.png");
            card_Image[18] = Image.FromFile("image/Stick/Stick1.png");
            card_Image[19] = Image.FromFile("image/Stick/Stick2.png");
            card_Image[20] = Image.FromFile("image/Stick/Stick3.png");
            card_Image[21] = Image.FromFile("image/Stick/Stick4.png");
            card_Image[22] = Image.FromFile("image/Stick/Stick5.png");
            card_Image[23] = Image.FromFile("image/Stick/Stick6.png");
            card_Image[24] = Image.FromFile("image/Stick/Stick7.png");
            card_Image[25] = Image.FromFile("image/Stick/Stick8.png");
            card_Image[26] = Image.FromFile("image/Stick/Stick9.png");
            card_Image[27] = Image.FromFile("image/Honor/East.png");
            card_Image[28] = Image.FromFile("image/Honor/South.png");
            card_Image[29] = Image.FromFile("image/Honor/West.png");
            card_Image[30] = Image.FromFile("image/Honor/North.png");
            card_Image[31] = Image.FromFile("image/Honor/RedDragon.png");
            card_Image[32] = Image.FromFile("image/Honor/GreenDragon.png");
            card_Image[33] = Image.FromFile("image/Honor/WhiteDragon.png");
            card_Image[34] = Image.FromFile("image/Flower/Spring.png");
            card_Image[35] = Image.FromFile("image/Flower/Summer.png");
            card_Image[36] = Image.FromFile("image/Flower/Autumn.png");
            card_Image[37] = Image.FromFile("image/Flower/Winter.png");
            card_Image[38] = Image.FromFile("image/Flower/Plum.png");
            card_Image[39] = Image.FromFile("image/Flower/Orchid.png");
            card_Image[40] = Image.FromFile("image/Flower/Chrysanthemum.png");
            card_Image[41] = Image.FromFile("image/Flower/Bamboo.png");

            list[0] = "一萬"; list[1] = "二萬"; list[2] = "三萬"; list[3] = "四萬"; list[4] = "五萬"; 
            list[5] = "六萬"; list[6] = "七萬"; list[7] = "八萬"; list[8] = "九萬";

            list[9] = "一餅"; list[10] = "二餅"; list[11] = "三餅"; list[12] = "四餅"; list[13] = "五餅";
            list[14] = "六餅"; list[15] = "七餅"; list[16] = "八餅"; list[17] = "九餅";

            list[18] = "一條"; list[19] = "二條"; list[20] = "三條"; list[21] = "四條"; list[22] = "五條";
            list[23] = "六條"; list[24] = "七條"; list[25] = "八條"; list[26] = "九條";

            list[27] = "東"; list[28] = "南"; list[29] = "西"; list[30] = "北";
            list[31] = "中"; list[32] = "發"; list[33] = "白皮";

            list[34] = "春"; list[35] = "夏"; list[36] = "秋"; list[37] = "冬";
            list[38] = "梅"; list[39] = "蘭"; list[40] = "菊"; list[41] = "竹";

            int i, j = 0;
            for (i = 0; i < 34; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    AllCard[j] = list[i];
                    j++;
                }
            }
            j = 136;
            for (i = 34; i < 42; i++)
            {
                AllCard[j] = list[i];
                j++;
            }

            //洗牌
            Shuffle(AllCard);

            //擲骰
            Random dice_rn = new Random();
            int dice1 = dice_rn.Next(1, 7);
            int dice2 = dice_rn.Next(1, 7);
            int dice3 = dice_rn.Next(1, 7);

            int dice_n = dice1 + dice2 + dice3;
           
            int Banker = dice_n % 4;
            if (Banker == 0)
                Banker = 4;

            int startGetCard = Banker * 36 - 36 + (36 - dice_n * 2);
            StartGetCard = startGetCard;

            //抓牌
            for (int a = 0; a < 16; a+=4)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player1[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player1[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player2[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player2[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player3[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player3[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player4[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player4[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;
            }

            Console.WriteLine(StartGetCard);
            //開門
            if (StartGetCard - 64 < 0)                 
                Player1[16] = AllCard[144 + StartGetCard - 64];
            else
                Player1[16] = AllCard[StartGetCard - 64];

            
            //補花

            /*bool haveAfterFlower = true;
            flower = 0;

            while (haveAfterFlower)
            {
                haveAfterFlower = false;

                for (int a = 0; a < 17; a++)           //莊家開門後有17張
                {
                    for (int b = 34; b < 42; b++)
                    {
                        if (Player1[a] == list[b])
                        {
                            Player1[a] = AllCard[StartGetCard + flower];
                            flower++;
                        }
                    }
                }
                for (int a = 0; a < 16; a++)
                {
                    for (int b = 34; b < 42; b++)
                    {
                        if (Player2[a] == list[b])
                        {
                            Player2[a] = AllCard[StartGetCard + flower];
                            flower++;
                        }
                    }
                }
                for (int a = 0; a < 16; a++)
                {
                    for (int b = 34; b < 42; b++)
                    {
                        if (Player3[a] == list[b])
                        {
                            Player3[a] = AllCard[StartGetCard + flower];
                            flower++;
                        }
                    }
                }
                for (int a = 0; a < 16; a++)
                {
                    for (int b = 34; b < 42; b++)
                    {
                        if (Player4[a] == list[b])
                        {
                            Player4[a] = AllCard[StartGetCard + flower];
                            flower++;
                        }
                    }
                }


                for (int a = 0; a < 16; a++)  //檢查補完之後還有沒有花
                {
                    for (int b = 34; b < 42; b++)
                    {
                        if (Player1[a] == list[b])
                        {
                            haveAfterFlower = true;
                        }
                        if (Player2[a] == list[b])
                        {
                            haveAfterFlower = true;
                        }
                        if (Player3[a] == list[b])
                        {
                            haveAfterFlower = true;
                        }
                        if (Player4[a] == list[b])
                        {
                            haveAfterFlower = true;
                        }
                    }
                }
            }*/ //自動補花

            showCard();

        }
        void newGame()
        {
            //洗牌
            Shuffle(AllCard);

            //擲骰
            Random dice_rn = new Random();
            int dice1 = dice_rn.Next(1, 7);
            int dice2 = dice_rn.Next(1, 7);
            int dice3 = dice_rn.Next(1, 7);

            int dice_n = dice1 + dice2 + dice3;

            int Banker = dice_n % 4;
            if (Banker == 0)
                Banker = 4;

            int startGetCard = Banker * 36 - 36 + (36 - dice_n * 2);
            StartGetCard = startGetCard;

            //抓牌
            for (int a = 0; a < 16; a += 4)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player1[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player1[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player2[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player2[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player3[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player3[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                for (int b = 0; b < 4; b++)
                {
                    if (startGetCard - b < 0)
                        Player4[a + b] = AllCard[startGetCard - b + 144];
                    else
                        Player4[a + b] = AllCard[startGetCard - b];
                }

                if (startGetCard - 4 < 0)
                    startGetCard += 144;
                startGetCard -= 4;

                showCard();
            }

            Console.WriteLine(StartGetCard);
            //開門
            if (StartGetCard - 64 < 0)
                Player1[16] = AllCard[144 + StartGetCard - 64];
            else
                Player1[16] = AllCard[StartGetCard - 64];


            //補花


        }
        static void Shuffle(string[] array) //洗牌
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                string temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        void showCard() //更新牌桌上的畫面
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();

            for (int a = 0; a < 17; a++)
            {
                richTextBox1.Text += Player1[a];
                richTextBox1.Text += " ";
            }
 
            for (int a = 0; a < 16; a++)
            {
                richTextBox2.Text += Player2[a];
                richTextBox2.Text += " ";
            }

            for (int a = 0; a < 16; a++)
            {
                richTextBox3.Text += Player3[a];
                richTextBox3.Text += " ";
            }
;
            for (int a = 0; a < 16; a++)
            {
                richTextBox4.Text += Player4[a];
                richTextBox4.Text += " ";
            }
            List<PictureBox> player1_picture = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                pictureBox16, pictureBox17
            };
            List<PictureBox> player2_picture = new List<PictureBox>
            {
                pictureBox33, pictureBox32, pictureBox31, pictureBox30, pictureBox29,
                pictureBox28, pictureBox27, pictureBox26, pictureBox25, pictureBox24,
                pictureBox23, pictureBox22, pictureBox21, pictureBox20, pictureBox19,
                pictureBox18
            };
            List<PictureBox> player3_picture = new List<PictureBox>
            {
                pictureBox49, pictureBox48, pictureBox47, pictureBox46, pictureBox45,
                pictureBox44, pictureBox43, pictureBox42, pictureBox41, pictureBox40,
                pictureBox39, pictureBox38, pictureBox37, pictureBox36, pictureBox35,
                pictureBox34
            };
            List<PictureBox> player4_picture = new List<PictureBox>
            {
                pictureBox65, pictureBox64, pictureBox63, pictureBox62, pictureBox61,
                pictureBox60, pictureBox59, pictureBox58, pictureBox57, pictureBox56,
                pictureBox55, pictureBox54, pictureBox53, pictureBox52, pictureBox51,
                pictureBox50
            };
            for (int i = 0; i < player1_picture.Count; i++)
            {
                player1_picture[i].Image = Player1_Image[i];
            }
            for (int i = 0; i < player2_picture.Count; i++)
            {
                player2_picture[i].Image = Player2_Image[i];
                player3_picture[i].Image = Player3_Image[i];
                player4_picture[i].Image = Player4_Image[i];
            }
        }

        string[] tidyCard(string[] target, int n)
        {
            string[] AfterTidy = new string[n];
            int k = 0;

            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (target[j] == list[i])
                    {
                        AfterTidy[k] = target[j];

                        if(target== Player1)
                        {                      
                            Player1_Image[k] = card_Image[i];
                        }
                        else if (target == Player2)
                        {
                            Player2_Image[k] = card_Image[i];
                        }
                        else if (target == Player3)
                        {
                            Player3_Image[k] = card_Image[i];
                        }
                        else if (target == Player4)
                        {
                            Player4_Image[k] = card_Image[i];
                        }
                        k++;
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                target[j] = AfterTidy[j];
            }

            return target;
        }


        private void button2_Click(object sender, EventArgs e) //整牌
        {
            Player1 = tidyCard(Player1, 17);
            Player2 = tidyCard(Player2, 16);
            Player3 = tidyCard(Player3, 16);
            Player4 = tidyCard(Player4, 16);

            showCard();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void button1_Click(object sender, EventArgs e) //補花
        {
            for (int a = 0; a < 17; a++)           //莊家開門後有17張
            {
                for (int b = 34; b < 42; b++)
                {
                    if (Player1[a] == list[b])
                    {
                        Player1[a] = AllCard[StartGetCard + flower];
                        flower++;
                    }
                }
            }
            for (int a = 0; a < 16; a++)
            {
                for (int b = 34; b < 42; b++)
                {
                    if (Player2[a] == list[b])
                    {
                        Player2[a] = AllCard[StartGetCard + flower];
                        flower++;
                    }
                }
            }
            for (int a = 0; a < 16; a++)
            {
                for (int b = 34; b < 42; b++)
                {
                    if (Player3[a] == list[b])
                    {
                        Player3[a] = AllCard[StartGetCard + flower];
                        flower++;
                    }
                }
            }
            for (int a = 0; a < 16; a++)
            {
                for (int b = 34; b < 42; b++)
                {
                    if (Player4[a] == list[b])
                    {
                        Player4[a] = AllCard[StartGetCard + flower];
                        flower++;
                    }
                }
            }

            label1.Text=flower.ToString();
            showCard();
        }
    }
}
