using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace kaifPuzzle
{
    
    public partial class Form1 : Form
    {
        Image LoadImage;


        TableLayoutPanel picturebox; 

        int OldWidth;
        int OldHeight;
        int size;
        int ballCount;
        int wallCount;

        float ratio = 1.0f;
        float pbxWidth = 0.0f;
        float pbxHeight = 0.0f;
        int puzzleSize = 4;

        int reservedArea = 500;

        private PuzzlePictureBox[,] pbxGrid;
        private string TempDirectory = "";
        private string ArchiveLoc;
        private string Bin_transfer;
        private string Entered_name = "";
        private int ttime = 0;
        private int Tmoves = 0;

        int PuzzleTileRow = 0;
        int PuzzleTileCol = 0;
        
        List<PersonItem> highest_score;

        public Form1()
        {
            InitializeComponent();
            highest_score = new List<PersonItem>();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
            OldWidth = Width;
            OldHeight = Height;

            //    LoadImage = Image.FromFile("puzzle.jpg");
            //    //These will be based on the height/width ratio of your input picture
            //    //int pbxWidth = 50;
            //    //int pbxHeight = 50;

            //    string[] lines = System.IO.File.ReadAllLines("puzzle.txt");    
            //    string[] pieces = lines[0].Split(' ');

            //    //float ratio = 1.0f;
            //    //float pbxWidth = 0.0f;
            //    //float pbxHeight = 0.0f;
            //    //int puzzleSize = 4;

            //    //ratio should always be between 0 and 1
            //    if (LoadImage.Width > LoadImage.Height)
            //    {
            //        ratio = LoadImage.Height / LoadImage.Width;
            //        pbxWidth = reservedArea / puzzleSize;
            //        pbxHeight = (int)(ratio * pbxWidth);
            //    }
            //    else
            //    {
            //        ratio = LoadImage.Width / LoadImage.Height;
            //        pbxHeight = reservedArea / puzzleSize;
            //        pbxWidth = (int)(ratio * pbxHeight);
            //    }

            //    size = Convert.ToInt32(pieces[0]);
            //    ballCount = Convert.ToInt32(pieces[1]);
            //    wallCount = Convert.ToInt32(pieces[2]);

            //    pbxGrid = new PuzzlePictureBox[size, size];
            //    for (int r = 0; r < size; r++)
            //    {
            //        for (int c = 0; c < size; c++)
            //        {
            //            pbxGrid[r, c] = new PuzzlePictureBox();
            //            pbxGrid[r, c].Width = (int)pbxWidth;
            //            pbxGrid[r, c].Height = (int)pbxHeight;
            //            pbxGrid[r, c].Location = new System.Drawing.Point((int)(pbxWidth + (c * pbxWidth)), (int)(150 + (r * pbxHeight)));
            //            pbxGrid[r, c].Name = "b" + r.ToString() + " " + c.ToString();
            //            pbxGrid[r, c].Size = new System.Drawing.Size((int)pbxWidth, (int)pbxHeight);
            //            pbxGrid[r, c].Row = r;
            //            pbxGrid[r, c].Column = c;
            //            Controls.Add(pbxGrid[r, c]);
            //        }
            //    }

            //    for (int i = 0; i < ballCount; i++)
            //    {
            //        string[] ballPieces = lines[i + 1].Split(' '); //plus 1 because we read the first line already
            //        int r = Convert.ToInt32(ballPieces[0]);
            //        int c = Convert.ToInt32(ballPieces[1]);
            //        pbxGrid[r, c].BallOrHole = i + 1;
            //    }

            //    for (int i = 0; i < ballCount; i++)
            //    {
            //        string[] holePieces = lines[i + 1 + ballCount].Split(' '); //plus 1 because we read the first line already
            //        int r = Convert.ToInt32(holePieces[0]);
            //        int c = Convert.ToInt32(holePieces[1]);
            //        pbxGrid[r, c].BallOrHole = 0 - (i + 1);
            //    }

            //    for (int i = 0; i < wallCount; i++)
            //    {
            //        string[] wallPieces = lines[i + 1 + (2 * ballCount)].Split(' '); //plus 1 because we read the first line already
            //        int r1 = Convert.ToInt32(wallPieces[0]);
            //        int c1 = Convert.ToInt32(wallPieces[1]);
            //        int r2 = Convert.ToInt32(wallPieces[2]);
            //        int c2 = Convert.ToInt32(wallPieces[3]);

            //        if (r1 == r2)
            //        {
            //            if (c1 > c2)
            //            {
            //                pbxGrid[r1, c1].LeftWall = true;
            //                pbxGrid[r2, c2].RightWall = true;
            //            }
            //            else
            //            {
            //                pbxGrid[r1, c1].RightWall = true;
            //                pbxGrid[r2, c2].LeftWall = true;
            //            }
            //        }
            //        else
            //        {
            //            if (r1 > r2)
            //            {
            //                pbxGrid[r1, c1].TopWall = true;
            //                pbxGrid[r2, c2].BottomWall = true;
            //            }
            //            else
            //            {
            //                pbxGrid[r1, c1].BottomWall = true;
            //                pbxGrid[r2, c2].TopWall = true;
            //            }
            //        }
            //    }


            //    updatepic();

        }


        private void Win()
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (pbxGrid[r, c].BallOrHole != 0)
                    {
                        return ;
                    }

                }

            }
            

            clock1.Start();

            Form3 f3 = new Form3();
            f3.ShowDialog();

            Entered_name = f3.Name_Entered;
            ttime = Convert.ToInt32(clock1.Totaltime.TotalSeconds);
            UP.Enabled = false;
            right.Enabled = false;
            down.Enabled = false;
            Left.Enabled = false;


            PersonItem personItem = new PersonItem();
            personItem.Name = Entered_name;
            personItem.Time = ttime;
            personItem.Moves = Tmoves;

            highest_score.Add(personItem);
            Save_list();
            listView1.Items.Clear();

            List<PersonItem> sortedlist = highest_score.OrderBy(x => x.Moves).ThenBy(x => x.Time).ToList();
            foreach (PersonItem p in highest_score)
            {

                AddPerson(p);    
            }
        }





        private void button1_Click(object sender, EventArgs e) // up
        {

            for (int r = 1; r <= size - 1; r++)
            {
                for (int c = 0; c <= size - 1; c++)
                {
                    if (pbxGrid[r, c].BallOrHole > 0)
                    {
                        int tempR = r;
                        while (tempR > 0)
                        {
                            if (pbxGrid[tempR, c].TopWall == true || pbxGrid[tempR - 1, c].BallOrHole > 0)
                            {
                                break;
                            }
                            if (pbxGrid[tempR - 1, c].BallOrHole < 0)
                            {
                                if (pbxGrid[tempR - 1, c].BallOrHole + pbxGrid[tempR, r].BallOrHole == 0)
                                {
                                    pbxGrid[tempR - 1, c].BallOrHole = 0;
                                    pbxGrid[tempR, c].BallOrHole = 0;
                                    break;
                                }
                                else
                                {

                                    MessageBox.Show("Game Over!");
                                    return;
                                }

                            }
                            else
                            {
                                pbxGrid[tempR - 1, c].BallOrHole = pbxGrid[tempR, c].BallOrHole;
                                pbxGrid[tempR, c].BallOrHole = 0;
                                tempR--;
                                //updatepic();
                            }
                        }

                    }
                }
            }
            updatepic();

            Win();
            // MessageBox.Show("You Win!");
        }

        private void button1_Click_1(object sender, EventArgs e) // left //
        {
            for (int r = 0; r < size; r++) // are the > < signs correct for r?
            {
                for (int c = 1; c < size; c++) // // are the > < signs correct for c?
                {
                    if (pbxGrid[r, c].BallOrHole > 0)
                    {
                        int tempC = c;
                        while (tempC > 0)
                        {
                            if (pbxGrid[r, tempC].LeftWall == true || pbxGrid[r, tempC - 1].BallOrHole > 0) // is this statement correct because i could not understand what was written in the code you gave
                            {
                                break;
                            }
                            if (pbxGrid[r, tempC - 1].BallOrHole < 0)
                            {
                                if (pbxGrid[r, tempC - 1].BallOrHole + pbxGrid[r, tempC].BallOrHole == 0)
                                {
                                    pbxGrid[r, tempC - 1].BallOrHole = 0; // are these 2 statements correct? do they set both of them to zero?
                                    pbxGrid[r, tempC].BallOrHole = 0;
                                    break;
                                }
                                else
                                {

                                    MessageBox.Show("Game Over!");
                                    return;
                                }

                            }
                            else
                            {

                                pbxGrid[r, tempC - 1].BallOrHole = pbxGrid[r, tempC].BallOrHole;
                                pbxGrid[r, tempC].BallOrHole = 0;
                                tempC--;
                                // updatepic();

                                // move current ball to left 
                                // what do ou mean by that? and how do I do it right?

                            }
                        }

                    }
                }
            }
            updatepic();
            Win();
            // MessageBox.Show("You Win!");
            // you win??  how would you know they have won? how do you do it?


        }

        //private bool NoBalls()
        //{
        //    for (int r = 0; r < size; r++)
        //    {
        //        for (int c = 0; c < size; c++)
        //        {
        //            if (pbxGrid[r,c].BallOrHole != 0)
        //            {
        //                return false; 
        //            }

        //        }

        //    }
        //    return true;

        //}

        private void button3_Click(object sender, EventArgs e) // DOWN
        {

            for (int r = size - 2; r >= 0; r--)
            {
                for (int c = 0; c < size; c++)
                {
                    if (pbxGrid[r, c].BallOrHole > 0)
                    {
                        int tempR = r;
                        while (tempR < size - 1)
                        {
                            if (pbxGrid[tempR, c].BottomWall == true || pbxGrid[tempR + 1, c].BallOrHole > 0)
                            {
                                break;
                            }
                            if (pbxGrid[tempR + 1, c].BallOrHole < 0)
                            {
                                if (pbxGrid[tempR + 1, c].BallOrHole + pbxGrid[tempR, c].BallOrHole == 0)
                                {
                                    pbxGrid[tempR + 1, c].BallOrHole = 0;
                                    pbxGrid[tempR, c].BallOrHole = 0;
                                    break;
                                }
                                else
                                {

                                    MessageBox.Show("Game Over!");
                                    return;
                                }

                            }
                            else
                            {
                                pbxGrid[tempR + 1, c].BallOrHole = pbxGrid[tempR, c].BallOrHole;
                                pbxGrid[tempR, c].BallOrHole = 0;
                                tempR++;
                                //updatepic();
                            }
                        }

                    }
                }
            }
            updatepic();
            Win();

        }



        private void right_Click(object sender, EventArgs e) // right
        {

            for (int r = 0; r < size; r++)
            {
                for (int c = size - 1; c >= 0; c--)
                {
                    if (pbxGrid[r, c].BallOrHole > 0)
                    {
                        int tempC = c;
                        while (tempC < size - 1)
                        {
                            if (pbxGrid[r, tempC].RightWall == true || pbxGrid[r, tempC + 1].BallOrHole > 0)
                            {
                                break;
                            }
                            if (pbxGrid[r, tempC + 1].BallOrHole < 0)
                            {
                                if (pbxGrid[r, tempC + 1].BallOrHole + pbxGrid[r, tempC].BallOrHole == 0)
                                {
                                    pbxGrid[r, tempC + 1].BallOrHole = 0;
                                    pbxGrid[r, tempC].BallOrHole = 0;
                                    break;
                                }
                                else
                                {

                                    MessageBox.Show("Game Over!");
                                    return;
                                }

                            }
                            else
                            {
                                pbxGrid[r, tempC + 1].BallOrHole = pbxGrid[r, tempC].BallOrHole;
                                pbxGrid[r, tempC].BallOrHole = 0;
                                tempC++;
                                //updatepic();
                            }
                        }

                    }
                }
            }
            updatepic();
            Win();
            
            // MessageBox.Show("You Win!");
        }


        private void updatepic()
        {

            // LoadImage = Image.FromFile("puzzle.jpg");
            //float ratio = 1.0f;
            //float pbxWidth = 0.0f;
            //float pbxHeight = 0.0f;
            //int puzzleSize = 4;

            ////ratio should always be between 0 and 1
            //if (LoadImage.Width > LoadImage.Height)
            //{
            //    ratio = LoadImage.Height / LoadImage.Width;
            //    pbxWidth = reservedArea / puzzleSize;
            //    pbxHeight = ratio * pbxWidth;
            //}
            //else
            //{
            //    ratio = LoadImage.Width / LoadImage.Height;
            //    pbxHeight = reservedArea / puzzleSize;
            //    pbxWidth = ratio * pbxHeight;
            //}


            ////This memory is really requested when you do the file read.
            //pbxPuzzle = new PictureBox();

            ////The size of the individual picture boxes will be dictated by the
            ////number of pieces used and the dimensions of the input puzzle image
            //int r = 2;
            //int c = 1;

            //int puzzRow = 3;
            //int puzzCol = 2;

            for (int puzzCol = 0; puzzCol < size; puzzCol++)
            {
                for (int puzzRow = 0; puzzRow < size; puzzRow++)
                {
                    //   pbxGrid[puzzRow, puzzCol].Location = new System.Drawing.Point(50 + puzzCol * (int)pbxWidth, 50 + puzzRow * (int)pbxHeight);
                    // pbxGrid[puzzRow, puzzCol].Name = "pbxTrog"; //get this from the 2D array of buttons project
                    //pbxGrid[puzzRow, puzzCol].Size = new System.Drawing.Size((int)pbxWidth, (int)pbxHeight);
                    // pbxGrid[puzzRow, puzzCol].TabIndex = 2; //get this from the 2D array of buttons project
                    // pbxGrid[puzzRow, puzzCol].TabStop = false;
                    pbxWidth = picturebox.Width / puzzleSize;
                    pbxHeight = picturebox.Height /puzzleSize;
                    Bitmap bm = new Bitmap((int)pbxWidth, (int)pbxHeight);
                    Graphics g = Graphics.FromImage(bm);
                    Rectangle rec = new Rectangle(0, 0, (int)pbxWidth, (int)pbxHeight);


                    //there is a ball

                    int result = 0;
                    //16 here
                    if (pbxGrid[puzzRow, puzzCol].LeftWall == false && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 0;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 1;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == false && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 2;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 3;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 4;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 5;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 6;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 7;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == false && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 8;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 9;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == false && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 10;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == false && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 11;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == false && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 12;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == false)
                    {
                        result = 13;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == false && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 14;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].LeftWall == true && pbxGrid[puzzRow, puzzCol].RightWall == true && pbxGrid[puzzRow, puzzCol].TopWall == true && pbxGrid[puzzRow, puzzCol].BottomWall == true)
                    {
                        result = 15;
                    }

                    //PuzzleTileRow = 0;
                    //PuzzleTileCol = 0;

                    if (pbxGrid[puzzRow, puzzCol].BallOrHole > 0)
                    {
                        result += 32;
                    }
                    else if (pbxGrid[puzzRow, puzzCol].BallOrHole < 0)
                    {
                        result += 16;
                    }

                    PuzzleTileRow = result / 7;
                    PuzzleTileCol = result % 7;

                    g.DrawImage(LoadImage, rec, PuzzleTileCol * LoadImage.Width / 7, PuzzleTileRow * LoadImage.Height / 7, LoadImage.Width / 7, LoadImage.Height / 7, GraphicsUnit.Pixel);

                    int BallNumber = pbxGrid[puzzRow, puzzCol].BallOrHole;
                    Font f = new Font("Arial", 48.5f);
                    Brush b = new SolidBrush(Color.Lime);
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;


                    g.DrawString(BallNumber.ToString(), f, b, rec, sf);
                    pbxGrid[puzzRow, puzzCol].Image = bm;
                    // Controls.Add(pbxGrid[puzzRow, puzzCol]);



                }





            }

        }

        private void Select_Click(object sender, EventArgs e) // click folder
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                Bin_transfer = f2.Bintransfering;
                if (size > 0)
                {
                    for (int r = 0; r < size; r++)
                    {
                        for (int c = 0; c < size; c++)
                        {

                            Controls.Remove(pbxGrid[r, c]);
                        }
                    }
                }
                listView1.Items.Clear();
                clock1.Start();
                ArchiveLoc = f2.archiveLocation;
                ScoreLoad();

                UP.Enabled = true;
                right.Enabled = true;
                down.Enabled = true;
                Left.Enabled = true;


                //these two files have to come from either the mrb file path or the path to the extracted jpg and txt files from f2

                string[] lines = System.IO.File.ReadAllLines(f2.Textpath);
                string[] pieces = lines[0].Split(' ');



                //float ratio = 1.0f;
                //float pbxWidth = 0.0f;
                //float pbxHeight = 0.0f;
                //int puzzleSize = 4;

                // ratio should always be between 0 and 1
                LoadImage = Image.FromFile(f2.Imagepath);
                if (LoadImage.Width > LoadImage.Height)
                {
                    ratio = LoadImage.Height / LoadImage.Width;
                    pbxWidth = reservedArea / puzzleSize;
                    pbxHeight = (int)(ratio * pbxWidth);
                }
                else
                {
                    ratio = LoadImage.Width / LoadImage.Height;
                    pbxHeight = reservedArea / puzzleSize;
                    pbxWidth = (int)(ratio * pbxHeight);
                }

                size = Convert.ToInt32(pieces[0]);
                ballCount = Convert.ToInt32(pieces[1]);
                wallCount = Convert.ToInt32(pieces[2]);


                tbl1.Controls.Add(tb2, 0, 0);
                //tb2.Controls.Add(picturebox, 0, 0);


                TableLayoutPanel RatioPanel = new TableLayoutPanel();
                RatioPanel.Margin = new Padding(0);
                RatioPanel.Name = "RatioPanel";
                RatioPanel.Dock = DockStyle.Fill;
                tbl1.Controls.Add(RatioPanel, 0, 0);

                string ImagePath = f2.Imagepath;

                
                string TextPath = f2.Textpath;


                picturebox = new TableLayoutPanel();
                picturebox.Dock = System.Windows.Forms.DockStyle.Fill;
                picturebox.Name = "picturebox";
                picturebox.Margin = new System.Windows.Forms.Padding(0);
                picturebox.RowCount = size;
                picturebox.ColumnCount = size;

                RatioPanel.Controls.Add(picturebox, 0, 0);

                

                using (Image temp = Image.FromFile(ImagePath))
                {
                    int ImageWidth = temp.Width;
                    int ImageHeight = temp.Height;

                    if (ImageWidth > ImageHeight)
                    {
                        //Width is bigger
                        float ratio = ImageHeight / (float)ImageWidth;
                        RatioPanel.ColumnCount = 1;
                        RatioPanel.RowCount = 2;

                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, ratio * 100F));
                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F - ratio * 100F));

                    }
                    else
                    {
                        //Height is bigger
                        float ratio = ImageWidth / (float)ImageHeight;
                        RatioPanel.ColumnCount = 2;
                        RatioPanel.RowCount = 1;

                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, ratio * 100F));
                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F - ratio * 100F));

                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                    }



                    for (int i = 0; i < size; i++)
                    {
                        picturebox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / (float)size));
                        picturebox.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / (float)size));
                    }

                    pbxWidth = picturebox.Width / size;
                    pbxHeight = picturebox.Height / size;
                    pbxGrid = new PuzzlePictureBox[size, size];
                    for (int r = 0; r < size; r++)
                    {
                        for (int c = 0; c < size; c++)
                        {
                            pbxGrid[r, c] = new PuzzlePictureBox();
                            pbxGrid[r, c].Name = "b" + r.ToString() + " " + c.ToString();
                            pbxGrid[r, c].Dock = System.Windows.Forms.DockStyle.Fill;
                            pbxGrid[r, c].Row = r;
                            pbxGrid[r, c].Column = c;
                            pbxGrid[r, c].Margin = new Padding(0);
                            picturebox.Controls.Add(pbxGrid[r, c], c, r);



                        }
                    }
                }


                for (int i = 0; i < ballCount; i++)
                {
                    string[] ballPieces = lines[i + 1].Split(' '); //plus 1 because we read the first line already
                    int r = Convert.ToInt32(ballPieces[0]);
                    int c = Convert.ToInt32(ballPieces[1]);
                    pbxGrid[r, c].BallOrHole = i + 1;
                }

                for (int i = 0; i < ballCount; i++)
                {
                    string[] holePieces = lines[i + 1 + ballCount].Split(' '); //plus 1 because we read the first line already
                    int r = Convert.ToInt32(holePieces[0]);
                    int c = Convert.ToInt32(holePieces[1]);
                    pbxGrid[r, c].BallOrHole = 0 - (i + 1);
                }

                for (int i = 0; i < wallCount; i++)
                {
                    string[] wallPieces = lines[i + 1 + (2 * ballCount)].Split(' '); //plus 1 because we read the first line already
                    int r1 = Convert.ToInt32(wallPieces[0]);
                    int c1 = Convert.ToInt32(wallPieces[1]);
                    int r2 = Convert.ToInt32(wallPieces[2]);
                    int c2 = Convert.ToInt32(wallPieces[3]);

                    if (r1 == r2)
                    {
                        if (c1 > c2)
                        {
                            pbxGrid[r1, c1].LeftWall = true;
                            pbxGrid[r2, c2].RightWall = true;
                        }
                        else
                        {
                            pbxGrid[r1, c1].RightWall = true;
                            pbxGrid[r2, c2].LeftWall = true;
                        }
                    }
                    else
                    {
                        if (r1 > r2)
                        {
                            pbxGrid[r1, c1].TopWall = true;
                            pbxGrid[r2, c2].BottomWall = true;
                        }
                        else
                        {
                            pbxGrid[r1, c1].BottomWall = true;
                            pbxGrid[r2, c2].TopWall = true;
                        }
                    }
                }


                updatepic();

            }
        }


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int DiffW = Math.Abs(Width - OldWidth); //Tells us how much W was changed
            int DiffH = Math.Abs(Height - OldHeight); //Tells us how much W was changed


            if (Width > Screen.PrimaryScreen.WorkingArea.Height)
            {
                Width = Screen.PrimaryScreen.WorkingArea.Height;
                Height = Screen.PrimaryScreen.WorkingArea.Height - 127;
            }
            else if (DiffH > DiffW)
            {
                Width = Height + 127;
            }
            else if (DiffW > DiffH)
            {
                Height = Width - 127;
            }

            OldHeight = Height;
            OldWidth = Width;
            updatepic();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            
            
          
        }

        private void Save_list()
        {
            List<PersonItem> sortedlist = highest_score.OrderBy(x => x.Moves).ThenBy(x => x.Time).ToList();
            highest_score = sortedlist;


            IFormatter format = new BinaryFormatter();

            using (ZipArchive archive = ZipFile.Open(ArchiveLoc, ZipArchiveMode.Update))
            {
                ZipArchiveEntry oldEntry = archive.GetEntry("puzzle.bin");
                if (oldEntry != null)
                {
                    oldEntry.Delete();
                }
                ZipArchiveEntry scoreEntry = archive.CreateEntry("puzzle.bin");


                using (Stream stream = scoreEntry.Open())
                {
                    format.Serialize(stream, highest_score);
                }
            }

        }
        private void AddPerson(PersonItem person)
        {
            ListViewItem listv = new ListViewItem();


            listv.Text = person.Name;
            listv.SubItems.Add(person.Moves.ToString());
            listv.SubItems.Add(person.Time.ToString());


            listView1.Items.Add(listv);


        }



        private void ScoreLoad()  
        {


            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream stream = new FileStream(Bin_transfer, FileMode.Open, FileAccess.Read))  // fix this
                {
                    highest_score = (List<PersonItem>)formatter.Deserialize(stream);

                    foreach (PersonItem p in highest_score)
                    {

                        AddPerson(p);
                    }
                }
            }
            catch (FileNotFoundException f)
            {

            }

        }

    }
}
    




  



