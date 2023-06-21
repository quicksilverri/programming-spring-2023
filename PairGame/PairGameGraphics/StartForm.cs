using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PairGameLibraryNET;
using System.Threading;

namespace PairGameGraphics
{
    public partial class StartForm : Form
    {
        string firstChoice;
        string secondChoice;

        PictureBox picA;
        PictureBox picB;
        
        bool gameOver;

        readonly Board board = new Board();

        private int ticks;
        private int totalSeconds; 

        public StartForm()
        {
            InitializeComponent();
            LoadPictures();
        }

        private void LoadPictures()
        {
            var boxes = board.LoadPictures();

            foreach (var box in boxes)
            {
                // set action
                box.Click += NewPic_Click;
                // add boxes to the board
                Controls.Add(box);
            }

            RestartGame();
        }

        // initially shows pictures for board.tickBegin seconds
        private void ShowPictures()
        {
            board.action = ActionType.ShowPictures;
            timer.Start();
            
            foreach (var pic in board.pictures)
            {
                pic.Image = Image.FromFile(Application.StartupPath + @"\pics\" + (string)pic.Tag + ".jpg");
            }

        }

        // action method for clicks on pictures
        private void NewPic_Click(object sender, EventArgs e)
        {
            // if game ended, don't care about clicks
            if (gameOver || board.action != ActionType.Choice)
            { return; }

            // if no pics are chosen
            if (firstChoice == null)
            {
                picA = sender as PictureBox;

                if (picA.Tag != null && picA.Image == board.back)
                {
                    picA.Image = Image.FromFile(Application.StartupPath + @"\pics\" + (string)picA.Tag + ".jpg");
                    firstChoice = (string)picA.Tag;
                }
            }
            // if the first pic is chosen but the second is not 
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;

                if (picB.Tag != null && picB.Image == board.back)
                {
                    picB.Image = Image.FromFile(Application.StartupPath + @"\pics\" + (string)picB.Tag + ".jpg");
                    secondChoice = (string)picB.Tag;

                    if (CheckPictures(picA, picB))
                    {
                        board.action = ActionType.Delete;
                        timer.Start(); 
                    }
                    else
                    {
                        board.action = ActionType.Close;
                        timer.Start(); 
                    }
                }
            }
        }

        // reloads the main screen
        private void RestartGame()
        {
            totalTime.Start();

            var randomList = board.cardTypes.OrderBy(x => Guid.NewGuid()).ToList();
            var cardTypes = randomList;

            for (int i = 0; i < cardTypes.Count; i++)
            {
                board.pictures[i].Image = board.back;
                board.pictures[i].Tag = cardTypes[i].ToString();
            }

            gameOver = false;
            ShowPictures(); 
        }

        // checks if match was made
        private bool CheckPictures(PictureBox A, PictureBox B)
        {
            bool ifSame = firstChoice == secondChoice;
            if (ifSame)
            {
                A.Tag = null;
                B.Tag = null;
            }

            firstChoice = null;
            secondChoice = null;

            return ifSame; 
        }

        // self-explenatory ig??
        private void CheckGameOver()
        { 
            if (board.pictures.All(x => x.Tag == null))
            {
                GameOver();
            }
        }

        // puts the remaining cards on the form
        private void PutCards()
        {
            foreach (var pics in board.pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = board.back;
                }
                else
                {
                    pics.Image = null; 
                }
            }
        }

        // end game statement
        private void GameOver()
        {
            gameOver = true;
            MessageBox.Show("ВЫ ПОБЕДИЛИ!! \nВаше время игры: " + totalSeconds.ToString() + " секунд.");
            timer.Stop();
            totalSeconds = 0; 
        }

        // exit 
        private void ExitGame(object sender, EventArgs e)
        {
            Close(); 
        }

        // creates new game 
        private void CreateNewGame(object sender, EventArgs e)
        {
            RestartGame();
            ShowPictures();
        }

        // extra timer 
        private void TimerTick(object sender, EventArgs e)
        {
            
            ticks++;

            if (ticks == board.tickBegin && board.action == ActionType.ShowPictures)
            {
                timer.Stop();
                
                foreach (var pic in board.pictures)
                {
                    pic.Image = board.back;
                }

                ticks = 0;
                board.action = ActionType.Choice;   
            }
            if (board.action == ActionType.Delete && ticks == board.tickDelete) 
            {
                timer.Stop();
                CheckGameOver();
                PutCards();
                ticks = 0;
                board.action = ActionType.Choice;
            }
            if (board.action == ActionType.Close && ticks == board.tickClose)
            {
                timer.Stop();
                PutCards();
                ticks = 0;
                board.action = ActionType.Choice;
            }
        }

        // main timer
        private void GetTotalTime(object sender, EventArgs e)
        {
            totalSeconds++; 
        }
    }
}
